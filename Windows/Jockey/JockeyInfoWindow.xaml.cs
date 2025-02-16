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

namespace horsesProj.Windows.Jockey
{
    /// <summary>
    /// Логика взаимодействия для JockeyInfoWindow.xaml
    /// </summary>
    public partial class JockeyInfoWindow : Window
    {
        public JockeyInfoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string f = fio.Text;
            int w = int.Parse(weight.Text);

            CurrentUser.Jokey.JokeyFio = f;
            CurrentUser.Jokey.JokeyWeight = w;

            DatabaseConnection.ContextV2.TbJockeys.Update(CurrentUser.Jokey);
            DatabaseConnection.ContextV2.SaveChanges();
        }
    }
}
