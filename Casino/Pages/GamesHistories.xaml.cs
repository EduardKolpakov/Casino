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
    /// Логика взаимодействия для GamesHistory.xaml
    /// </summary>
    public partial class GamesHistories : Page
    {
        User US;
        public GamesHistories(User user)
        {
            InitializeComponent();
            US = user;
            LvTr.ItemsSource = ConnectionClass.connect.GamesHistories.Where(z => z.UserID == US.ID).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
