namespace StudentManagementSystem.Forms
{
    partial class AuditingSystemForm
    {
        private System.ComponentModel.IContainer components = null;
        private Oracle.ManagedDataAccess.Client.OracleConnection connection = null!;
        private System.Windows.Forms.TabControl tabControl = null!;
        private System.Windows.Forms.Label lblStatus = null!;
        private System.Windows.Forms.DataGridView dgvStandardAudit = null!, dgvTriggerAudit = null!, dgvFGAPolicies = null!, dgvFGALogs = null!;
        private System.Windows.Forms.DataGridView dgvOLSPolicy = null!, dgvOLSLevels = null!, dgvOLSCompartments = null!, dgvOLSLabels = null!, dgvOLSUserLabels = null!;
        private System.Windows.Forms.DateTimePicker dtpFromDate = null!, dtpToDate = null!;
        private System.Windows.Forms.ComboBox cmbAuditUser = null!, cmbAuditAction = null!, cmbTriggerTable = null!, cmbTriggerOp = null!;
        private System.Windows.Forms.RichTextBox rtbAuditReport = null!;
        private System.Windows.Forms.Button btnRefreshAudit = null!, btnRefreshTrigger = null!, btnRefreshFGA = null!, btnRefreshOLS = null!;
        private System.Windows.Forms.Label lblTriggerInfo = null!;

