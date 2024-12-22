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
    /// Логика взаимодействия для transactions.xaml
    /// </summary>
    public partial class transactions : Page
    {
        User us;
        public transactions(User user)
        {
            InitializeComponent();
            us = user;
            BalanceLbl.Content = $"Balance: {us.Balance}";
        }

        private void GetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CardTxt.Text == "")
            {
                MessageBox.Show("Введите карту");
                return;
            }
            if (Convert.ToInt32(BalanceTxt.Text) > 0)
            {
                us.Balance += Convert.ToInt32(BalanceTxt.Text);
                BalanceLbl.Content = $"Balance: {us.Balance}";
                ConnectionClass.connect.SaveChanges();
                TransactionHistory th = new TransactionHistory();
                th.UserID = us.ID;
                th.Type = "Пополнение";
                th.summ = Convert.ToInt32(BalanceTxt.Text);
                ConnectionClass.connect.TransactionHistories.Add(th);
                ConnectionClass.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("Сумму введи нормально по-братски");
            }
        }

        private void OutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(BalanceTxt.Text) > 0 && Convert.ToInt32(BalanceTxt.Text) <= us.Balance)
            {
                us.Balance -= Convert.ToInt32(BalanceTxt.Text);
                BalanceLbl.Content = $"Balance: {us.Balance}";
                MessageBox.Show("Ваши деньги поступят через ୧̷͓̳̗͓̬̈̋̈́̔̐୧̶̳̗͕͍͑̂͗̋͆ͅ୧̴̧̛̘̦͈̑̕̕͠ͅ୧̸̢̙̭̣̟̿̇͛̔͝୧̵͎͍͇͔͒́̐͑̀͜");
                ConnectionClass.connect.SaveChanges();
                TransactionHistory th = new TransactionHistory();
                th.UserID = us.ID;
                th.Type = "Вывод";
                th.summ = Convert.ToInt32(BalanceTxt.Text);
                ConnectionClass.connect.TransactionHistories.Add(th);
                ConnectionClass.connect.SaveChanges();
            }
            else
            {
                MessageBox.Show("Сумму введи нормально по-братски");
            }
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(us));
        }

        private void GamesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Games(us));
        }

        private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatPage(us));
        }
    }
}
