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
    /// Interaction logic for frmCover.xaml
    /// </summary>
    public partial class frmCover : Window
    {
        public frmCover()
        {
            InitializeComponent();
        }

        private void btnQuickGame_Click(object sender, RoutedEventArgs e)
        {
            frmCategory frmCategory = new frmCategory(1);
            frmCategory.Show();
            this.Close();
        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            frmCategory frmCategory = new frmCategory(2);
            frmCategory.Show();
            this.Close();

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }
    }
}
