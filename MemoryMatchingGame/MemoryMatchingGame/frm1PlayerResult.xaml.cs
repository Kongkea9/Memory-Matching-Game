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
using System.Windows.Shapes;

namespace MemoryMatchingGame
{
    /// <summary>
    /// Interaction logic for frm1PlayerResult.xaml
    /// </summary>
    public partial class frm1PlayerResult : Window
    {
        private int numberOfPlayer;
        private string category;
        private int row;
        private int column;
        private string time;
        private int move;
        public frm1PlayerResult(int numberOfPlayer,string category, int row,int column,string time,int move)
        {
            InitializeComponent();
            this.numberOfPlayer = numberOfPlayer;
            this.category = category;
            this.row = row;
            this.column = column;
            tbTime.Text = time;
            tbMove.Text = move.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmCategory category = new frmCategory(numberOfPlayer);
            category.Show();
            this.Close();
        }

        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer,category,row,column);
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
