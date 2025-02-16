using horsesProj.ModelV2;
using horsesProj.Util;
using Microsoft.Win32;
using System.Windows;

namespace horsesProj.Windows.Judge
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();

            var re = DatabaseConnection.ContextV2.TbRideCompetitors.Where(r => competition.TbRides.Contains(r.Ride)).ToList();

            bool res = ReportUtils.genPDFReport(re, dialog.FileName);
            if (res)
            {
                MessageBox.Show("Репорт создан успешно");
            } else
            {
                MessageBox.Show("Ошибка");
            }

            Close();
        }
    }
}
