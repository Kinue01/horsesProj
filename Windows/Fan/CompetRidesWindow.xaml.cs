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
            var list = DatabaseConnection.ContextV2.TbCompetitions.Include(c => c.TbRides).ToList();
            grid.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.Include(c => c.TbRides).Select(c => new CompetRides
            {
                CompetDate = c.CompetDate,
                CompetName = c.CompetName,
                Rides = c.TbRides.ToList(),
            }).ToList();
            
        }
    }
}
