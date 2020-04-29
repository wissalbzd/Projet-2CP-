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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet.Chronogrammes
{
    /// <summary>
    /// Interaction logic for ChronosWindow.xaml
    /// </summary>
    public partial class ChronosWindow : Window
    {
        List<Chrono> lesChronogrammes = new List<Chrono>();
        bool paused = false;
        Path triangle = new Path();
        Path Rec = new Path();

        public ChronosWindow()
        {
            InitializeComponent();
            //triangle.Data = StreamGeometry.Parse("M32840 10359 c0 -5168 1 -5431 18 -5426 26 7 9386 5414 9389 5424 3 7 - 9385 5433 - 9400 5433 - 4 0 - 7 - 2444 - 7 - 5431z m4488 2359 c2231 - 1287 4062 - 2346 4069 - 2352 10 - 9 - 3157 - 1845 - 7934 - 4598 l - 203 - 117 0 4704 c0 2588 2 4705 5 4705 3 0 1831 - 1054 4063 - 2342z ");
            //Rec.Data= StreamGeometry.Parse("M1490 6135 l0 -4955 1470 0 1470 0 0 4955 0 4955 -1470 0 -1470 0 0 - 4955z m2520 0 l0 - 4535 - 1050 0 - 1050 0 0 4535 0 4535 1050 0 1050 0 0 - 4535z");
            //Rec.Margin = new Thickness(454.5, 6.5, 40.5, 0);
            //Rec.Width = 5;
            //triangle.Width = 16;
            this.Closing += ChronosWindow_Closing;
        }

        private void ChronosWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void AddChrono(Chrono chrono)
        {
            lesChronogrammes.Add(chrono);
            lesChronos.Children.Add(chrono);

        }
        public void ActiverChrono()
        {
            foreach (Chrono chrono in lesChronogrammes)
            {
                chrono.Activate();
            }

        }
        public void PauseChrono()
        {
            foreach (Chrono chrono in lesChronogrammes)
            {
                chrono.Pause();
            }
        }

        private void Hide_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void Pause_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!paused) { PauseChrono(); paused = true; pause.Content = "Paused"; pause.Background = Brushes.Red; }
            else
            {
                ActiverChrono(); paused = false; pause.Content = "Pause"; pause.Background = Brushes.Turquoise;
            }

        }

        private void pause_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
