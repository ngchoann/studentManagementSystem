using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using OracleCmd = Oracle.ManagedDataAccess.Client.OracleCommand;

namespace StudentManagementSystem.Forms
{
    public partial class SystemConfigForm : Form
    {
        private bool _hasDbaPrivilege = false;

        public SystemConfigForm() => InitializeComponent();

        private void SystemConfigForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối trước khi load
            if (!IsConnected())
            {
                ShowWarning("Chưa có kết nối database. Vui lòng đăng nhập lại.");
                return;
            }

            // Kiểm tra quyền DBA
            CheckDbaPrivilege();
            
            LoadTablespaceData();
            LoadProfileData();
            LoadUsersForProfile();
            LoadSessionData();
            LoadResourceData();
        }

        private void CheckDbaPrivilege()
        {
            try
            {
                using var conn = GetConn();
                conn.Open();
                using var cmd = new OracleCmd("SELECT COUNT(*) FROM dba_users WHERE ROWNUM = 1", conn);
                cmd.ExecuteScalar();
                _hasDbaPrivilege = true;
            }
            catch
            {
                _hasDbaPrivilege = false;
                ShowWarning("User hiện tại không có quyền DBA.\nMột số chức năng sẽ bị hạn chế.\n\nĐể có đầy đủ quyền, chạy:\nGRANT DBA TO ADMIN_MASTER;");
            }
        }

        private bool IsConnected()
        {
            try
            {
                return !string.IsNullOrEmpty(DAL.OracleConnection.Instance.ConnectionString);
            }
            catch { return false; }
        }

