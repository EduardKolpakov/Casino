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
    /// Логика взаимодействия для BlackJack.xaml
    /// </summary>

    public partial class BlackJack : Page
    {
        string[] cards_a = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "j", "q", "k", "a" };
        string[] cards_b = new string[4] { "c", "d", "h", "s" };
        Random rnd = new Random();
        string curcard;
        bool started = false;
        List<string> row1 = new List<string>();
        List<string> row2 = new List<string>();
        List<string> row3 = new List<string>();
        int row1c = 0;
        int row2c = 0;
        int row3c = 0;
        int row1p = 0;
        int row2p = 0;
        int row3p = 0;
        int hp = 3;
        int pts = 0;
        string messageBoxText = "Do you want to save changes?";
        string caption = "Word Processor";
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage icon = MessageBoxImage.Warning;
        MessageBoxResult result;
        User Us;
        int bet;
        int startBal;
        bool sessionStarted = false;
        public BlackJack(User user)
        {
            InitializeComponent();
            curcard = shuffle();
            hpUpd();
            ScoreUpd();
            row1_pts.Content = "0";
            row2_pts.Content = "0";
            row3_pts.Content = "0";
            LastScore.Content = "Last score: ";
            Us = user;
            BalanceLabel.Content = "Balance" + user.Balance;
            startBal = Convert.ToInt32(Us.Balance);
        }
        public string shuffle()
        {
            string curr_card = $"{cards_a[rnd.Next(cards_a.Count())]}{cards_b[rnd.Next(cards_b.Count())]}";
            ChangeImage(curCard, curr_card);
            return curr_card;
        }
        public void ChangeImage(Image img, string card)
        {
            img.Source = BitmapFrame.Create(new Uri($@"pack://application:,,,/images/{card}.jpg"));
        }

        private void row1_btn_Click(object sender, RoutedEventArgs e)
        {
            if (started)
            {
                row1.Add(curcard);
                row1c++;
                switch (row1c)
                {
                    case 1:
                        {
                            ChangeImage(row1_1, curcard);
                            break;
                        }
                    case 2:
                        {
                            ChangeImage(row1_2, curcard);
                            break;
                        }
                    case 3:
                        {
                            ChangeImage(row1_3, curcard);
                            break;
                        }
                    case 4:
                        {
                            ChangeImage(row1_4, curcard);
                            break;
                        }
                    case 5:
                        {
                            ChangeImage(row1_5, curcard);
                            break;
                        }
                    case 6:
                        {
                            RowEnd("1");
                            row1c = 0;
                            break;
                        }
                }
                curcard = shuffle();
                RowEnd("1");
            }
        }

        private void row2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (started)
            {
                row2.Add(curcard);
                row2c++;
                switch (row2c)
                {
                    case 1:
                        {
                            ChangeImage(row2_1, curcard);
                            break;
                        }
                    case 2:
                        {
                            ChangeImage(row2_2, curcard);
                            break;
                        }
                    case 3:
                        {
                            ChangeImage(row2_3, curcard);
                            break;
                        }
                    case 4:
                        {
                            ChangeImage(row2_4, curcard);
                            break;
                        }
                    case 5:
                        {
                            ChangeImage(row2_5, curcard);
                            break;
                        }
                    case 6:
                        {
                            RowEnd("2");
                            row2c = 0;
                            break;
                        }
                }
                curcard = shuffle();
                RowEnd("2");
            }
        }

        private void row3_btn_Click(object sender, RoutedEventArgs e)
        {
            if (started)
            {
                row3.Add(curcard);
                row3c++;
                switch (row3c)
                {
                    case 1:
                        {
                            ChangeImage(row3_1, curcard);
                            break;
                        }
                    case 2:
                        {
                            ChangeImage(row3_2, curcard);
                            break;
                        }
                    case 3:
                        {
                            ChangeImage(row3_3, curcard);
                            break;
                        }
                    case 4:
                        {
                            ChangeImage(row3_4, curcard);
                            break;
                        }
                    case 5:
                        {
                            ChangeImage(row3_5, curcard);
                            break;
                        }
                    case 6:
                        {
                            RowEnd("3");
                            row3c = 0;
                            break;
                        }
                }
                curcard = shuffle();
                RowEnd("3");
            }
        }
        public void hpUpd()
        {
            Lives.Content = $"Lives: {hp}";
            if (hp == 0)
            {
                row1.Clear();
                row2.Clear();
                row3.Clear();
                row1_1.Source = null;
                row1_2.Source = null;
                row1_3.Source = null;
                row1_4.Source = null;
                row1_5.Source = null;
                row2_1.Source = null;
                row2_2.Source = null;
                row2_3.Source = null;
                row2_4.Source = null;
                row2_5.Source = null;
                row3_1.Source = null;
                row3_2.Source = null;
                row3_3.Source = null;
                row3_4.Source = null;
                row3_5.Source = null;
                row1p = 0;
                row2p = 0;
                row3p = 0;
                row1c = 0;
                row2c = 0;
                row3c = 0;
                row1_pts.Content = 0;
                row2_pts.Content = 0;
                row3_pts.Content = 0;
                row1.Clear();
                row2.Clear();
                row3.Clear();
                hp = 3;
                LastScore.Content = $"Last score: {pts}";
                int LastPts = pts;
                pts = 0;
                Lives.Content = $"Lives: {hp}";
                started = false;
                int coef = -1;
                GamesHistory gh = new GamesHistory();
                gh.GameName = "BlackJack";
                gh.Bet = bet;
                gh.UserID = Us.ID;
                if (LastPts >= 2000 && LastPts < 5000)
                {
                    coef = 1;
                }
                else if (LastPts >= 5000)
                {
                    coef = 4;
                }
                int bchange = Math.Abs(bet * coef);
                if (coef < 0)
                {
                    MessageBox.Show($"Вы проиграли {bchange} рубликов!\nАнлак:(");
                    Us.Balance -= bchange;
                    gh.Result = $"Lost ({bchange})";
                }
                else if (coef > 0)
                {
                    MessageBox.Show($"Вы выиграли {bchange} рубликов!\nАнлак:(");
                    Us.Balance += bchange;
                    gh.Result = $"Won ({bchange})";
                }
                BalanceLabel.Content = $"Balance: {Us.Balance}";
                ConnectionClass.connect.GamesHistories.Add(gh);
                ConnectionClass.connect.SaveChanges();
                ScoreUpd();
            }
        }
        public void ScoreUpd()
        {
            Score.Content = $"Score: {pts}";
        }
        public void RowEnd(string rw)
        {
            if (rw == "1")
            {
                foreach (string c in row1)
                {
                    if (c.Contains("2"))
                    {
                        row1p += 2;
                        continue;
                    }
                    if (c.Contains("3"))
                    {
                        row1p += 3;
                        continue;
                    }
                    if (c.Contains("4"))
                    {
                        row1p += 4;
                        continue;
                    }
                    if (c.Contains("5"))
                    {
                        row1p += 5;
                        continue;
                    }
                    if (c.Contains("6"))
                    {
                        row1p += 6;
                        continue;
                    }
                    if (c.Contains("7"))
                    {
                        row1p += 7;
                        continue;
                    }
                    if (c.Contains("8"))
                    {
                        row1p += 8;
                        continue;
                    }
                    if (c.Contains("9"))
                    {
                        row1p += 9;
                        continue;
                    }
                    if (c.Contains("10"))
                    {
                        row1p += 10;
                        continue;
                    }
                    if (c.Contains("j"))
                    {
                        row1p += 10;
                        continue;
                    }
                    if (c.Contains("q"))
                    {
                        row1p += 10;
                        continue;
                    }
                    if (c.Contains("k"))
                    {
                        row1p += 10;
                        continue;
                    }
                    if (c.Contains("a"))
                    {
                        if (row1p + 11 <= 21)
                            row1p += 11;
                        else
                            row1p += 1;
                        continue;
                    }
                }
                row1_pts.Content = row1p;
                if (row1p == 21)
                {
                    messageBoxText = "21!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    pts += 300;
                }
                else if (row1p > 21 & row1c <= 5)
                {
                    messageBoxText = "Слишком много очков!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    if (pts >= 50)
                        pts -= 50;
                    hp--;
                }
                else if (row1p < 21 & row1c == 5)
                {
                    messageBoxText = "БЛЕКДЖЕК!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row1_1.Source = null;
                    row1_2.Source = null;
                    row1_3.Source = null;
                    row1_4.Source = null;
                    row1_5.Source = null;
                    row1.Clear();
                    row1c = 0;
                    row1_pts.Content = 0;
                    pts += 150;
                }
                row1p = 0;
            }
            if (rw == "2")
            {
                foreach (string c in row2)
                {
                    if (c.Contains("2"))
                    {
                        row2p += 2;
                        continue;
                    }
                    if (c.Contains("3"))
                    {
                        row2p += 3;
                        continue;
                    }
                    if (c.Contains("4"))
                    {
                        row2p += 4;
                        continue;
                    }
                    if (c.Contains("5"))
                    {
                        row2p += 5;
                        continue;
                    }
                    if (c.Contains("6"))
                    {
                        row2p += 6;
                        continue;
                    }
                    if (c.Contains("7"))
                    {
                        row2p += 7;
                        continue;
                    }
                    if (c.Contains("8"))
                    {
                        row2p += 8;
                        continue;
                    }
                    if (c.Contains("9"))
                    {
                        row2p += 9;
                        continue;
                    }
                    if (c.Contains("10"))
                    {
                        row2p += 10;
                        continue;
                    }
                    if (c.Contains("j"))
                    {
                        row2p += 10;
                        continue;
                    }
                    if (c.Contains("q"))
                    {
                        row2p += 10;
                        continue;
                    }
                    if (c.Contains("k"))
                    {
                        row2p += 10;
                        continue;
                    }
                    if (c.Contains("a"))
                    {
                        if (row2p + 11 <= 21)
                            row2p += 11;
                        else
                            row2p += 1;
                        continue;
                    }
                }
                row2_pts.Content = row2p;
                if (row2p == 21)
                {
                    messageBoxText = "21!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    pts += 300;
                }
                else if (row2p > 21 && row2c <= 5)
                {
                    messageBoxText = "Слишком много карт!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    if (pts >= 50)
                        pts -= 50;
                    hp--;
                }
                else if (row2p < 21 & row2c == 5)
                {
                    messageBoxText = "БЛЕКДЖЕК!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row2_1.Source = null;
                    row2_2.Source = null;
                    row2_3.Source = null;
                    row2_4.Source = null;
                    row2_5.Source = null;
                    row2.Clear();
                    row2c = 0;
                    row2_pts.Content = 0;
                    pts += 150;
                }
                row2p = 0;
            }
            if (rw == "3")
            {
                foreach (string c in row3)
                {
                    if (c.Contains("2"))
                    {
                        row3p += 2;
                        continue;
                    }
                    if (c.Contains("3"))
                    {
                        row3p += 3;
                        continue;
                    }
                    if (c.Contains("4"))
                    {
                        row3p += 4;
                        continue;
                    }
                    if (c.Contains("5"))
                    {
                        row3p += 5;
                        continue;
                    }
                    if (c.Contains("6"))
                    {
                        row3p += 6;
                        continue;
                    }
                    if (c.Contains("7"))
                    {
                        row3p += 7;
                        continue;
                    }
                    if (c.Contains("8"))
                    {
                        row3p += 8;
                        continue;
                    }
                    if (c.Contains("9"))
                    {
                        row3p += 9;
                        continue;
                    }
                    if (c.Contains("10"))
                    {
                        row3p += 10;
                        continue;
                    }
                    if (c.Contains("j"))
                    {
                        row3p += 10;
                        continue;
                    }
                    if (c.Contains("q"))
                    {
                        row3p += 10;
                        continue;
                    }
                    if (c.Contains("k"))
                    {
                        row3p += 10;
                        continue;
                    }
                    if (c.Contains("a"))
                    {
                        if (row3p + 11 <= 21)
                            row3p += 11;
                        else
                            row3p += 1;
                        continue;
                    }
                }
                row3_pts.Content = row3p;
                if (row3p == 21)
                {
                    messageBoxText = "21!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row3_1.Source = null;
                    row3_2.Source = null;
                    row3_3.Source = null;
                    row3_4.Source = null;
                    row3_5.Source = null;
                    row3.Clear();
                    row3c = 0;
                    row3_pts.Content = 0;
                    pts += 300;
                }
                else if (row3p > 21 && row3c <= 5)
                {
                    messageBoxText = "Слишком много карт!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row3_1.Source = null;
                    row3_2.Source = null;
                    row3_3.Source = null;
                    row3_4.Source = null;
                    row3_5.Source = null;
                    row3.Clear();
                    row3c = 0;
                    row3_pts.Content = 0;
                    if (pts >= 50)
                        pts -= 50;
                    hp--;
                }
                else if (row3p < 21 & row3c == 5)
                {
                    messageBoxText = "БЛЕКДЖЕК!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    row3_1.Source = null;
                    row3_2.Source = null;
                    row3_3.Source = null;
                    row3_4.Source = null;
                    row3_5.Source = null;
                    row3.Clear();
                    row3c = 0;
                    row3_pts.Content = 0;
                    pts += 150;
                }
                row3p = 0;
            }
            hpUpd();
            ScoreUpd();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!started)
            {
                int Bet = Convert.ToInt32(TxtBet.Text);
                if (Bet > Us.Balance)
                {
                    MessageBox.Show("Недостаточно лавэ!");
                }
                else
                {
                    BetLabel.Content = "Bet: " + Bet.ToString();
                    bet = Bet;
                    started = true;
                    MessageBox.Show("Игра запущена!");
                    if (sessionStarted == false)
                    {
                        sessionStarted = true;
                    }
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (started)
            {
                if (MessageBox.Show("Вы точно хотите выйти из игры и потерять поставленные деньги?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    hp = 0;
                    hpUpd();
                    if (sessionStarted)
                    {
                        BalanceHistory bh = new BalanceHistory();
                        bh.UserID = Us.ID;
                        bh.BalanceChange = (Us.Balance - startBal).ToString();
                        bh.GameType = "BlackJack";
                        ConnectionClass.connect.BalanceHistories.Add(bh);
                        ConnectionClass.connect.SaveChanges();
                    }
                    NavigationService.Navigate(new MainPage(Us));
                }
            }
            else
            {
                if (sessionStarted)
                {
                    BalanceHistory bh = new BalanceHistory();
                    bh.UserID = Us.ID;
                    bh.BalanceChange = (Us.Balance - startBal).ToString();
                    bh.GameType = "BlackJack";
                    ConnectionClass.connect.BalanceHistories.Add(bh);
                    ConnectionClass.connect.SaveChanges();
                }
                NavigationService.Navigate(new Games(Us));
            }
        }
    }
}
