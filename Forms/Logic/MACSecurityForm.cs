using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Forms
{
    public partial class MACSecurityForm : Form
    {
        private const string ConnectionString = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";

        public MACSecurityForm()
        {
            InitializeComponent();
            InitializeConnection();
            LoadInitialData();
        }

        #region Initialization

        private void InitializeConnection()
        {
            try
            {
                connection = new OracleConnection(ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInitialData()
        {
            try
            {
                LoadSecurityLevels();
                LoadUsers();
                LoadUserClearances();
                LoadTablePolicies();
                LoadAuditLog();
                lblStatus.Text = "Data loaded successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error loading data: {ex.Message}";
            }
        }

        #endregion

        #region Data Loading

        private void LoadSecurityLevels()
        {
            cmbSecurityLevels.Items.Clear();
            try
            {
                using var cmd = new OracleCommand("SELECT level_name FROM mac_security_levels ORDER BY level_value", connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbSecurityLevels.Items.Add(reader["LEVEL_NAME"].ToString());
            }
            catch { cmbSecurityLevels.Items.AddRange(new[] { "PUBLIC", "CONFIDENTIAL", "SECRET", "TOP_SECRET" }); }
            
            if (cmbSecurityLevels.Items.Count > 0) cmbSecurityLevels.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            cmbUsers.Items.Clear();
            cmbUsers.Items.Add("-- Select User --");
            cmbUsers.Items.Add("-- Enter Custom User --");

            try
            {
                string sql = @"SELECT username FROM dba_users WHERE username NOT LIKE '%$%' 
                              AND username NOT IN ('SYS','SYSTEM','ANONYMOUS','CTXSYS','DBSNMP','XDB') ORDER BY username";
                using var cmd = new OracleCommand(sql, connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string username = reader["username"].ToString() ?? "";
                    if (!string.IsNullOrEmpty(username)) cmbUsers.Items.Add(username);
                }
            }
            catch
            {
                cmbUsers.Items.AddRange(new[] { "ADMIN_MASTER", "GV001", "SV001" });
            }
            cmbUsers.SelectedIndex = 0;
        }

        private void LoadUserClearances()
        {
            try
            {
                string sql = "SELECT username, security_level, granted_by, granted_date, is_active FROM user_security_clearances ORDER BY username";
                var adapter = new OracleDataAdapter(sql, connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvUserClearances.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clearances: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTablePolicies()
        {
            try
            {
                string sql = "SELECT table_name, policy_name, policy_function, is_enabled, created_date FROM mac_table_policies ORDER BY table_name";
                var adapter = new OracleDataAdapter(sql, connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvTablePolicies.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading policies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuditLog()
        {
            try
            {
                string sql = "SELECT username, table_name, operation, security_level, access_granted, log_timestamp FROM mac_audit_log WHERE log_timestamp >= SYSDATE - 30 ORDER BY log_timestamp DESC";
                var adapter = new OracleDataAdapter(sql, connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvAuditLog.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audit log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void CmbUsers_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem?.ToString() == "-- Enter Custom User --")
            {
                string customUser = Microsoft.VisualBasic.Interaction.InputBox("Enter username:", "Custom User Input", "");
                if (!string.IsNullOrEmpty(customUser))
                {
                    if (!cmbUsers.Items.Contains(customUser.ToUpper()))
                        cmbUsers.Items.Add(customUser.ToUpper());
                    cmbUsers.SelectedItem = customUser.ToUpper();
                }
            }
        }

        private void BtnSetClearance_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUsers.Text) || cmbSecurityLevels.SelectedItem == null)
            {
                MessageBox.Show("Please select both user and security level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Set security clearance for '{cmbUsers.Text}' to '{cmbSecurityLevels.SelectedItem}'?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using var cmd = new OracleCommand("BEGIN ADMIN_MASTER.pkg_mac_security.set_user_security_level(:username, :level, 'ADMIN_MASTER'); END;", connection);
                    cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = cmbUsers.Text;
                    cmd.Parameters.Add("level", OracleDbType.Varchar2).Value = cmbSecurityLevels.SelectedItem.ToString();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Security clearance set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserClearances();
                    LoadAuditLog();
                    lblStatus.Text = $"Clearance set for {cmbUsers.Text}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCreatePolicy_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTableName.Text) || string.IsNullOrEmpty(txtPolicyName.Text))
            {
                MessageBox.Show("Please enter both table name and policy name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Create MAC policy '{txtPolicyName.Text}' for table '{txtTableName.Text}'?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using var cmd = new OracleCommand("BEGIN ADMIN_MASTER.pkg_mac_security.create_table_policy(:table_name, :policy_name, 'mac_security_function'); END;", connection);
                    cmd.Parameters.Add("table_name", OracleDbType.Varchar2).Value = txtTableName.Text.ToUpper();
                    cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = txtPolicyName.Text.ToUpper();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("MAC policy created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTablePolicies();
                    txtTableName.Clear();
                    txtPolicyName.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDropPolicy_Click(object? sender, EventArgs e)
        {
            if (dgvTablePolicies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a policy to drop.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvTablePolicies.SelectedRows[0];
            var tableName = row.Cells["TABLE_NAME"].Value?.ToString();
            var policyName = row.Cells["POLICY_NAME"].Value?.ToString();

            if (MessageBox.Show($"Drop policy '{policyName}' from table '{tableName}'?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using var cmd = new OracleCommand("BEGIN mac_security_pkg.drop_mac_policy(:table_name, :policy_name); END;", connection);
                    cmd.Parameters.Add("table_name", OracleDbType.Varchar2).Value = tableName;
                    cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = policyName;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Policy dropped successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTablePolicies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
