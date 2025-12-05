using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    partial class ViewClassesForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewClasses;
        private Panel panelTop;
        private Label lblTitle;
        private Button btnRefresh;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewClasses = new DataGridView();
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // dataGridViewClasses
            // 
            this.dataGridViewClasses.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewClasses.BorderStyle = BorderStyle.None;
            this.dataGridViewClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasses.Location = new System.Drawing.Point(20, 80);
            this.dataGridViewClasses.Name = "dataGridViewClasses";
            this.dataGridViewClasses.RowHeadersWidth = 51;
            this.dataGridViewClasses.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewClasses.TabIndex = 0;
            this.dataGridViewClasses.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dataGridViewClasses.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.dataGridViewClasses.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewClasses.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.dataGridViewClasses.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewClasses.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh Sách Lớp";

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(580, 500);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(690, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // ViewClassesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dataGridViewClasses);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewClassesForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Xem Danh Sách Lớp";
            this.Load += new System.EventHandler(this.ViewClassesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}