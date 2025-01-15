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
    /// Interaction logic for frmSize1.xaml
    /// </summary>
    public partial class frmSize : Window
    {
        private int numberOfPlayer;
        private string category;
        public frmSize(int numberOfPlayer, string category)
        {
            InitializeComponent();
            this.numberOfPlayer = numberOfPlayer;
            this.category = category;
        }
        

        private void btn3x2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer,category,3,2);
            mainWindow.Show();
            this.Close();
        }

        private void btn4x3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, 4, 3);
            mainWindow.Show();
            this.Close();

        }

        private void btn4x4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, 4, 4);
            mainWindow.Show();
            this.Close();

        }

        private void btn5x4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, 5, 4);
            mainWindow.Show();
            this.Close();

        }

        private void btn6x5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, 6, 5);
            mainWindow.Show();
            this.Close();

        }

        private void btn8x5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(numberOfPlayer, category, 8, 5);
            mainWindow.Show();
            this.Close();

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frmCover frmCover = new frmCover();
            frmCover.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            
            frmCategory frmCategory = new frmCategory(numberOfPlayer);    
            frmCategory.Show();
            this.Close();
            
        }

    }
}
