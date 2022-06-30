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

namespace My_TIk_Tak_Toe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int move = 0;
        private int xscore = 0;
        private int oscore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            Start.Visibility = Visibility.Collapsed;
            Exit.Visibility = Visibility.Collapsed;
            LanPL.Visibility = Visibility.Visible;
            BotPL.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Start.Visibility = Visibility.Visible;
            Exit.Visibility = Visibility.Visible;
            LanPL.Visibility = Visibility.Collapsed;
            BotPL.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
        }

        private void StartLanPlay(object sender, RoutedEventArgs e)
        {
            LanPL.Visibility = Visibility.Collapsed;
            BotPL.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
            Button_1.Visibility = Visibility.Visible;
            Button_2.Visibility = Visibility.Visible;
            Button_3.Visibility = Visibility.Visible;
            Button_4.Visibility = Visibility.Visible;
            Button_5.Visibility = Visibility.Visible;
            Button_6.Visibility = Visibility.Visible;
            Button_7.Visibility = Visibility.Visible;
            Button_8.Visibility = Visibility.Visible;
            Button_9.Visibility = Visibility.Visible;
            Wait.Visibility = Visibility.Visible;
            Move.Visibility = Visibility.Visible;
            x.Visibility = Visibility.Visible;
            o.Visibility = Visibility.Visible;
            x_score.Visibility = Visibility.Visible;
            o_score.Visibility = Visibility.Visible;
            MainMenu.Visibility = Visibility.Visible;
            PlayLogic();
        }

        private void StartBotPlay(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ну этого бота в сраку");
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            Button_1.Visibility = Visibility.Collapsed;
            Button_2.Visibility = Visibility.Collapsed;
            Button_3.Visibility = Visibility.Collapsed;
            Button_4.Visibility = Visibility.Collapsed;
            Button_5.Visibility = Visibility.Collapsed;
            Button_6.Visibility = Visibility.Collapsed;
            Button_7.Visibility = Visibility.Collapsed;
            Button_8.Visibility = Visibility.Collapsed;
            Button_9.Visibility = Visibility.Collapsed;
            Wait.Visibility = Visibility.Collapsed;
            Move.Visibility = Visibility.Collapsed;
            x.Visibility = Visibility.Collapsed;
            o.Visibility = Visibility.Collapsed;
            x_score.Visibility = Visibility.Collapsed;
            o_score.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            Start.Visibility = Visibility.Visible;
            Exit.Visibility = Visibility.Visible;
            xscore = 0;
            oscore = 0;
            EndGame();
        }

        private void PlayLogic()
        {
            x_score.Text = xscore.ToString();
            o_score.Text = oscore.ToString();

            if (move % 2 == 0)
            {
                Move.Text = "x";
            }
            else
            {
                Move.Text = "o";
            }

            char[] pobeda = new char[9];
            pobeda[0] = Button_1.Content.ToString()[0];
            pobeda[1] = Button_2.Content.ToString()[0];
            pobeda[2] = Button_3.Content.ToString()[0];
            pobeda[3] = Button_4.Content.ToString()[0];
            pobeda[4] = Button_5.Content.ToString()[0];
            pobeda[5] = Button_6.Content.ToString()[0];
            pobeda[6] = Button_7.Content.ToString()[0];
            pobeda[7] = Button_8.Content.ToString()[0];
            pobeda[8] = Button_9.Content.ToString()[0];

            Win(pobeda[0], pobeda[1], pobeda[2]);
            Win(pobeda[3], pobeda[4], pobeda[5]);
            Win(pobeda[6], pobeda[7], pobeda[8]);
            Win(pobeda[0], pobeda[4], pobeda[8]);
            Win(pobeda[2], pobeda[4], pobeda[6]);
            Win(pobeda[0], pobeda[3], pobeda[6]);
            Win(pobeda[1], pobeda[4], pobeda[7]);
            Win(pobeda[2], pobeda[5], pobeda[8]);

            if (Button_1.IsEnabled == false && Button_2.IsEnabled == false && Button_3.IsEnabled == false && Button_4.IsEnabled == false && Button_5.IsEnabled == false && Button_6.IsEnabled == false && Button_7.IsEnabled == false && Button_8.IsEnabled == false && Button_9.IsEnabled == false)
            {
                EndGame();
                //move++;
            }
        }

        private void Win(char first, char second, char third)
        {
            if (first == second && first == third && first.ToString() != " ")
            {
                MessageBox.Show("Win: " + first.ToString());
                EndGame();
                if (first.ToString() == "x")
                {
                    xscore++;
                    x_score.Text = xscore.ToString();
                    o_score.Text = oscore.ToString();
                }
                else
                {
                    oscore++;
                    x_score.Text = xscore.ToString();
                    o_score.Text = oscore.ToString();

                }
            }
        }

        private void EndGame()
        {
            Button_1.IsEnabled = true;
            Button_2.IsEnabled = true;
            Button_3.IsEnabled = true;
            Button_4.IsEnabled = true;
            Button_5.IsEnabled = true;
            Button_6.IsEnabled = true;
            Button_7.IsEnabled = true;
            Button_8.IsEnabled = true;
            Button_9.IsEnabled = true;
            Button_1.Content = " ";
            Button_2.Content = " ";
            Button_3.Content = " ";
            Button_4.Content = " ";
            Button_5.Content = " ";
            Button_6.Content = " ";
            Button_7.Content = " ";
            Button_8.Content = " ";
            Button_9.Content = " ";
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (move % 2 == 0)
            {
                ((Button)sender).Content = "x";
                ((Button)sender).IsEnabled = false;
            }
            else 
            {
                ((Button)sender).Content = "o";
                ((Button)sender).IsEnabled = false;
            }
            move++;
            PlayLogic();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
