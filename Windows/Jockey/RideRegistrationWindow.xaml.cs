using horsesProj.ModelV2;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace horsesProj.Windows.Jockey
{
    /// <summary>
    /// Логика взаимодействия для RideRegistrationWindow.xaml
    /// </summary>
    public partial class RideRegistrationWindow : Window
    {
        ObservableCollection<TbRide> ridesTo = new ObservableCollection<TbRide>();

        public RideRegistrationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.ToList();
            horses.ItemsSource = DatabaseConnection.ContextV2.TbHorses.ToList();
        }

        // add ride
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbRide ride = rides.SelectedItem as TbRide;
            ridesTo.Add(ride);
            rides.ItemsSource = ridesTo;
        }

        // ok
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TbHorse horse = horses.SelectedItem as TbHorse;
            var years = DateTime.Now.Year - horse.HorseBirthYear;
            
            if (years < 2) return;

            var count = DatabaseConnection.ContextV2.TbRideCompetitors.Include(r => r.Competitor).Include(r => r.Ride).Include(r => r.Ride.RideCompetitionNavigation)
                .Where(r => r.Competitor.CompetitorHorseId == horse.HorseId).Where(r => r.Ride.RideCompetitionNavigation.CompetDate >= DateTime.Now.AddMonths(-1)).Count();

            switch (years)
            {
                case 2:
                    if (count > 3) return; break;
                case 3:
                    if (count > 4) return; break;
                default:
                    if (count > 5) return; break;
            }

            var competitor = DatabaseConnection.ContextV2.TbCompetitors.Add(new TbCompetitor
            {
                CompetitorJockeyId = CurrentUser.Jokey.JokeyId,
                CompetitorHorseId = horse.HorseId
            });
            DatabaseConnection.ContextV2.SaveChanges();
            foreach (var ride in ridesTo)
            {
                DatabaseConnection.ContextV2.TbRideCompetitors.Add(new TbRideCompetitor
                {
                    CompetitorId = competitor.Entity.CompetitorId,
                    JockeyColor = color.Text,
                    RideId = ride.RideId
                });
            }
            DatabaseConnection.ContextV2.SaveChanges();
        }

        private void compets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;
            rides.ItemsSource = DatabaseConnection.ContextV2.TbRides.Where(r => r.RideCompetition == competition.CompetId).ToList();
        }
    }
}
