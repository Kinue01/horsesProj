using horsesProj.Util;
using Microsoft.Win32;
using System.Windows;

namespace horsesProj.Windows.Judge
{
    /// <summary>
    /// Логика взаимодействия для JudgeWindow.xaml
    /// </summary>
    public partial class JudgeWindow : Window
    {
        public JudgeWindow()
        {
            InitializeComponent();
        }

        // rows
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitorRowWindow rowWindow = new();
            rowWindow.ShowDialog();
        }

        // competitors
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            JokeysWindow jokeysWindow = new();
            jokeysWindow.ShowDialog();
        }

        // insert results
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InsertResultWindow insertResultWindow = new();
            insertResultWindow.ShowDialog();
        }

        // fails
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CompetitorFailsWindow competitorFailsWindow = new();
            competitorFailsWindow.ShowDialog();
        }

        // read results
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RideResultsWindow rideResultsWindow = new();
            rideResultsWindow.ShowDialog();
        }

        // report
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new();
            reportWindow.ShowDialog();
        }

        // back
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
