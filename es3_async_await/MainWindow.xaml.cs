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

            Task<int> t1 = Task.Factory.StartNew(() => TrovaMultipli(a),
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
                );
        }

        public int TrovaMultipli(int n)
        {
            int multipli = 0;
            for (int c = 0; c < 200000000; c++)
            {
                if (c % n == 0)
                {
                    multipli++;
                }
                if (c % 2000000 == 0)
                {
                    pbr_Progress.Dispatcher.Invoke(() =>
                    {
                        pbr_Progress.Value++;
                    });
                }
            }
            lbl_output.Dispatcher.Invoke(() =>
            {
                lbl_output.Content = multipli;
            });
            return multipli;
        }
    }
}
