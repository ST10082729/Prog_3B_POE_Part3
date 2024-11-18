using System;
using System.Windows.Forms;

namespace Prog3BPoe
{
    // A custom UserControl to display and manage individual service requests.
    public partial class ServiceRequestDisplayControl : UserControl
    {
        // Event triggered when the status of the service request changes.
        public event EventHandler<string> StatusChanged;

        // Property to display and set the Request ID.
        public string RequestID
        {
            get => lblRequestID.Text; // Retrieves the current text displayed in the label.
            set => lblRequestID.Text = $"Request ID: {value}"; // Sets the label text with the provided value.
        }

        // Property to display and set the location of the service request.
        public string RequestLocation
        {
            get => lblLocation.Text; // Retrieves the current location text.
            set => lblLocation.Text = $"Location: {value}"; // Sets the label text to show the location.
        }

        // Property to display and set the status of the service request.
        public string Status
        {
            get => cmbStatus.SelectedItem?.ToString(); // Retrieves the currently selected status.
            set => cmbStatus.SelectedItem = value; // Sets the selected status in the combo box.
        }

        // Property to display and set the category of the service request.
        public string Category
        {
            get => lblCategory.Text; // Retrieves the current category text.
            set => lblCategory.Text = $"Category: {value}"; // Sets the label text to show the category.
        }

        // Constructor for the ServiceRequestDisplayControl.
        public ServiceRequestDisplayControl()
        {
            InitializeComponent(); // Initializes the UI components defined in the designer file.

            // Adds predefined status options to the combo box.
            cmbStatus.Items.AddRange(new[] { "Pending", "In Progress", "Completed" });

            // Event handler for when the selected status changes.
            cmbStatus.SelectedIndexChanged += (s, e) =>
            {
                // Triggers the StatusChanged event and passes the new status.
                StatusChanged?.Invoke(this, cmbStatus.SelectedItem?.ToString());
            };
        }
    }
}
