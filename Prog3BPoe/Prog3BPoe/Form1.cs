using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3BPoe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Open the Report issue Page
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.ShowDialog();
        }

        //Open the Local Evnts Page
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm();
            eventsForm.ShowDialog();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Enable only the Report Issues and Local Events button
            btnReportIssues.Enabled = true;
            btnLocalEvents.Enabled = true;
            btnServiceStatus.Enabled = true;

            // Adding some dummy data to RequestManager
            Program.RequestManager.AddRequest(new ServiceRequest
            {
                RequestID = "1",
                Location = "Test Location 1",
                Category = "Roads",
                Description = "Pothole repair needed",
                Status = "Pending",
                SubmissionDate = DateTime.Now
            });

            Program.RequestManager.AddRequest(new ServiceRequest
            {
                RequestID = "2",
                Location = "Test Location 2",
                Category = "Water Supply",
                Description = "Leaking pipe",
                Status = "In Progress",
                SubmissionDate = DateTime.Now
            });

            Program.RequestManager.AddRequest(new ServiceRequest
            {
                RequestID = "3",
                Location = "Test Location 3",
                Category = "Sanitation",
                Description = "Garbage pickup required",
                Status = "Pending",
                SubmissionDate = DateTime.Now
            });

            // Adding dependencies between requests for demo purposes
            Program.RequestManager.AddDependency("1", "2");
            Program.RequestManager.AddDependency("2", "3");

            Console.WriteLine("Dummy data and dependencies added.");
        }

        //Open the Service Requests Page
        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm = new ServiceRequestStatusForm(Program.RequestManager);
            statusForm.ShowDialog();
        }
    }
}
