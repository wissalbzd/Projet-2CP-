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
    /// Logique d'interaction pour NotControl.xaml
    /// </summary>
    public partial class NotControl : UserControl
    {
        public Non composant;
        public MainWindow window;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        bool clic=false;
        List<Ellipse> etr = new List<Ellipse>();
        public NotControl(MainWindow main)
        {
            composant = new Non();

            InitializeComponent();
            etr.Add(E);
            etr.Add(S);
            this.window = main;
        }

        private void entree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.destination = this.composant;
            window.filActif.NumDest = 0;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }

        private void entree_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.NumDest = 0;
            f.destination = composant;
            if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else f.pin.relierP(f.destination, f.NumDest);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);
        }

        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.source = this.composant;
            window.filActif.NumSource = 0;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }

        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.composant;
            f.NumSource = 0;
            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            // else relier avec la lampe
            else Circuit.relationSortie(f.source, f.NumSource, f.lampe);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);
        }
       
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Ellipse E in etr) if (E.IsMouseOver) clic = true;
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
            Console.WriteLine("Move");

            if (gates.IsMouseCaptured)
            {
                Console.WriteLine("hi");
                Vector offset = Point.Subtract(e.GetPosition(window), m_start);

                tt.X = m_startOffset.X + offset.X;
                tt.Y = m_startOffset.Y + offset.Y;
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Up");

            gates.ReleaseMouseCapture();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            composant.Supprimer();
            window.grid.Children.Remove(this);
        }
        private void Copier_Click(object sender, RoutedEventArgs e)
        {

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