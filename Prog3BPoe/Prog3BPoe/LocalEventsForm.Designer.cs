namespace Prog3BPoe
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader columnEventName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnRecommendations;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;

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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.columnEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRecommendations = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Navy;
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(650, 60);
            this.headerPanel.TabIndex = 12;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(15, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(398, 32);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Local Events and Announcements";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.lstEvents);
            this.contentPanel.Controls.Add(this.btnRecommendations);
            this.contentPanel.Controls.Add(this.btnViewHistory);
            this.contentPanel.Controls.Add(this.dtpEventDate);
            this.contentPanel.Controls.Add(this.cmbCategory);
            this.contentPanel.Controls.Add(this.btnSearch);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 60);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(650, 408);
            this.contentPanel.TabIndex = 13;
            // 
            // lstEvents
            // 
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEventName,
            this.columnCategory,
            this.columnDate});
            this.lstEvents.HideSelection = false;
            this.lstEvents.Location = new System.Drawing.Point(20, 100);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(600, 250);
            this.lstEvents.TabIndex = 0;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            // 
            // columnEventName
            // 
            this.columnEventName.Text = "Event Name";
            this.columnEventName.Width = 200;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 150;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Event Date";
            this.columnDate.Width = 100;
            // 
            // btnRecommendations
            // 
            this.btnRecommendations.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecommendations.ForeColor = System.Drawing.Color.White;
            this.btnRecommendations.Location = new System.Drawing.Point(373, 370);
            this.btnRecommendations.Name = "btnRecommendations";
            this.btnRecommendations.Size = new System.Drawing.Size(200, 35);
            this.btnRecommendations.TabIndex = 5;
            this.btnRecommendations.Text = "View Recommendations";
            this.btnRecommendations.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecommendations.UseVisualStyleBackColor = false;
            this.btnRecommendations.Click += new System.EventHandler(this.btnRecommendations_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.Location = new System.Drawing.Point(64, 370);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(200, 35);
            this.btnViewHistory.TabIndex = 4;
            this.btnViewHistory.Text = "View History";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Location = new System.Drawing.Point(240, 25);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEventDate.TabIndex = 3;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(20, 25);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 24);
            this.cmbCategory.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(470, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // LocalEventsForm
            // 
            this.ClientSize = new System.Drawing.Size(650, 468);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.IsMdiContainer = true;
            this.Name = "LocalEventsForm";
            this.Text = "Local Events and Announcements";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
