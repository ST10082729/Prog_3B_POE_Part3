using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Prog3BPoe
{
    public partial class ReportIssuesForm : Form
    {
        //public class Issue
        //{
            //public string Location { get; set; }
            //public string Category { get; set; }
            //public string Description { get; set; }
            public string AttachedFile { get; set; }
        //}

        private string attachedFilePath;
        //private List<Issue> issues = new List<Issue>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Sanitation", "Roads", "Utilities", "Water Supply", "Electricity" });
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text;
            string category = comboBox1.SelectedItem?.ToString();
            string description = rtbDescription.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(location) || location.Length < 5)
            {
                MessageBox.Show("Please enter a valid location (at least 5 characters).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(description) || description.Length < 10)
            {
                MessageBox.Show("Please provide a description (at least 10 characters).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new request
            var request = new ServiceRequest
            {
                RequestID = Guid.NewGuid().ToString(),
                Location = location,
                Category = category,
                Description = description,
                Status = "Pending",
                SubmissionDate = DateTime.Now
            };

            // Debugging log
            Console.WriteLine($"Creating Request: ID={request.RequestID}, Location={request.Location}, Category={request.Category}, Description={request.Description}, Status={request.Status}");

            // Add request to ServiceRequestManager
            Program.RequestManager.AddRequest(request);
            Console.WriteLine($"Request Submitted: {request.RequestID}");

            // Notify success
            MessageBox.Show("Service request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear fields
            txtLocation.Clear();
            comboBox1.SelectedIndex = -1;
            rtbDescription.Clear();

            // Refresh ServiceRequestStatusForm if it's open
            foreach (Form form in Application.OpenForms)
            {
                if (form is ServiceRequestStatusForm statusForm)
                {
                    Console.WriteLine("Refreshing ServiceRequestStatusForm...");
                    statusForm.RefreshRequests();
                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            // Confirmation message
            var result = MessageBox.Show("Are you sure you want to go back? Unsaved data will be lost.",
                                         "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            // Open file dialog to select a media file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = openFileDialog.FileName;
                // Show only the file name
                lblMediaStatus.Text = "Attached file: " + Path.GetFileName(attachedFilePath);
            }
        }
    }
}

