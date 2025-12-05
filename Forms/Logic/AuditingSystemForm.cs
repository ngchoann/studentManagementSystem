using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace StudentManagementSystem.Forms
{
    public partial class AuditingSystemForm : Form
    {
        private const string ConnectionString = "User Id=ADMIN_MASTER;Password=123;Data Source=localhost:1521/orcl21pdb1;";
        private OracleConnection _connection = null!;

        public AuditingSystemForm()
        {
            InitializeComponent();
            InitializeConnection();
            LoadUsers();
            LoadActions();
            LoadStandardAudit();
        }

        private void InitializeConnection()
        {
            try
            {
                _connection = new OracleConnection(ConnectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            cmbAuditUser.Items.Clear();
            cmbAuditUser.Items.Add("-- Tất cả --");
            try
            {
                using var command = new OracleCommand("SELECT DISTINCT username FROM AUDIT_LOGS ORDER BY username", _connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string username = reader["username"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(username))
                        cmbAuditUser.Items.Add(username);
                }
            }
            catch { }
            cmbAuditUser.SelectedIndex = 0;
        }

        private void LoadActions()
        {
            cmbAuditAction.Items.Clear();
            cmbAuditAction.Items.AddRange(new[] { "-- Tất cả --", "INSERT", "UPDATE", "DELETE", "LOGIN", "LOGOUT", "APP_LOGIN", "APP_LOGOUT" });
            cmbAuditAction.SelectedIndex = 0;
        }

        private void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: LoadStandardAudit(); break;
                case 1: LoadTriggerAudit(); break;
                case 2: LoadFineGrainedAudit(); break;
                case 3: LoadOracleLabelSecurity(); break;
            }
        }

        private void LoadStandardAudit()
        {
            try
            {
                string sql = @"SELECT AUDIT_ID, USERNAME, ACTION_TYPE, OBJECT_NAME, AUDIT_TIME, IP_ADDRESS, COMMENTS 
                               FROM AUDIT_LOGS WHERE AUDIT_TIME BETWEEN :startDate AND :endDate";
                
                if (cmbAuditUser.SelectedIndex > 0)
                    sql += " AND USERNAME = :username";
                if (cmbAuditAction.SelectedIndex > 0)
                    sql += " AND ACTION_TYPE = :actionType";
                
                sql += " ORDER BY AUDIT_TIME DESC";

                using var command = new OracleCommand(sql, _connection);
                command.Parameters.Add(":startDate", OracleDbType.Date).Value = dtpFromDate.Value.Date;
                command.Parameters.Add(":endDate", OracleDbType.Date).Value = dtpToDate.Value.Date.AddDays(1);
                
                if (cmbAuditUser.SelectedIndex > 0)
                    command.Parameters.Add(":username", cmbAuditUser.SelectedItem?.ToString());
                if (cmbAuditAction.SelectedIndex > 0)
                    command.Parameters.Add(":actionType", cmbAuditAction.SelectedItem?.ToString());

                dgvStandardAudit.DataSource = ExecuteQuery(command);
                lblStatus.Text = $"Standard Audit: {dgvStandardAudit.RowCount} bản ghi";
                rtbAuditReport.Text = $"Tổng: {dgvStandardAudit.RowCount} | Từ: {dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Standard Audit", ex);
            }
        }

        private void LoadTriggerAudit()
        {
            try
            {
                string sql = @"SELECT CHANGE_ID, TABLE_NAME, OPERATION, RECORD_KEY, COLUMN_NAME, 
                               OLD_VALUE, NEW_VALUE, CHANGED_BY, CHANGED_AT 
                               FROM AUDIT_DATA_CHANGES WHERE 1=1";
                
                if (cmbTriggerTable.SelectedIndex > 0)
                    sql += $" AND TABLE_NAME = '{cmbTriggerTable.SelectedItem}'";
                if (cmbTriggerOp.SelectedIndex > 0)
                    sql += $" AND OPERATION = '{cmbTriggerOp.SelectedItem}'";
                
                sql += " ORDER BY CHANGED_AT DESC";

                dgvTriggerAudit.DataSource = ExecuteQuery(new OracleCommand(sql, _connection));
                lblStatus.Text = $"Trigger Audit: {dgvTriggerAudit.RowCount} bản ghi";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Trigger Audit", ex);
            }
        }

        private void LoadFineGrainedAudit()
        {
            try
            {
                string policiesSql = @"SELECT POLICY_NAME ""Policy"", OBJECT_NAME ""Bảng"", POLICY_COLUMN ""Cột"", 
                                       ENABLED ""TT"", SEL, INS, UPD, DEL 
                                       FROM DBA_AUDIT_POLICIES 
                                       WHERE OBJECT_SCHEMA = 'ADMIN_MASTER' 
                                       ORDER BY POLICY_NAME";

                string logsSql = @"SELECT EXTENDED_TIMESTAMP ""Thời gian"", DB_USER ""User"", OBJECT_NAME ""Bảng"", 
                                   POLICY_NAME ""Policy"", SUBSTR(SQL_TEXT, 1, 200) ""SQL"", STATEMENT_TYPE ""Loại"" 
                                   FROM DBA_FGA_AUDIT_TRAIL 
                                   WHERE OBJECT_SCHEMA = 'ADMIN_MASTER' 
                                   ORDER BY EXTENDED_TIMESTAMP DESC 
                                   FETCH FIRST 100 ROWS ONLY";

                dgvFGAPolicies.DataSource = ExecuteQuery(new OracleCommand(policiesSql, _connection));
                dgvFGALogs.DataSource = ExecuteQuery(new OracleCommand(logsSql, _connection));
                lblStatus.Text = $"FGA: {dgvFGAPolicies.RowCount} policies, {dgvFGALogs.RowCount} logs";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("FGA", ex);
            }
        }

        private void LoadOracleLabelSecurity()
        {
            try
            {
                const string policyName = "BMCSDL_OLS";
                
                dgvOLSPolicy.DataSource = ExecuteQuery(new OracleCommand(
                    $"SELECT POLICY_NAME, STATUS, COLUMN_NAME FROM DBA_SA_POLICIES WHERE POLICY_NAME = '{policyName}'", _connection));
                
                dgvOLSLevels.DataSource = ExecuteQuery(new OracleCommand(
                    $"SELECT LEVEL_NUM \"#\", SHORT_NAME \"Mã\", LONG_NAME \"Tên\" FROM DBA_SA_LEVELS WHERE POLICY_NAME = '{policyName}' ORDER BY LEVEL_NUM", _connection));
                
                dgvOLSCompartments.DataSource = ExecuteQuery(new OracleCommand(
                    $"SELECT COMP_NUM \"#\", SHORT_NAME \"Mã\", LONG_NAME \"Tên\" FROM DBA_SA_COMPARTMENTS WHERE POLICY_NAME = '{policyName}' ORDER BY COMP_NUM", _connection));
                
                dgvOLSLabels.DataSource = ExecuteQuery(new OracleCommand(
                    $"SELECT LABEL_TAG \"Tag\", LABEL \"Nhãn\" FROM DBA_SA_LABELS WHERE POLICY_NAME = '{policyName}' ORDER BY LABEL_TAG", _connection));
                
                dgvOLSUserLabels.DataSource = ExecuteQuery(new OracleCommand(
                    $"SELECT USER_NAME \"User\", MAX_READ_LABEL \"Read\", MAX_WRITE_LABEL \"Write\" FROM DBA_SA_USER_LABELS WHERE POLICY_NAME = '{policyName}'", _connection));
                
                lblStatus.Text = "OLS: Đã tải cấu hình";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"OLS chưa được cấu hình: {ex.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable ExecuteQuery(OracleCommand command)
        {
            var dataTable = new DataTable();
            using var adapter = new OracleDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        private void ShowErrorMessage(string source, Exception ex)
        {
            MessageBox.Show($"Lỗi {source}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = $"Lỗi {source}";
        }

        private void BtnRefreshAudit_Click(object? sender, EventArgs e) => LoadStandardAudit();
        private void BtnRefreshTrigger_Click(object? sender, EventArgs e) => LoadTriggerAudit();
        private void BtnRefreshFGA_Click(object? sender, EventArgs e) => LoadFineGrainedAudit();
        private void BtnRefreshOLS_Click(object? sender, EventArgs e) => LoadOracleLabelSecurity();
    }
}
