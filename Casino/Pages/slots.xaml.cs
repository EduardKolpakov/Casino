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
    /// Логика взаимодействия для slots.xaml
    /// </summary>
    public partial class slots : Page
    {
        int Balance;
        int bet;
        User US;
        List<string> slotsItems = new List<string>();
        bool started = false;
        Random random = new Random();
        string slot1item;
        string slot2item;
        string slot3item;
        int prize;
        bool wasStarted = false;
        int initBal;
        public slots(User user)
        {
            InitializeComponent();
            US = user;
            Balance = Convert.ToInt32(US.Balance);
            BalanceLabel.Content = $"Balance: {Balance}";
            slotsItems.Add("Cherry");
            slotsItems.Add("Coin");
            slotsItems.Add("Seven");
        }
        async Task roll()
        {
            for (int i = 0; i <= 15; i++)
            {
                slot1item = slotsItems[random.Next(0, 3)];
                ChangeImage(slot1, slot1item);
                await Task.Delay(100);
                slot2item = slotsItems[random.Next(0, 3)];
                ChangeImage(slot2, slot2item);
                await Task.Delay(100);
                slot3item = slotsItems[random.Next(0, 3)];
                ChangeImage(slot3, slot3item);
                await Task.Delay(500);
            }
            result();
        }
        void ChangeImage(Image img, string item)
        {
            img.Source = BitmapFrame.Create(new Uri($@"pack://application:,,,/images/{item.ToLower()}.png"));
        }

        void result()
        {
            GamesHistory gh = new GamesHistory();
            gh.UserID = US.ID;
            gh.GameName = "Slots";
            gh.Bet = bet;
            if (slot1item == slot2item)
            {
                prize = bet * 2;
            }
            else if (slot1item == slot3item)
            {
                prize = bet * 2;
            }
            else if(slot2item == slot3item)
            {
                prize = bet * 2;
            }
            if (slot1item == slot2item && slot2item == slot3item)
            {
                prize = bet * 5;
                MessageBox.Show("Джекпот!");
            }
            if (slot1item != slot2item && slot2item != slot3item && slot1item != slot3item)
            {
                prize = bet * -1;
            }
            Balance += prize;
            if (prize > 0)
            {
                gh.Result = $"Won ({prize})";
                MessageBox.Show($"Вы выиграли {prize}!");
            }
            else
            {
                gh.Result = $"Lost ({Math.Abs(prize)})";
                MessageBox.Show($"Вы проиграли {prize} :(");
            }
            started = false;
            BalanceLabel.Content = $"Balance: {Balance}";
            US.Balance = Balance;
            ConnectionClass.connect.GamesHistories.Add(gh);
            ConnectionClass.connect.SaveChanges();

            
        }

        private async void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            bet = Convert.ToInt32(TxtBet.Text);
            if (bet > 0 && bet <= Balance && started == false)
            {
                initBal = Convert.ToInt32(US.Balance);
                wasStarted = true;
                started = true;
                MessageBox.Show("Игра началась!");
                BetLabel.Content = "Bet: " + bet;
                await roll();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (wasStarted)
            {
                int change = Balance - initBal;
                BalanceHistory bh = new BalanceHistory();
                bh.UserID = US.ID;
                bh.BalanceChange = $"{change}";
                bh.GameType = "Slots";
                ConnectionClass.connect.BalanceHistories.Add(bh);
                ConnectionClass.connect.SaveChanges();
                NavigationService.Navigate(new Games(US));
            }
            else
            {
                NavigationService.Navigate(new Games(US));
            }
        }
    }
}
