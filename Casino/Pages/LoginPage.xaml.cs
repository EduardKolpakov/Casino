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
using Casino.Model;

namespace Casino.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string log = TxtLogin.Text;
            string pass = TxtPassword.Password;
            var d = ConnectionClass.connect.Users.Where(us => us.Login == log && us.Password == pass).FirstOrDefault();
            if (d != null)
            {
                MessageBox.Show("Добро пожаловать!");
                NavigationService.Navigate(new MainPage(d));
            }
            else
            {
                MessageBox.Show("Такой пользователь не существует! Проверьте пароль или зарегистрируйтесь!");
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
