using horsesProj.ModelV2;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для RideResultsWindow.xaml
    /// </summary>
    public partial class RideResultsWindow : Window
    {
        public RideResultsWindow()
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
            grid.ItemsSource = DatabaseConnection.ContextV2.TbRideCompetitors.Where(r => r.RideId == ride.RideId).Include(r => r.Ride).Include(r => r.Competitor).Include(r => r.Competitor.CompetitorJockey).Include(c => c.Competitor.CompetitorHorse).ToList();
        }
    }
}
