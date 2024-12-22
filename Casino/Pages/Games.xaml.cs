using Casino.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Casino.Pages
{
    /// <summary>
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        User us;
        public Games(User user)
        {
            InitializeComponent();
            us = user;
        }

        private void BlackJackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BlackJack(us));
        }

        private void SlotsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new slots(us));
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(us));
        }

        private void TransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new transactions(us));
        }

        private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatPage(us));
        }
    }
}
