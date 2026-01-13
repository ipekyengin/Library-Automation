namespace LibraryAutomation
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnMostBorrowed = new System.Windows.Forms.Button();
            this.btnOverdue = new System.Windows.Forms.Button();
            this.btnActiveMembers = new System.Windows.Forms.Button();
            this.btnCategoryReport = new System.Windows.Forms.Button();
            this.btnMonthlyStats = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(306, 51);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(5);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(1063, 618);
            this.dgvReport.TabIndex = 0;
            // 
            // btnMostBorrowed
            // 
            this.btnMostBorrowed.BackColor = System.Drawing.Color.Silver;
            this.btnMostBorrowed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostBorrowed.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMostBorrowed.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnMostBorrowed.Location = new System.Drawing.Point(45, 51);
            this.btnMostBorrowed.Margin = new System.Windows.Forms.Padding(5);
            this.btnMostBorrowed.Name = "btnMostBorrowed";
            this.btnMostBorrowed.Size = new System.Drawing.Size(220, 49);
            this.btnMostBorrowed.TabIndex = 1;
            this.btnMostBorrowed.Text = "Most Borrowed";
            this.btnMostBorrowed.UseVisualStyleBackColor = false;
            this.btnMostBorrowed.Click += new System.EventHandler(this.btnMostBorrowed_Click);
            // 
            // btnOverdue
            // 
            this.btnOverdue.BackColor = System.Drawing.Color.Silver;
            this.btnOverdue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverdue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOverdue.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnOverdue.Location = new System.Drawing.Point(45, 130);
            this.btnOverdue.Margin = new System.Windows.Forms.Padding(5);
            this.btnOverdue.Name = "btnOverdue";
            this.btnOverdue.Size = new System.Drawing.Size(220, 49);
            this.btnOverdue.TabIndex = 2;
            this.btnOverdue.Text = "Overdue";
            this.btnOverdue.UseVisualStyleBackColor = false;
            this.btnOverdue.Click += new System.EventHandler(this.btnOverdue_Click);
            // 
            // btnActiveMembers
            // 
            this.btnActiveMembers.BackColor = System.Drawing.Color.Silver;
            this.btnActiveMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiveMembers.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnActiveMembers.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnActiveMembers.Location = new System.Drawing.Point(45, 207);
            this.btnActiveMembers.Margin = new System.Windows.Forms.Padding(5);
            this.btnActiveMembers.Name = "btnActiveMembers";
            this.btnActiveMembers.Size = new System.Drawing.Size(220, 49);
            this.btnActiveMembers.TabIndex = 3;
            this.btnActiveMembers.Text = "Active Members";
            this.btnActiveMembers.UseVisualStyleBackColor = false;
            this.btnActiveMembers.Click += new System.EventHandler(this.btnActiveMembers_Click);
            // 
            // btnCategoryReport
            // 
            this.btnCategoryReport.BackColor = System.Drawing.Color.Silver;
            this.btnCategoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryReport.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCategoryReport.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCategoryReport.Location = new System.Drawing.Point(45, 287);
            this.btnCategoryReport.Margin = new System.Windows.Forms.Padding(5);
            this.btnCategoryReport.Name = "btnCategoryReport";
            this.btnCategoryReport.Size = new System.Drawing.Size(220, 49);
            this.btnCategoryReport.TabIndex = 4;
            this.btnCategoryReport.Text = "Category Report";
            this.btnCategoryReport.UseVisualStyleBackColor = false;
            this.btnCategoryReport.Click += new System.EventHandler(this.btnCategoryReport_Click);
            // 
            // btnMonthlyStats
            // 
            this.btnMonthlyStats.BackColor = System.Drawing.Color.Silver;
            this.btnMonthlyStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonthlyStats.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMonthlyStats.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnMonthlyStats.Location = new System.Drawing.Point(45, 370);
            this.btnMonthlyStats.Margin = new System.Windows.Forms.Padding(5);
            this.btnMonthlyStats.Name = "btnMonthlyStats";
            this.btnMonthlyStats.Size = new System.Drawing.Size(220, 49);
            this.btnMonthlyStats.TabIndex = 5;
            this.btnMonthlyStats.Text = "Monthly Stats";
            this.btnMonthlyStats.UseVisualStyleBackColor = false;
            this.btnMonthlyStats.Click += new System.EventHandler(this.btnMonthlyStats_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Silver;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnBack.Location = new System.Drawing.Point(45, 447);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(220, 51);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryAutomation.Properties.Resources.Library;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1400, 703);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMonthlyStats);
            this.Controls.Add(this.btnCategoryReport);
            this.Controls.Add(this.btnActiveMembers);
            this.Controls.Add(this.btnOverdue);
            this.Controls.Add(this.btnMostBorrowed);
            this.Controls.Add(this.dgvReport);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnMostBorrowed;
        private System.Windows.Forms.Button btnOverdue;
        private System.Windows.Forms.Button btnActiveMembers;
        private System.Windows.Forms.Button btnCategoryReport;
        private System.Windows.Forms.Button btnMonthlyStats;
        private System.Windows.Forms.Button btnBack;
    }
}