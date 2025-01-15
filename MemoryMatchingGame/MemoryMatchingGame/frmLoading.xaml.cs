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
    /// Interaction logic for frmLoading.xaml
    /// </summary>
    public partial class frmLoading : Window
    {
        public frmLoading()
        {
            InitializeComponent();
            StartLoading();
        }

        private async void StartLoading()
        {
            for (int i = 0; i <= 100; i++)
            {
               
                LoadingBar.Value = i; 
                await Task.Delay(25); 
                if ( i== 100)
                {
                    frmCover frmCover = new frmCover();
                    frmCover.Show();
                    this.Close();
                }
            }
        }
    }
}
