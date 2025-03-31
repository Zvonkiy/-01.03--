// Habit.cs
using System;

namespace HabitTrackerMaui
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; } // "Daily", "Weekly", "SpecificDays"
        public string SpecificDays { get; set; } // Comma-separated days for "SpecificDays" frequency
        public TimeSpan? ReminderTime { get; set; }
        public bool IsReminderEnabled { get; set; }

        public Habit()
        {
            // Generate a unique ID for each habit
            Id = Guid.NewGuid().GetHashCode();
        }
    }
}