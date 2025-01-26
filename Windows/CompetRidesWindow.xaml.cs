using horsesProj.UIModel;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для CompetRidesWindow.xaml
    /// </summary>
    public partial class CompetRidesWindow : Window
    {
        public CompetRidesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var rqw = DatabaseConnection.context.TbCompetitionRides.Include(c => c.Ride).Include(c => c.Compet).ToList();

            var res = rqw.Select(c => new CompetRides
            {
                CompetDate = c.Compet.CompetDate,
                CompetName = c.Compet.CompetName,
                Rides = DatabaseConnection.context.TbCompetitionRides.Where(r => r.CompetId == c.CompetId).Include(r => r.Ride).Select(c => c.Ride).ToList(),
            }).Where(c => c.CompetDate > DateTime.Now).ToList();

            grid.ItemsSource = res;
        }
    }
}
