﻿using System.Windows;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для FanWindow.xaml
    /// </summary>
    public partial class FanWindow : Window
    {
        public FanWindow()
        {
            InitializeComponent();
        }

        // back
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // rides and compets
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CompetRidesWindow competRidesWindow = new();
            competRidesWindow.ShowDialog();
        }

        // jokeys
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JokeysWindow jokeysWindow = new();
            jokeysWindow.ShowDialog();
        }

        // stats
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RideResultsWindow roideResultsWindow = new();
            roideResultsWindow.ShowDialog();
        }

        // pay
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            HorseDonateWindow horseDonateWindow = new();
            horseDonateWindow.ShowDialog();
        }
    }
}
