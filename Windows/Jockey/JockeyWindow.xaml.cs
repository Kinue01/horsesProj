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

namespace horsesProj.Windows.Jockey
{
    /// <summary>
    /// Логика взаимодействия для JockeyWindow.xaml
    /// </summary>
    public partial class JockeyWindow : Window
    {
        public JockeyWindow()
        {
            InitializeComponent();
        }

        // exit
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // jockey info redo
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            JockeyInfoWindow infoWindow = new();
            infoWindow.ShowDialog();
        }

        // horses info redo
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JockeyHorsesWindow jockeyHorsesWindow = new();
            jockeyHorsesWindow.ShowDialog();
        }

        // ride reg
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RideRegistrationWindow roideRegistrationWindow = new();
            roideRegistrationWindow.ShowDialog();
        }

        // ride competitors
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            JokeysWindow jokeysWindow = new();
            jokeysWindow.ShowDialog();
        }

        // ride res
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RideResultsWindow rideResultsWindow = new();
            rideResultsWindow.ShowDialog();
        }
    }
}
