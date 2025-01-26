using horsesProj.Model;
using horsesProj.Util;
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
            TbUser user = DatabaseConnection.context.TbUsers.Find(login.Text);
            if (user != null && user.UserPassword.Equals(password.Password))
            {
                //Вход в формы жокея и судьи
            }
            else MessageBox.Show("Нет такого пользователя или неправильный пароль");
        }

        // Болельщик
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FanWindow fanWindow = new();
            fanWindow.ShowDialog();
        }
    }
}
