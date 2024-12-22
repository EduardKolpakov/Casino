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
    /// Логика взаимодействия для StatPage.xaml
    /// </summary>
    public partial class StatPage : Page
    {
        User US;
        public StatPage(User user)
        {
            InitializeComponent();
            US = user;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(US));
        }

        private void GamesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Games(US));
        }

        private void TransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new transactions(US));
        }

        private void TransHistBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TH(US));
        }

        private void SessionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sessions(US));
        }

        private void GamesHistBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamesHistories(US));
        }
    }
}
