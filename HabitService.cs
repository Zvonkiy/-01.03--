// HabitService.cs
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace HabitTrackerMaui
{
    public static class HabitService
    {
        private static List<Habit> _habits = new List<Habit>();
        private static List<HabitCompletion> _completions = new List<HabitCompletion>();

        public static Task<List<Habit>> GetHabits()
        {
            return Task.FromResult(_habits.ToList()); // Return a copy to prevent direct modification
        }

        public static Task<Habit> GetHabit(int id)
        {
            return Task.FromResult(_habits.FirstOrDefault(h => h.Id == id));
        }

        public static Task SaveHabit(Habit habit)
        {
            if (habit.Id == 0 || !_habits.Any(h => h.Id == habit.Id)) //New Habit
            {
                habit.Id = Guid.NewGuid().GetHashCode(); //Generate unique ID
                _habits.Add(habit);
            }
            else
            {
                // Existing Habit, Update it (Find & Replace)
                var existingHabit = _habits.FirstOrDefault(h => h.Id == habit.Id);
                if (existingHabit != null)
                {
                    int index = _habits.IndexOf(existingHabit);
                    _habits[index] = habit;
                }
            }
            return Task.CompletedTask;
        }

        public static Task DeleteHabit(Habit habit)
        {
            _habits.RemoveAll(h => h.Id == habit.Id);
            _completions.RemoveAll(c => c.HabitId == habit.Id);
            return Task.CompletedTask;
        }

        public static Task<List<HabitCompletion>> GetCompletionsForHabit(int habitId)
        {
            return Task.FromResult(_completions.Where(c => c.HabitId == habitId).ToList());
        }

        public static Task SaveHabitCompletion(HabitCompletion completion)
        {
            _completions.Add(completion);
            return Task.CompletedTask;
        }

        public static Task ClearAllData()
        {
            _habits.Clear();
            _completions.Clear();
            return Task.CompletedTask;
        }
    }
}