using horsesProj.Dialog;
using horsesProj.ModelV2;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace horsesProj.Windows.Judge
{
    /// <summary>
    /// Логика взаимодействия для InsertResultWindow.xaml
    /// </summary>
    public partial class InsertResultWindow : Window
    {
        public InsertResultWindow()
        {
            InitializeComponent();
        }

        private void rides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbRide ride = rides.SelectedItem as TbRide;
            grid.ItemsSource = DatabaseConnection.ContextV2.TbRideCompetitors.Where(r => r.RideId == ride.RideId).Include(r => r.Ride).Include(r => r.Competitor).Include(r => r.Competitor.CompetitorJockey).Include(r => r.Competitor.CompetitorHorse).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.Where(c => c.CompetJudgeId == CurrentUser.Judge.JudgeId).ToList();
        }

        private void compets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbCompetition comp = compets.SelectedItem as TbCompetition;
            rides.ItemsSource = DatabaseConnection.ContextV2.TbRides.Where(c => c.RideCompetition == comp.CompetId).ToList();
        }

        // Insert comp
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbRide tbRide = rides.SelectedItem as TbRide;
            AddCompetitorDialog addCompetitorDialog = new(tbRide.RideId);
            addCompetitorDialog.ShowDialog();
        }

        // Upd comp
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TbRideCompetitor tbRideCompetitor = grid.SelectedItem as TbRideCompetitor;
            AddCompetitorDialog addCompetitorDialog1 = new(tbRideCompetitor);
            addCompetitorDialog1.ShowDialog();
        }
    }
}
