// App.xaml.cs
using Microsoft.Maui.Controls;
using System;

namespace HabitTrackerMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}