        protected override void Dispose(bool disposing) { if (disposing) { connection?.Close(); components?.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            Text = "Hệ Thống Audit & Bảo Mật"; Size = new System.Drawing.Size(1300, 850);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            BackColor = System.Drawing.Color.FromArgb(245, 245, 250);

            tabControl = new System.Windows.Forms.TabControl { Dock = System.Windows.Forms.DockStyle.Fill, Font = new System.Drawing.Font("Segoe UI", 10F) };
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            var tabs = new[] { ("Standard Audit", (System.Action<System.Windows.Forms.TabPage>)CreateStandardTab),
                              ("Trigger Audit", CreateTriggerTab), ("FGA Audit", CreateFGATab), ("OLS Security", CreateOLSTab) };
            foreach (var (name, create) in tabs) { var tab = new System.Windows.Forms.TabPage(name) { Padding = new System.Windows.Forms.Padding(10) }; create(tab); tabControl.TabPages.Add(tab); }

            Controls.Add(tabControl);
            lblStatus = new System.Windows.Forms.Label { Text = "Sẵn sàng", Dock = System.Windows.Forms.DockStyle.Bottom, Height = 30,
                BackColor = System.Drawing.Color.FromArgb(52, 73, 94), ForeColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(10, 5, 5, 5) };
            Controls.Add(lblStatus);
        }

        private void CreateStandardTab(System.Windows.Forms.TabPage tab)
        {
            var p = new System.Windows.Forms.Panel { Height = 50, Dock = System.Windows.Forms.DockStyle.Top, BackColor = System.Drawing.Color.White };
            dtpFromDate = new System.Windows.Forms.DateTimePicker { Location = new System.Drawing.Point(80, 10), Size = new System.Drawing.Size(130, 25), Value = System.DateTime.Now.AddDays(-30), Format = System.Windows.Forms.DateTimePickerFormat.Short };
            dtpToDate = new System.Windows.Forms.DateTimePicker { Location = new System.Drawing.Point(260, 10), Size = new System.Drawing.Size(130, 25), Value = System.DateTime.Now, Format = System.Windows.Forms.DateTimePickerFormat.Short };
            cmbAuditUser = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(445, 10), Size = new System.Drawing.Size(130, 25), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            cmbAuditAction = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(625, 10), Size = new System.Drawing.Size(100, 25), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            btnRefreshAudit = CreateBtn("Refresh", 740, 8, BtnRefreshAudit_Click);
            p.Controls.AddRange(new System.Windows.Forms.Control[] { Lbl("Từ:", 10, 12), dtpFromDate, Lbl("Đến:", 220, 12), dtpToDate, Lbl("User:", 400, 12), cmbAuditUser, Lbl("Action:", 580, 12), cmbAuditAction, btnRefreshAudit });
            dgvStandardAudit = Dgv();
            rtbAuditReport = new System.Windows.Forms.RichTextBox { Height = 100, Dock = System.Windows.Forms.DockStyle.Bottom, ReadOnly = true, Font = new System.Drawing.Font("Consolas", 9F), BackColor = System.Drawing.Color.FromArgb(30, 30, 30), ForeColor = System.Drawing.Color.LightGreen };
            tab.Controls.AddRange(new System.Windows.Forms.Control[] { dgvStandardAudit, rtbAuditReport, p });
        }

        private void CreateTriggerTab(System.Windows.Forms.TabPage tab)
        {
            var p = new System.Windows.Forms.Panel { Height = 50, Dock = System.Windows.Forms.DockStyle.Top, BackColor = System.Drawing.Color.White };
            cmbTriggerTable = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(60, 10), Size = new System.Drawing.Size(120, 25), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            cmbTriggerTable.Items.AddRange(new object[] { "-- Tất cả --", "SINHVIEN", "GIAOVIEN", "DIEM" }); cmbTriggerTable.SelectedIndex = 0;
            cmbTriggerOp = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(270, 10), Size = new System.Drawing.Size(100, 25), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            cmbTriggerOp.Items.AddRange(new object[] { "-- Tất cả --", "INSERT", "UPDATE", "DELETE" }); cmbTriggerOp.SelectedIndex = 0;
            btnRefreshTrigger = CreateBtn("Refresh", 390, 8, BtnRefreshTrigger_Click);
            p.Controls.AddRange(new System.Windows.Forms.Control[] { Lbl("Bảng:", 10, 12), cmbTriggerTable, Lbl("Thao tác:", 200, 12), cmbTriggerOp, btnRefreshTrigger });
            dgvTriggerAudit = Dgv();
            var info = new System.Windows.Forms.Panel { Height = 60, Dock = System.Windows.Forms.DockStyle.Bottom, BackColor = System.Drawing.Color.FromArgb(240, 248, 255), Padding = new System.Windows.Forms.Padding(10) };
            lblTriggerInfo = new System.Windows.Forms.Label { Dock = System.Windows.Forms.DockStyle.Fill, Text = "Trigger ghi lại INSERT/UPDATE/DELETE trên SINHVIEN, GIAOVIEN, DIEM vào bảng AUDIT_DATA_CHANGES." };
            info.Controls.Add(lblTriggerInfo);
            tab.Controls.AddRange(new System.Windows.Forms.Control[] { dgvTriggerAudit, info, p });
        }

        private void CreateFGATab(System.Windows.Forms.TabPage tab)
        {
            var split = new System.Windows.Forms.SplitContainer { Dock = System.Windows.Forms.DockStyle.Fill, Orientation = System.Windows.Forms.Orientation.Horizontal, SplitterDistance = 180 };
            var lbl1 = new System.Windows.Forms.Label { Text = "FGA Policies:", Dock = System.Windows.Forms.DockStyle.Top, Height = 25, Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            dgvFGAPolicies = Dgv(); split.Panel1.Controls.AddRange(new System.Windows.Forms.Control[] { dgvFGAPolicies, lbl1 });
            var p = new System.Windows.Forms.Panel { Height = 40, Dock = System.Windows.Forms.DockStyle.Top, BackColor = System.Drawing.Color.White };
            p.Controls.AddRange(new System.Windows.Forms.Control[] { new System.Windows.Forms.Label { Text = "FGA Logs:", Location = new System.Drawing.Point(10, 10), Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold), AutoSize = true }, btnRefreshFGA = CreateBtn("Refresh", 150, 5, BtnRefreshFGA_Click) });
            dgvFGALogs = Dgv(); split.Panel2.Controls.AddRange(new System.Windows.Forms.Control[] { dgvFGALogs, p });
            tab.Controls.Add(split);
        }

        private void CreateOLSTab(System.Windows.Forms.TabPage tab)
        {
            var p = new System.Windows.Forms.Panel { Height = 40, Dock = System.Windows.Forms.DockStyle.Top, BackColor = System.Drawing.Color.White };
            btnRefreshOLS = CreateBtn("Refresh", 10, 5, BtnRefreshOLS_Click);
            p.Controls.Add(btnRefreshOLS);

            var tbl = new System.Windows.Forms.TableLayoutPanel { Dock = System.Windows.Forms.DockStyle.Fill, RowCount = 3, ColumnCount = 2 };
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            var g1 = Grp("Policy"); dgvOLSPolicy = Dgv(); g1.Controls.Add(dgvOLSPolicy); tbl.Controls.Add(g1, 0, 0); tbl.SetColumnSpan(g1, 2);
            var g2 = Grp("Levels"); dgvOLSLevels = Dgv(); g2.Controls.Add(dgvOLSLevels); tbl.Controls.Add(g2, 0, 1);
            var g3 = Grp("Compartments"); dgvOLSCompartments = Dgv(); g3.Controls.Add(dgvOLSCompartments); tbl.Controls.Add(g3, 1, 1);
            var g4 = Grp("Labels"); dgvOLSLabels = Dgv(); g4.Controls.Add(dgvOLSLabels); tbl.Controls.Add(g4, 0, 2);
            var g5 = Grp("User Labels"); dgvOLSUserLabels = Dgv(); g5.Controls.Add(dgvOLSUserLabels); tbl.Controls.Add(g5, 1, 2);
            tab.Controls.AddRange(new System.Windows.Forms.Control[] { tbl, p });
        }

        private System.Windows.Forms.Label Lbl(string t, int x, int y) => new() { Text = t, Location = new System.Drawing.Point(x, y), AutoSize = true };
        private System.Windows.Forms.DataGridView Dgv() => new() { Dock = System.Windows.Forms.DockStyle.Fill, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, ReadOnly = true, AllowUserToAddRows = false, SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White, BorderStyle = System.Windows.Forms.BorderStyle.None, RowHeadersVisible = false };
        private System.Windows.Forms.GroupBox Grp(string t) => new() { Text = t, Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(5), Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
        private System.Windows.Forms.Button CreateBtn(string t, int x, int y, System.EventHandler h) { var b = new System.Windows.Forms.Button { Text = t, Location = new System.Drawing.Point(x, y), Size = new System.Drawing.Size(100, 30), BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White, FlatStyle = System.Windows.Forms.FlatStyle.Flat, Cursor = System.Windows.Forms.Cursors.Hand }; b.FlatAppearance.BorderSize = 0; b.Click += h; return b; }
    }
}
