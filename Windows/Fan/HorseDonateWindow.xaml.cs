using horsesProj.Util;
using System.Windows;
using System.Windows.Media;

namespace horsesProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для HorseDonateWindow.xaml
    /// </summary>
    public partial class HorseDonateWindow : Window
    {
        public HorseDonateWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            horses.ItemsSource = DatabaseConnection.ContextV2.TbHorses.ToList();
            months.ItemsSource = Enumerable.Range(1, 12);
            years.ItemsSource = Enumerable.Range(2014, 27);
        }

        bool IsValid(long card)
        {
            string temp = card.ToString();
            if (temp.Length > 16)
            {
                return false;
            }

            char[] chars = temp.ToCharArray();
            Array.Reverse(chars);
            temp = new string(chars);

            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                int dig = int.Parse(temp[i].ToString());

                if (i == 0)
                {
                    sum += dig;
                }
                else if (i % 2 != 0)
                {
                    dig *= 2;
                    if (dig > 9)
                    {
                        dig -= 9;
                    }
                    sum += dig;
                }
                else
                {
                    sum += dig;
                }
            }

            if (sum % 10 != 0)
            {
                return false;
            }

            return true;
        }

        private void cardcode_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try {
                if (IsValid(long.Parse(cardcode.Text))) cardcode.Background = Brushes.Green;
                else cardcode.Background = Brushes.Red;
            } catch (Exception) {
                MessageBox.Show("Вводи цифры");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thx");
            Close();
        }
    }
}
