using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace es3_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEsegui_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txt_Numero.Text);

            pbr_Progress.Minimum = 0;
            pbr_Progress.Maximum = 100;
            pbr_Progress.Value = 0;

            TrovaMultipli(a);
        }

        public async Task TrovaMultipli(int n)
        {
            await Task.Run(() =>
            {
                int max = 2000000;
                int min = 0;
                for (int i = 1; i <= max; i++)
                {
                    if ((i % n) == 0)
                    {
                        min++;
                    }
                    if (i % 2000000 == 0)
                    {
                        pbr_Progress.Dispatcher.Invoke(() =>
                        pbr_Progress.Value++);
                    }
                }

                lbl_output.Dispatcher.Invoke(() =>
                   lbl_output.Content = min
               );
            });
        }

        private void btn_calcola_Click(object sender, RoutedEventArgs e)
        {
            bool primo=true;
            int n = int.Parse(txt_Numero.Text);
            for(int i = 2;i<=n/2;i++)
            {
                if (n%i==0)
                {
                    primo = false;
                }
            }
             if(primo == false)
                lbl_risultatoPrimo.Content=$"il numero non è primo!";
             else
                lbl_risultatoPrimo.Content = $"il numero è primo!";
        }
    }
}



