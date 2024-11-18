namespace Prog3BPoe
{
    partial class ServiceRequestDisplayControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRequestID;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbStatus;

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
            this.lblRequestID = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // lblRequestID
            this.lblRequestID.AutoSize = true;
            this.lblRequestID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRequestID.Location = new System.Drawing.Point(10, 10);
            this.lblRequestID.Name = "lblRequestID";
            this.lblRequestID.Size = new System.Drawing.Size(77, 16);

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocation.Location = new System.Drawing.Point(10, 40);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(61, 16);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategory.Location = new System.Drawing.Point(10, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 16);

            // cmbStatus
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Location = new System.Drawing.Point(10, 100);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 24);

            // ServiceRequestDisplayControl
            this.Controls.Add(this.lblRequestID);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbStatus);
            this.Name = "ServiceRequestDisplayControl";
            this.Size = new System.Drawing.Size(300, 150);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
