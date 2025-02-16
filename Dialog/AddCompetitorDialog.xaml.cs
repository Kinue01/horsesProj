using horsesProj.ModelV2;
using horsesProj.Util;
using System.Windows;

namespace horsesProj.Dialog
{
    /// <summary>
    /// Логика взаимодействия для AddCompetitorDialog.xaml
    /// </summary>
    public partial class AddCompetitorDialog : Window
    {
        TbRideCompetitor competitor;
        int rideId;

        public AddCompetitorDialog()
        {
            InitializeComponent();
        }

        public AddCompetitorDialog(int rideId) : this()
        {
            this.rideId = rideId;
        }

        public AddCompetitorDialog(TbRideCompetitor tbRideCompetitor) : this()
        {
            competitor = tbRideCompetitor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (competitor != null)
            {
                // todo maybe will not be update by UI
                DatabaseConnection.ContextV2.TbRideCompetitors.Update(competitor);
            } else
            {
                TbJockey j = jokeys.SelectedItem as TbJockey;
                TbHorse horse = horses.SelectedItem as TbHorse;

                var comp = DatabaseConnection.ContextV2.TbCompetitors.Where(c => c.CompetitorJockeyId == j.JokeyId && c.CompetitorHorseId == horse.HorseId).FirstOrDefault();

                DatabaseConnection.ContextV2.TbRideCompetitors.Add(new TbRideCompetitor
                {
                    RideId = rideId,
                    CompetitorId = comp.CompetitorId,
                    RideResult = decimal.Parse(result.Text),
                    HorseRunFail = int.Parse(fails.Text),
                    JockeyColor = jokeyColor.Text
                });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            jokeys.ItemsSource = DatabaseConnection.ContextV2.TbJockeys.ToList();
            horses.ItemsSource = DatabaseConnection.ContextV2.TbHorses.ToList();

            if (competitor != null)
            {
                jokeys.SelectedItem = competitor.Competitor.CompetitorJockey;
                horses.SelectedItem = competitor.Competitor.CompetitorHorse;
                result.Text = competitor.RideResult.ToString();
                fails.Text = competitor.HorseRunFail.ToString();
                jokeyColor.Text = competitor.JockeyColor;
            }
        }
    }
}
