﻿using horsesProj.ModelV2;
using horsesProj.UIModel;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для JokeysWindow.xaml
    /// </summary>
    public partial class JokeysWindow : Window
    {
        public JokeysWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.ToList();
        }

        private void compets_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;
            rides.ItemsSource = DatabaseConnection.ContextV2.TbRides.Where(r => r.RideCompetition == competition.CompetId).ToList();
        }

        private void rides_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TbRide ride = rides.SelectedItem as TbRide;
            grid.ItemsSource = DatabaseConnection.ContextV2.TbRideCompetitors.Include(r => r.Competitor).Include(c => c.Competitor.CompetitorHorse).Include(c => c.Competitor.CompetitorJockey).Where(r => r.RideId == ride.RideId).Include(r => r.Competitor.CompetitorHorse.HorseGender).Include(r => r.Competitor.CompetitorHorse.HorseBreed).Select(r => new Competitior
            {
                Jokey = r.Competitor.CompetitorJockey,
                Horse = r.Competitor.CompetitorHorse,
            }).ToList();
        }
    }
}
