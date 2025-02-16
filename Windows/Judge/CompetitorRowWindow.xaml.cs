using horsesProj.ModelV2;
using horsesProj.Util;
using System;
using System.Collections.Generic;
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

namespace horsesProj.Windows.Judge
{
    /// <summary>
    /// Логика взаимодействия для CompetitorRowWindow.xaml
    /// </summary>
    public partial class CompetitorRowWindow : Window
    {
        public CompetitorRowWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.Where(c => c.CompetJudgeId == CurrentUser.Judge.JudgeId).ToList();
        }

        private void compets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;
            rides.ItemsSource = DatabaseConnection.ContextV2.TbRides.Where(r => r.RideCompetition == competition.CompetId).ToList();
        }

        private void rides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbRide ride = rides.SelectedItem as TbRide;
            competitors.ItemsSource = DatabaseConnection.ContextV2.TbRideCompetitors.Where(r => r.RideId == ride.RideId).Select(r  => r.Competitor).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbCompetitor competitor = competitors.SelectedItem as TbCompetitor;
            competitor.CompetitorRow = int.Parse(row.Text);
            DatabaseConnection.ContextV2.Update(competitor);
            DatabaseConnection.ContextV2.SaveChanges();
        }
    }
}