        private OracleConnection GetConn() => DAL.OracleConnection.Instance.GetConnection();
        private static void ShowError(string msg, Exception ex) => MessageBox.Show($"{msg}:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private DataTable RunQuery(string sql)
        {
            using var conn = GetConn();
            conn.Open();
            using var cmd = new OracleCmd(sql, conn);
            using var adapter = new OracleDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private void RunNonQuery(string sql)
        {
            using var conn = GetConn();
            conn.Open();
            using var cmd = new OracleCmd(sql, conn);
            cmd.ExecuteNonQuery();
        }

        #region Tablespace
        private void LoadTablespaceData()
        {
            if (!_hasDbaPrivilege)
            {
                lblTablespaceInfo.Text = "Cần quyền DBA để xem Tablespace";
                return;
            }
            try
            {
                dgvTablespace.DataSource = RunQuery(@"SELECT ts.tablespace_name AS ""Tên Tablespace"", ROUND(SUM(df.bytes)/1024/1024,2) AS ""Dung lượng (MB)"",
                    ts.status AS ""Trạng thái"", ts.contents AS ""Loại"", ts.extent_management AS ""Quản lý Extent"", ts.segment_space_management AS ""Quản lý Segment""
                    FROM dba_tablespaces ts LEFT JOIN dba_data_files df ON ts.tablespace_name=df.tablespace_name
                    GROUP BY ts.tablespace_name,ts.status,ts.contents,ts.extent_management,ts.segment_space_management ORDER BY ts.tablespace_name");
                lblTablespaceInfo.Text = $"Tổng: {dgvTablespace.Rows.Count} tablespaces | Dữ liệu thật từ Oracle";
            }
            catch (Exception ex) { lblTablespaceInfo.Text = $"Lỗi: {ex.Message}"; }
        }

        private void btnRefreshTablespace_Click(object sender, EventArgs e)
        {
            CheckDbaPrivilege();
            LoadTablespaceData();
            if (_hasDbaPrivilege) ShowInfo("Đã làm mới Tablespace!");
        }
        #endregion

        #region Profile
        private void LoadProfileData()
        {
            if (!_hasDbaPrivilege)
            {
                // Fallback: hiển thị thông tin cơ bản từ all_users
                try
                {
                    dgvProfile.DataSource = RunQuery(@"SELECT 'DEFAULT' AS ""Tên Profile"", COUNT(*) AS ""Số User"" FROM all_users");
                }
                catch { }
                return;
            }
            try
            {
                dgvProfile.DataSource = RunQuery(@"SELECT DISTINCT profile AS ""Tên Profile"", COUNT(*) OVER(PARTITION BY profile) AS ""Số User"" FROM dba_users ORDER BY profile");
            }
            catch { /* Đã xử lý ở trên */ }
        }

        private void btnRefreshProfile_Click(object sender, EventArgs e)
        {
            CheckDbaPrivilege();
            LoadProfileData();
            LoadUsersForProfile();
            if (_hasDbaPrivilege) ShowInfo("Đã làm mới Profile!");
        }

        private void dgvProfile_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfile.SelectedRows.Count > 0)
            {
                var val = dgvProfile.SelectedRows[0].Cells["Tên Profile"].Value;
                if (val != null && !string.IsNullOrEmpty(val.ToString()))
                {
                    var profileName = val.ToString()!;
                    LoadProfileDetails(profileName);
                    txtProfileName.Text = profileName;
                    LoadProfileSettingsToForm(profileName);
                }
            }
        }

        private void LoadProfileDetails(string name)
        {
            if (!_hasDbaPrivilege)
            {
                lblProfileDetail.Text = $"{name}\n(Cần quyền DBA để xem chi tiết)";
                return;
            }
            try
            {
                using var conn = GetConn();
                conn.Open();
                using var cmd = new OracleCmd("SELECT resource_name, limit FROM dba_profiles WHERE profile=:p ORDER BY resource_name", conn);
                cmd.Parameters.Add(new OracleParameter("p", name));
                var sb = new StringBuilder($"{name}\n");
                using var r = cmd.ExecuteReader();
                while (r.Read()) sb.AppendLine($"• {r["resource_name"]}: {r["limit"]}");
                lblProfileDetail.Text = sb.ToString();
            }
            catch (Exception ex) { lblProfileDetail.Text = $"Lỗi: {ex.Message}"; }
        }

        private void LoadProfileSettingsToForm(string profileName)
        {
            if (!_hasDbaPrivilege) return;
            try
            {
                using var conn = GetConn();
                conn.Open();
                using var cmd = new OracleCmd(@"SELECT resource_name, limit FROM dba_profiles 
                    WHERE profile=:p AND resource_name IN('FAILED_LOGIN_ATTEMPTS','PASSWORD_LOCK_TIME','SESSIONS_PER_USER','IDLE_TIME','CONNECT_TIME')", conn);
                cmd.Parameters.Add(new OracleParameter("p", profileName));
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var res = r["resource_name"].ToString()!;
                    var lim = r["limit"].ToString()!;
                    if (lim.Equals("UNLIMITED", StringComparison.OrdinalIgnoreCase) || lim.Equals("DEFAULT", StringComparison.OrdinalIgnoreCase)) continue;
                    if (int.TryParse(lim, out int v))
                    {
                        switch (res)
                        {
                            case "FAILED_LOGIN_ATTEMPTS": numProfFailedLogin.Value = Math.Min(v, (int)numProfFailedLogin.Maximum); break;
                            case "PASSWORD_LOCK_TIME": numProfLockTime.Value = Math.Min(v * 1440, (int)numProfLockTime.Maximum); break;
                            case "SESSIONS_PER_USER": numProfSessions.Value = Math.Min(v, (int)numProfSessions.Maximum); break;
                            case "IDLE_TIME": numProfIdleTime.Value = Math.Min(v, (int)numProfIdleTime.Maximum); break;
                            case "CONNECT_TIME": numProfConnectTime.Value = Math.Min(v, (int)numProfConnectTime.Maximum); break;
                        }
                    }
                }
            }
            catch { /* Ignore */ }
        }

        private void LoadUsersForProfile()
        {
            lstUsersForProfile.Items.Clear();
            if (!_hasDbaPrivilege) return;
            try
            {
                using var conn = GetConn();
                conn.Open();
                using var cmd = new OracleCmd(@"SELECT username, profile FROM dba_users 
                    WHERE username NOT IN('SYS','SYSTEM','SYSMAN','OUTLN','DBSNMP','XDB','ANONYMOUS','APEX_PUBLIC_USER','FLOWS_FILES','APEX_040000','APEX_030200','OWBSYS','ORDDATA','CTXSYS','MDSYS','OLAPSYS','ORDSYS','EXFSYS','WMSYS','SYSMAN','LBACSYS','DVSYS','DVF','AUDSYS','GSMADMIN_INTERNAL','SYSBACKUP','SYSDG','SYSKM','SYSRAC','SYS$UMF','DBSFWUSER','REMOTE_SCHEDULER_AGENT','GGSYS','OJVMSYS','APPQOSSYS','DIP','XS$NULL') 
                    ORDER BY username", conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var user = r["username"].ToString()!;
                    var profile = r["profile"].ToString()!;
                    lstUsersForProfile.Items.Add($"{user} [{profile}]");
                }
            }
            catch { /* Ignore */ }
        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            if (!_hasDbaPrivilege) { ShowWarning("Cần quyền DBA!"); return; }
            var name = txtProfileName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(name)) { ShowWarning("Nhập tên Profile!"); return; }
            if (!name.StartsWith("PROFILE_")) name = "PROFILE_" + name;

            try
            {
                var limits = GetProfileLimitsFromForm();
                RunNonQuery($"CREATE PROFILE {name} LIMIT {limits}");
                ShowInfo($"Tạo Profile '{name}' thành công!");
                LoadProfileData();
                LoadUsersForProfile();
            }
            catch (Exception ex) { ShowError("Lỗi tạo Profile", ex); }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (!_hasDbaPrivilege) { ShowWarning("Cần quyền DBA!"); return; }
            var name = txtProfileName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(name)) { ShowWarning("Chọn Profile để cập nhật!"); return; }
            if (name == "DEFAULT") { ShowWarning("Không thể sửa Profile DEFAULT!"); return; }

