using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog3BPoe
{
    // Generic PriorityQueue class for managing items with associated priorities.
    // TItem: The type of items to store in the queue.
    // TPriority: The type of priorities assigned to items (must implement IComparable<TPriority> for sorting).
    public class PriorityQueue<TItem, TPriority> where TPriority : IComparable<TPriority>
    {
        // Internal storage using a SortedDictionary.
        // Key: Priority value.
        // Value: Queue of items sharing the same priority.
        private readonly SortedDictionary<TPriority, Queue<TItem>> storage = new SortedDictionary<TPriority, Queue<TItem>>();

        // Adds an item to the priority queue with the specified priority.
        public void Enqueue(TItem item, TPriority priority)
        {
            // Check if the priority already exists in the dictionary.
            // If not, initialize a new queue for this priority.
            if (!storage.ContainsKey(priority))
                storage[priority] = new Queue<TItem>();

            // Add the item to the queue associated with the given priority.
            storage[priority].Enqueue(item);
        }

        // Removes and returns the item with the highest priority (smallest priority value).
        public TItem Dequeue()
        {
            // Throw an exception if the queue is empty to prevent invalid operations.
            if (storage.Count == 0) throw new InvalidOperationException("The queue is empty.");

            // Retrieve the smallest key (highest priority) in the dictionary.
            var firstKey = storage.Keys.Min();

            // Retrieve the first item in the queue associated with this priority.
            var item = storage[firstKey].Dequeue();

            // If the queue for this priority is now empty, remove the key from the dictionary.
            if (storage[firstKey].Count == 0)
                storage.Remove(firstKey);

            // Return the dequeued item.
            return item;
        }

        // Checks if the priority queue is empty.
        public bool IsEmpty() => storage.Count == 0;
    }
}
