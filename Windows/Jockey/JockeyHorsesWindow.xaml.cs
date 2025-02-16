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

namespace horsesProj.Windows.Jockey
{
    /// <summary>
    /// Логика взаимодействия для JockeyHorsesWindow.xaml
    /// </summary>
    public partial class JockeyHorsesWindow : Window
    {
        TbHorse horse;

        public JockeyHorsesWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            horse.HorseName = name.Text;
            horse.HorseTrainerFio = trainer.Text;
            DatabaseConnection.ContextV2.TbHorses.Update(horse);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            horse = DatabaseConnection.ContextV2.TbHorses.Where(h => h.HorseOwnerId == CurrentUser.Jokey.JokeyId).FirstOrDefault();
            name.Text = horse.HorseName;
            trainer.Text = horse.HorseTrainerFio;
        }
    }
}
