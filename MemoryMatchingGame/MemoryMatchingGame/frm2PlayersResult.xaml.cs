using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Shapes;

namespace MemoryMatchingGame
{
    /// <summary>
    /// Interaction logic for frm2PlayersResult.xaml
    /// </summary>
    public partial class frm2PlayersResult : Window
    {
        private int numberOfPlayer;
        private string category;
        private int row;
        private int column;
        private string time;
        private int move;
        private int blueScore;
        private int redScore;
        public frm2PlayersResult(int numberOfPlayer, string category, int row, int column, string time, int move,int blueScore,int redScore)
        {
            InitializeComponent();
            this.numberOfPlayer = numberOfPlayer;
            this.category = category;
            this.row = row;
            this.column = column;
            this.blueScore = blueScore;
            this.redScore = redScore;
            tbBlueScore.Text = blueScore.ToString();
            tbRedScore.Text = redScore.ToString();
            tbTime.Text = time;
            tbMove.Text = move.ToString();
            if(blueScore > redScore)
            {
                tbWinner.Text = "Blue Win!";
                BlueIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Winner.png"));
                RedIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Loser.png"));
            }
            else if (blueScore < redScore)
            { 
                tbWinner.Text = "Red Win!";
                BlueIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Loser.png"));
                RedIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Winner.png"));
            }
            else
            {
                tbWinner.Text = "Draw!";
                BlueIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Winner.png"));
                RedIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ResultIcon/Winner.png"));
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmCategory category = new frmCategory(numberOfPlayer);
            category.Show();
            this.Close();
        }

        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, row, column);
            mainWindow.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frmCover frmCover = new frmCover();
            frmCover.Show();
            this.Close();
        }

    }
}
