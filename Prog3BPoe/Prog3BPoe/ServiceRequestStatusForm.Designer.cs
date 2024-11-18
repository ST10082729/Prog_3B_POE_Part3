namespace Prog3BPoe
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel requestPanel;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.Button btnViewDependencies;
        private System.Windows.Forms.Button btnGenerateMST;

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
            this.requestPanel = new System.Windows.Forms.Panel();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.btnViewDependencies = new System.Windows.Forms.Button();
            this.btnGenerateMST = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // requestPanel
            this.requestPanel.AutoScroll = true;
            this.requestPanel.Location = new System.Drawing.Point(10, 50);
            this.requestPanel.Name = "requestPanel";
            this.requestPanel.Size = new System.Drawing.Size(780, 500);
            this.requestPanel.TabIndex = 0;

            // txtRequestId
            this.txtRequestId.Location = new System.Drawing.Point(10, 10);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size(200, 22);
            this.txtRequestId.TabIndex = 1;

            // btnViewDependencies
            this.btnViewDependencies.Location = new System.Drawing.Point(220, 10);
            this.btnViewDependencies.Name = "btnViewDependencies";
            this.btnViewDependencies.Size = new System.Drawing.Size(150, 30);
            this.btnViewDependencies.TabIndex = 2;
            this.btnViewDependencies.Text = "View Dependencies";
            this.btnViewDependencies.UseVisualStyleBackColor = true;
            this.btnViewDependencies.Click += new System.EventHandler(this.btnViewDependencies_Click);

            // btnGenerateMST
            this.btnGenerateMST.Location = new System.Drawing.Point(380, 10);
            this.btnGenerateMST.Name = "btnGenerateMST";
            this.btnGenerateMST.Size = new System.Drawing.Size(150, 30);
            this.btnGenerateMST.TabIndex = 3;
            this.btnGenerateMST.Text = "Generate MST";
            this.btnGenerateMST.UseVisualStyleBackColor = true;
            this.btnGenerateMST.Click += new System.EventHandler(this.btnGenerateMST_Click);

            // ServiceRequestStatusForm
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnGenerateMST);
            this.Controls.Add(this.btnViewDependencies);
            this.Controls.Add(this.txtRequestId);
            this.Controls.Add(this.requestPanel);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "Service Request Status";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}