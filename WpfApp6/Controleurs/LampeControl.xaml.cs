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
using Projet.CirSim;
namespace Projet.Controleurs
{
    /// <summary>
    /// Interaction logic for Lampe.xaml
    /// </summary>
    public partial class LampeControl : UserControl
    {

        public Composant c;
        public bool boolsource = false, booldestinataire = false;
        Line ligne;
        public int numS_c;
        public MainWindow window;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;

        public LampeControl(MainWindow main)
        {
            InitializeComponent();
            this.window = main;
        }
        public void RelierLampe(Composant compo, int numS)
        {
            this.c = compo;
            this.numS_c = numS;
            if (c.sync)
            {
                Circuit.lampesSync.Add(this);

                Console.WriteLine("lampe avec sync");
            }
            else
            {
                Circuit.lampes.Add(this);
                Console.WriteLine("lampe non sync");
            }
        }
        public void activer()
        {
            Console.WriteLine("inside activer");
            Console.WriteLine(this.c.GetType());
            Console.WriteLine(this.c.sync);
            this.Dispatcher.Invoke(() =>
            {//this refer to form in WPF application 
                if (c.Get_sortie(numS_c) == 1)
                {
                    le_path.Fill = Brushes.Goldenrod; Console.WriteLine("inside activer turquoise");
                }
                else
                {
                    le_path.Fill = Brushes.Gray; Console.WriteLine("inside activer gris");
                }

            });

        }

        private void E_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.lampe = this;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;

        }

        private void E_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            Circuit.relationSortie(f.source, f.NumSource, this);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (E.IsMouseOver) clic = true;
            if (!clic)
            {
                m_start = e.GetPosition(window);
                m_startOffset = new Vector(tt.X, tt.Y);
                gates.CaptureMouse();
            }
            clic = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clic)
            {
                if (gates.IsMouseCaptured)
                {
                    Vector offset = Point.Subtract(e.GetPosition(window), m_start);

                    tt.X = m_startOffset.X + offset.X;
                    tt.Y = m_startOffset.Y + offset.Y;
                }
            }


        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!clic) gates.ReleaseMouseCapture();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Circuit.lampes.Contains(this)) Circuit.lampes.Remove(this);
            else Circuit.lampesSync.Remove(this);
            window.grid.Children.Remove(this);
        }
        private void Copier_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Pivoter_Click(object sender, RoutedEventArgs e)
        {
            if (vv.Angle == 0) { vv.Angle = 90; }
            else
            {
                if (vv.Angle == 90) { vv.Angle = 180; }
                else
                {
                    if (vv.Angle == 180) { vv.Angle = -90; }
                    else
                    {
                        if (vv.Angle == -90) { vv.Angle = 0; }
                    }
                    
                }
                
            }
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as MenuItem).Background = Brushes.Turquoise;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as MenuItem).Background = Brushes.Black;
        }


    }
}
