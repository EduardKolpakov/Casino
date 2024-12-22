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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string log = TxtLogin.Text;
            string pass = TxtPassword.Password;
            User user = new User();
            user.Login = log;
            user.Password = pass;
            user.Balance = 0;
            user.Role = RoleSel.SelectedValue.ToString();
            ConnectionClass.connect.Users.Add(user);
            ConnectionClass.connect.SaveChanges();
            NavigationService.Navigate(new MainPage(user));
        }

        private void RoleSel_Initialized(object sender, EventArgs e)
        {
            RoleSel.Items.Add("Owner");
            RoleSel.Items.Add("Admin");
            RoleSel.Items.Add("User");
        }
    }
}
