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
    /// Interaction logic for frmCategory.xaml
    /// </summary>
    public partial class frmCategory : Window
    {
        private int numberOfPlayer;
        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(int numberOfPlayer)
        {
            InitializeComponent();
            this.numberOfPlayer = numberOfPlayer;
        }

        private void btnPeople_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "People");
            frmSize.Show();
            this.Close();
        }

        private void btnFruit_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Fruits");
            frmSize.Show();
            this.Close();


        }

        private void btnAnimal_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Animals");
            frmSize.Show();
            this.Close();

        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Foods");
            frmSize.Show();
            this.Close();

        }

        private void btnClothing_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Clothing");
            frmSize.Show();
            this.Close();

        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Letters");
            frmSize.Show();
            this.Close();

        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Numbers");
            frmSize.Show();
            this.Close();

        }

        private void btnHandSign_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "HandSigns");
            frmSize.Show();
            this.Close();

        }

        private void btnFlag_Click(object sender, RoutedEventArgs e)
        {
            frmSize frmSize = new frmSize(numberOfPlayer, "Flags");
            frmSize.Show();
            this.Close();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frmCover frmCover = new frmCover();
            frmCover.Show();
            this.Close();
        }
    }
}
