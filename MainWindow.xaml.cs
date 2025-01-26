using horsesProj.Windows;
using System.Windows;

namespace horsesProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Начало работы
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new();
            authWindow.ShowDialog();
        }

        // Инфа о программе
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppInfoWindow appInfoWindow = new();
            appInfoWindow.ShowDialog();
        }

        // Выход
        private void Button_Click_2(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}