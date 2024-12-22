using Casino.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using QRCoder;
using System.Drawing;


namespace Casino.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        User us;
        public MainPage(User user)
        {
            InitializeComponent();
            LoginLabel.Content = "Login: " + user.Login;
            BalanceLabel.Content = "Balance: " + user.Balance;
            us = user;
            RoleLabel.Content = "Role: " + user.Role;
            if (us.Role == "User")
            {
                RoleInfo.Visibility = Visibility.Hidden;
                RoleSel.Visibility = Visibility.Hidden;
                LoginTxt.Text = us.Login;
                PasswordTxt.Password = us.Password;
            }
            else
            {
                LoginTxt.Text = us.Login;
                PasswordTxt.Password = us.Password;
                RoleSel.SelectedValue = us.Role;
            }
        }

        private void RoleSel_Initialized(object sender, EventArgs e)
        {
            RoleSel.Items.Add("Owner");
            RoleSel.Items.Add("Admin");
            RoleSel.Items.Add("User");
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (us.Role == "User")
            {
                us.Login = LoginTxt.Text;
                us.Password = PasswordTxt.Password;
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Успешно сохранено!");
                LoginLabel.Content = "Login: " + us.Login;
                return;
            }
            if (us.Role == "Admin")
            {
                if (RoleSel.SelectedValue.ToString() == "Owner")
                {
                    MessageBox.Show("Админ не может назначить себя владельцем!");
                    return;
                }
            }
            us.Login = LoginTxt.Text;
            us.Password = PasswordTxt.Password;
            us.Role = RoleSel.SelectedValue.ToString();
            LoginLabel.Content = "Login: " + us.Login;
            RoleLabel.Content = "Role: " + us.Role;
            ConnectionClass.connect.SaveChanges();
        }

        private void GamesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Games(us));
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
