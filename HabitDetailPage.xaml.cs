// HabitDetailPage.xaml.cs
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HabitTrackerMaui
{
    public partial class HabitDetailPage : ContentPage
    {
        private Habit _habit;

        public HabitDetailPage()
        {
            InitializeComponent();
            _habit = new Habit();
            BindingContext = _habit;
        }

        public HabitDetailPage(Habit habit)
        {
            InitializeComponent();
            _habit = habit;
            BindingContext = _habit;

            // Pre-populate fields for editing
            NameEntry.Text = _habit.Name;
            FrequencyPicker.SelectedItem = _habit.Frequency;
            if (_habit.ReminderTime.HasValue)
            {
                ReminderTimePicker.Time = _habit.ReminderTime.Value;
                ReminderSwitch.IsToggled = _habit.IsReminderEnabled;
            }
        }


        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            _habit.Name = NameEntry.Text;
            _habit.Frequency = FrequencyPicker.SelectedItem?.ToString() ?? "Daily"; // Default to Daily
            _habit.ReminderTime = ReminderSwitch.IsToggled ? ReminderTimePicker.Time : null;
            _habit.IsReminderEnabled = ReminderSwitch.IsToggled;


            await HabitService.SaveHabit(_habit);
            await Navigation.PopAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}