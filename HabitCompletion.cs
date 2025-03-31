// HabitCompletion.cs
using System;

namespace HabitTrackerMaui
{
    public class HabitCompletion
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public DateTime CompletionDate { get; set; }

        public HabitCompletion()
        {
            // Generate a unique ID for each habit completion
            Id = Guid.NewGuid().GetHashCode();
        }
    }
}