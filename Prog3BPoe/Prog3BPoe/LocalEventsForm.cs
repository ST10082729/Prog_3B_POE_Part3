using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prog3BPoe
{
    public partial class LocalEventsForm : Form
    {
        private SortedDictionary<DateTime, List<Event>> eventsByDate = new SortedDictionary<DateTime, List<Event>>();
        private Stack<string> searchHistory = new Stack<string>();
        private HashSet<string> uniqueCategories = new HashSet<string>();

        public LocalEventsForm()
        {
            InitializeComponent();
            // using HashSet to add categories
            uniqueCategories.Add("Community");
            uniqueCategories.Add("Sports");
            uniqueCategories.Add("Cultural");
            uniqueCategories.Add("Education");
            uniqueCategories.Add("Health");

            // Populate ComboBox with categories
            cmbCategory.Items.AddRange(uniqueCategories.ToArray());

            LoadSampleEvents();

            DisplayUpcomingEvents();
        }

        private void LoadSampleEvents()
        {
            // Add events
            AddEvent("Community Clean-up", "Community", new DateTime(2024, 11, 15));
            AddEvent("Soccer Tournament", "Sports", new DateTime(2024, 11, 20));
            AddEvent("Art Exhibition", "Cultural", new DateTime(2024, 11, 25));
            AddEvent("Health Workshop", "Health", new DateTime(2024, 12, 5));
            AddEvent("Music Festival", "Cultural", new DateTime(2023, 10, 5));
            AddEvent("Book Fair", "Education", new DateTime(2024, 12, 10));
            AddEvent("Marathon for Charity", "Sports", new DateTime(2024, 12, 15));
            AddEvent("Local Business Expo", "Community", new DateTime(2025, 01, 10));
            AddEvent("Traditional Dance Festival", "Cultural", new DateTime(2025, 01, 20));
            AddEvent("First Aid Training", "Health", new DateTime(2025, 02, 01));
            AddEvent("Student Hackathon", "Education", new DateTime(2025, 02, 10));
            AddEvent("Annual Food Drive", "Community", new DateTime(2025, 02, 20));
            AddEvent("Regional Soccer Finals", "Sports", new DateTime(2025, 03, 05));
            AddEvent("Art and Sculpture Workshop", "Cultural", new DateTime(2025, 03, 10));
            AddEvent("Yoga for Beginners", "Health", new DateTime(2025, 03, 15));
        }

        private void AddEvent(string eventName, string category, DateTime eventDate)
        {
            DateTime eventOnlyDate = eventDate.Date;

            if (!eventsByDate.ContainsKey(eventOnlyDate))
            {
                eventsByDate[eventOnlyDate] = new List<Event>();
            }
            eventsByDate[eventOnlyDate].Add(new Event { EventName = eventName, Category = category, EventDate = eventOnlyDate });
        }

        // to display only the upcoming events
        private void DisplayUpcomingEvents()
        {
            lstEvents.Items.Clear();

            DateTime today = DateTime.Now.Date;

            // display only the upcoming events
            foreach (var eventPair in eventsByDate)
            {
                DateTime eventDate = eventPair.Key;

                // Check the event date
                if (eventDate >= today)
                {
                    foreach (var eventItem in eventPair.Value)
                    {
                        var listViewItem = new ListViewItem(new[]
                        {
                            eventItem.EventName,
                            eventItem.Category,
                            eventItem.EventDate.ToShortDateString()
                        });
                        lstEvents.Items.Add(listViewItem);
                    }
                }
            }

            if (lstEvents.Items.Count == 0)
            {
                MessageBox.Show("No upcoming events.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();

            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            DateTime selectedDate = dtpEventDate.Value.Date;

            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Please select a category to search for.");
                return;
            }

            searchHistory.Push($"{selectedCategory} on {selectedDate.ToShortDateString()}");

            foreach (var eventPair in eventsByDate)
            {
                DateTime eventDate = eventPair.Key.Date; 

                if (eventDate == selectedDate)  
                {
                    foreach (var eventItem in eventPair.Value)
                    {
                        if (eventItem.Category.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase))
                        {
                            var listViewItem = new ListViewItem(new[]
                            {
                                eventItem.EventName,
                                eventItem.Category,
                                eventItem.EventDate.ToShortDateString()
                            });
                            lstEvents.Items.Add(listViewItem);
                        }
                    }
                }
            }

            if (lstEvents.Items.Count == 0)
            {
                MessageBox.Show("No events found for the selected category and date.");
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (searchHistory.Count == 0)
            {
                MessageBox.Show("No recent searches.");
                return;
            }

            string history = string.Join(Environment.NewLine, searchHistory.ToArray());
            MessageBox.Show($"Search History:\n{history}");
        }

        private void btnRecommendations_Click(object sender, EventArgs e)
        {
            RecommendEvents();
        }

        private void RecommendEvents()
        {
            if (searchHistory.Count == 0)
            {
                MessageBox.Show("No recent searches to base recommendations on.");
                return;
            }

            Dictionary<string, int> categoryCount = new Dictionary<string, int>();

            foreach (var search in searchHistory)
            {
                string category = search.Split(' ')[0];  // Extract category from search

                if (categoryCount.ContainsKey(category))
                {
                    categoryCount[category]++;
                }
                else
                {
                    categoryCount[category] = 1;
                }
            }

            // Find the most searched category
            string mostSearchedCategory = categoryCount.OrderByDescending(c => c.Value).FirstOrDefault().Key;

            // Recommend future events in the most searched category
            lstEvents.Items.Clear();
            foreach (var eventPair in eventsByDate)
            {
                foreach (var eventItem in eventPair.Value)
                {
                    if (eventItem.Category.Equals(mostSearchedCategory, StringComparison.OrdinalIgnoreCase))
                    {
                        var listViewItem = new ListViewItem(new[]
                        {
                            eventItem.EventName,
                            eventItem.Category,
                            eventItem.EventDate.ToShortDateString()
                        });
                        lstEvents.Items.Add(listViewItem);
                    }
                }
            }

            MessageBox.Show($"Recommendations based on your searches for category: {mostSearchedCategory}");
        }
    }

    // Event class to store event details
    public class Event
    {
        public string EventName { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
    }
}
