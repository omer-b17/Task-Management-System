using System;

namespace TaskManagementSystem
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int ExpectedDuration { get; set; } // in hours
        public int ActualDuration { get; set; } // in hours
        public int Priority { get; set; } // 1 (highest) to 5 (lowest)

        public Task(string title, string description, int expectedDuration, int priority)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
            ExpectedDuration = expectedDuration;
            ActualDuration = 0;
            Priority = priority;
        }

        public void Info()
        {
            Console.WriteLine($"Title: {Title}\nDescription: {Description}\nPriority: {Priority}\nExpected Duration: {ExpectedDuration} hours");
        }
    }
}