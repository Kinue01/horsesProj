using horsesProj.Model;
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
            compets.ItemsSource = DatabaseConnection.context.TbCompetitions.ToList();
        }

        private void compets_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;
            rides.ItemsSource = DatabaseConnection.context.TbCompetitionRides.Include(c => c.Ride).Where(r => r.CompetId == competition.CompetId).Select(r => r.Ride).ToList();
        }

        private void rides_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TbRide ride = rides.SelectedItem as TbRide;
            grid.ItemsSource = DatabaseConnection.context.TbRideCompetitors.Where(r => r.RideId == ride.RideId).Select(r => new Competitior
            {
                Jokey = r.Jokey,
                Horse = r.Horse,
            }).Include(r => r.Horse.HorseGender).Include(r => r.Horse.HorseBreed).ToArray();
        }
    }
}
