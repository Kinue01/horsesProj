using horsesProj.ModelV2;
using horsesProj.Util;
using Microsoft.EntityFrameworkCore;
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

namespace horsesProj.Windows.Judge
{
    /// <summary>
    /// Логика взаимодействия для CompetitorFailsWindow.xaml
    /// </summary>
    public partial class CompetitorFailsWindow : Window
    {
        public CompetitorFailsWindow()
        {
            InitializeComponent();
        }

        // дисквалификация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TbCompetitor rs = competitors.SelectedItem as TbCompetitor;
            rs.CompetitorDisqualification = true;
            DatabaseConnection.ContextV2.Update(rs);
            DatabaseConnection.ContextV2.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            compets.ItemsSource = DatabaseConnection.ContextV2.TbCompetitions.Include(c => c.TbRides).Where(c => c.CompetJudgeId == CurrentUser.Judge.JudgeId).ToList();
            offences.ItemsSource = DatabaseConnection.ContextV2.TbOffences.ToList();
        }

        private void compets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbCompetition competition = compets.SelectedItem as TbCompetition;
            var rides = competition.TbRides;
            competitors.ItemsSource = DatabaseConnection.ContextV2.TbRideCompetitors.Include(r => r.Ride).Include(r => r.Competitor).Where(r => rides.Contains(r.Ride)).Select(r => r.Competitor).ToList();
        }

        // добавить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TbCompetitor competitor = competitors.SelectedItem as TbCompetitor;
            TbOffence offence = offences.SelectedItem as TbOffence;

            DatabaseConnection.ContextV2.TbCompetitorOffences.Add(new TbCompetitorOffence
            {
                CompetitorId = competitor.CompetitorId,
                OffenceId = offence.OffenceId
            });

            DatabaseConnection.ContextV2.SaveChanges();
        }
    }
}
