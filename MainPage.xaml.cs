// MainPage.xaml.cs
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HabitTrackerMaui
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Habit> Habits { get; set; } = new ObservableCollection<Habit>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadHabits();
        }

        private async Task LoadHabits()
        {
            Habits.Clear();
            var habits = await HabitService.GetHabits();
            foreach (var habit in habits)
            {
                Habits.Add(habit);
            }
        }

        private async void AddHabitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HabitDetailPage());
        }

        private async void Habit_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Habit selectedHabit)
            {
                await Navigation.PushAsync(new HabitDetailPage(selectedHabit));
                HabitList.SelectedItem = null; // Deselect the item
            }
        }

        private async void DeleteHabit_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var habit = (Habit)button.CommandParameter;

            bool result = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {habit.Name}?", "Yes", "No");
            if (result)
            {
                await HabitService.DeleteHabit(habit);
                await LoadHabits();
            }
        }

        private async void ClearDataButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirm Clear", $"Are you sure you want to delete ALL data?", "Yes", "No");
            if (result)
            {
                await HabitService.ClearAllData();
                await LoadHabits();
            }

        }
    }
}