            try
            {
                var limits = GetProfileLimitsFromForm();
                RunNonQuery($"ALTER PROFILE {name} LIMIT {limits}");
                ShowInfo($"Cập nhật Profile '{name}' thành công!");
                LoadProfileData();
            }
            catch (Exception ex) { ShowError("Lỗi cập nhật Profile", ex); }
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (!_hasDbaPrivilege) { ShowWarning("Cần quyền DBA!"); return; }
            var name = txtProfileName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(name)) { ShowWarning("Chọn Profile để xóa!"); return; }
            if (name == "DEFAULT") { ShowWarning("Không thể xóa Profile DEFAULT!"); return; }

            if (MessageBox.Show($"Xóa Profile '{name}'?\nUsers đang dùng sẽ chuyển về DEFAULT.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                RunNonQuery($"DROP PROFILE {name} CASCADE");
                ShowInfo($"Xóa Profile '{name}' thành công!");
                txtProfileName.Text = "";
                LoadProfileData();
                LoadUsersForProfile();
            }
            catch (Exception ex) { ShowError("Lỗi xóa Profile", ex); }
        }

        private void btnApplyProfileToUsers_Click(object sender, EventArgs e)
        {
            if (!_hasDbaPrivilege) { ShowWarning("Cần quyền DBA!"); return; }
            var profileName = txtProfileName.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(profileName)) { ShowWarning("Chọn hoặc nhập tên Profile!"); return; }

            var selectedUsers = lstUsersForProfile.CheckedItems.Cast<string>().ToList();
            if (selectedUsers.Count == 0) { ShowWarning("Chọn ít nhất 1 user!"); return; }

            if (MessageBox.Show($"Áp dụng Profile '{profileName}' cho {selectedUsers.Count} users?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int success = 0, fail = 0;
            foreach (var item in selectedUsers)
            {
                var username = item.Split('[')[0].Trim();
                try
                {
                    RunNonQuery($"ALTER USER {username} PROFILE {profileName}");
                    success++;
                }
                catch { fail++; }
            }

            ShowInfo($"Hoàn thành!\nThành công: {success}\nThất bại: {fail}");
            LoadProfileData();
            LoadUsersForProfile();
        }

        private string GetProfileLimitsFromForm()
        {
            var lockDays = numProfLockTime.Value / 1440m;
            return $"FAILED_LOGIN_ATTEMPTS {numProfFailedLogin.Value} " +
                   $"PASSWORD_LOCK_TIME {lockDays} " +
                   $"SESSIONS_PER_USER {numProfSessions.Value} " +
                   $"IDLE_TIME {numProfIdleTime.Value} " +
                   $"CONNECT_TIME {numProfConnectTime.Value}";
        }
        #endregion

        #region Session
        private void LoadSessionData()
        {
            if (!_hasDbaPrivilege)
            {
                lblSessionInfo.Text = "Cần quyền DBA để xem Sessions";
                return;
            }
            try
            {
                dgvSession.DataSource = RunQuery(@"SELECT sid AS ""SID"", serial# AS ""Serial#"", username AS ""Username"", status AS ""Trạng thái"",
                    osuser AS ""OS User"", machine AS ""Máy"", program AS ""Chương trình"", TO_CHAR(logon_time,'DD/MM/YYYY HH24:MI:SS') AS ""Đăng nhập"",
                    last_call_et AS ""Hoạt động (s)"" FROM v$session WHERE username IS NOT NULL ORDER BY logon_time DESC");
                lblSessionInfo.Text = $"Sessions: {dgvSession.Rows.Count} | Dữ liệu thật từ v$session";
            }
            catch (Exception ex) { lblSessionInfo.Text = $"Lỗi: {ex.Message}"; }
        }

        private void btnRefreshSession_Click(object sender, EventArgs e)
        {
            CheckDbaPrivilege();
            LoadSessionData();
            if (_hasDbaPrivilege) ShowInfo("Đã làm mới Session!");
        }

        private void btnKillSession_Click(object sender, EventArgs e)
        {
            if (!_hasDbaPrivilege) { ShowWarning("Cần quyền DBA để kill session!"); return; }
            if (dgvSession.SelectedRows.Count == 0) { ShowWarning("Chọn session để kill!"); return; }
            var row = dgvSession.SelectedRows[0];
            var sid = row.Cells["SID"].Value?.ToString();
            var serial = row.Cells["Serial#"].Value?.ToString();
            var user = row.Cells["Username"].Value?.ToString();
            if (MessageBox.Show($"Kill session?\nSID={sid}, Serial#={serial}, User={user}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    RunNonQuery($"ALTER SYSTEM KILL SESSION '{sid},{serial}' IMMEDIATE");
                    ShowInfo("Kill thành công!");
                    LoadSessionData();
                }
                catch (Exception ex) { ShowError("Lỗi kill session", ex); }
            }
        }
        #endregion

        #region Resource
        private void LoadResourceData()
        {
            if (!_hasDbaPrivilege)
            {
                lblResourceInfo.Text = "Cần quyền DBA để xem Resource";
                return;
            }
            try
            {
                dgvResource.DataSource = RunQuery(@"SELECT name AS ""Tài nguyên"", value AS ""Giá trị"" FROM v$parameter
                    WHERE name IN('sessions','processes','cpu_count','memory_target','sga_target','pga_aggregate_target','db_block_size','open_cursors','parallel_max_servers') ORDER BY name");
                lblResourceInfo.Text = "Dữ liệu thật từ v$parameter | sessions/processes: tối đa connections";
            }
            catch (Exception ex) { lblResourceInfo.Text = $"Lỗi: {ex.Message}"; }
        }

        private void btnRefreshResource_Click(object sender, EventArgs e)
        {
            CheckDbaPrivilege();
            LoadResourceData();
            if (_hasDbaPrivilege) ShowInfo("Đã làm mới Resource!");
        }
        #endregion
    }
}
