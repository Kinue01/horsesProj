using horsesProj.ModelV2;
using horsesProj.Util;
using horsesProj.Windows.Jockey;
using horsesProj.Windows.Judge;
using System.Windows;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        // Назад
        private void Button_Click(object sender, RoutedEventArgs e) => Close();

        // Вход
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TbUser user = DatabaseConnection.ContextV2.TbUsers.Find(login.Text);

            if (user != null && user.UserPassword.Equals(password.Password)) CurrentUser.User = user;
            else
            {
                MessageBox.Show("Нет такого пользователя или неправильный пароль");
                return;
            }

            if (CurrentUser.User.UserRoleId == 1) {
                CurrentUser.Jokey = DatabaseConnection.ContextV2.TbJockeys.Where(u => u.JokeyUserLogin == user.UserLogin).FirstOrDefault();
                JockeyWindow jokeysWindow = new();
                jokeysWindow.ShowDialog();
            }
            else {
                CurrentUser.Judge = DatabaseConnection.ContextV2.TbJudges.Where(u => u.JudgeUserLogin == user.UserLogin).FirstOrDefault();
                JudgeWindow judgeWindow = new();
                judgeWindow.ShowDialog();
            }
        }

        // Болельщик
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FanWindow fanWindow = new();
            fanWindow.ShowDialog();
        }
    }
}
