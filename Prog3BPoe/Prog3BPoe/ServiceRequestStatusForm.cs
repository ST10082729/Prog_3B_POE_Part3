using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Prog3BPoe
{
    public partial class ServiceRequestStatusForm : Form
    {
        private ServiceRequestManager serviceRequestManager;

        public ServiceRequestStatusForm(ServiceRequestManager manager)
        {
            InitializeComponent();
            this.serviceRequestManager = manager;
            PopulateServiceRequests();
        }

        // Populates the service request panel with individual service request controls
        private void PopulateServiceRequests()
        {
            Console.WriteLine("Populating service requests...");
            var serviceRequests = serviceRequestManager.GetAllRequests();
            Console.WriteLine($"Found {serviceRequests.Count} service requests.");

            requestPanel.Controls.Clear();
            int yOffset = 10;

            foreach (var request in serviceRequests)
            {
                Console.WriteLine($"Creating control for Request ID: {request.RequestID}");
                var requestControl = CreateServiceRequestControl(request);
                AddRequestControlToPanel(requestControl, ref yOffset);
            }
        }

        // Creates a user control for a specific service request
        private ServiceRequestDisplayControl CreateServiceRequestControl(ServiceRequest request)
        {
            var requestControl = new ServiceRequestDisplayControl
            {
                RequestID = request.RequestID,
                RequestLocation = request.Location,
                Status = request.Status,
                Category = request.Category
            };

            requestControl.StatusChanged += (sender, newStatus) =>
            {
                UpdateServiceRequestStatus(request, newStatus);
            };

            SetRequestControlBackgroundColor(requestControl, request.Status);

            return requestControl;
        }

        // Adds a request control to the panel and updates the yOffset
        private void AddRequestControlToPanel(ServiceRequestDisplayControl requestControl, ref int yOffset)
        {
            requestControl.Location = new Point(10, yOffset);
            requestPanel.Controls.Add(requestControl);
            yOffset += requestControl.Height + 10;
        }

        // Updates the status of a service request
        private void UpdateServiceRequestStatus(ServiceRequest request, string newStatus)
        {
            request.Status = newStatus;
            MessageBox.Show($"Status updated to {newStatus} for Request ID: {request.RequestID}");
        }

        // Sets the background color of the request control based on its status
        private void SetRequestControlBackgroundColor(ServiceRequestDisplayControl requestControl, string status)
        {
            switch (status)
            {
                case "Completed":
                    requestControl.BackColor = Color.LightGreen;
                    break;
                case "In Progress":
                    requestControl.BackColor = Color.LightYellow;
                    break;
                default:
                    requestControl.BackColor = Color.LightCoral;
                    break;
            }
        }

        // Refresh the service request panel to reflect any updates
        public void RefreshRequests()
        {
            PopulateServiceRequests();
        }

        // Button click event to view dependencies of a specific service request
        private void btnViewDependencies_Click(object sender, EventArgs e)
        {
            string requestId = txtRequestId.Text;
            if (string.IsNullOrEmpty(requestId))
            {
                ShowErrorMessage("Please enter a valid Request ID to view dependencies.");
                return;
            }

            DisplayDependencies(requestId);
        }

        // Displays the dependencies of a specific service request
        private void DisplayDependencies(string requestId)
        {
            var dependencies = serviceRequestManager.GetDependencies(requestId);
            if (dependencies == null || dependencies.Count == 0)
            {
                ShowInfoMessage($"No dependencies found for Request ID: {requestId}");
            }
            else
            {
                string dependenciesList = string.Join(", ", dependencies);
                ShowInfoMessage($"Dependencies for Request ID {requestId}: {dependenciesList}");
            }
        }

        // Button click event to generate the Minimum Spanning Tree (MST) of service requests
        private void btnGenerateMST_Click(object sender, EventArgs e)
        {
            var mstEdges = serviceRequestManager.GenerateMST();
            if (mstEdges == null || mstEdges.Count == 0)
            {
                ShowInfoMessage("No dependencies to form an MST.");
            }
            else
            {
                string mstResult = string.Join("\n", mstEdges.Select(edge => $"{edge.Item1} - {edge.Item2}"));
                ShowInfoMessage($"Minimum Spanning Tree:\n{mstResult}");
            }
        }

        // Shows an error message in a message box
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Shows an informational message in a message box
        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
