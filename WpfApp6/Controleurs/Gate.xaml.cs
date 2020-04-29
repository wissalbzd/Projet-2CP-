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
    /// Logique d'interaction pour test.xaml
    /// </summary>
        /* graphique = new Gate(nbbit, "Nor");

        Grid.SetColumn(ph, 1);
        Grid.SetRowSpan(ph, 5);
        graphique.gates.Children.Add(ph);*/


public partial class Gate : UserControl
{
    public PorteLogique composant;
        public MainWindow window;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        List<Ellipse> etr = new List<Ellipse>();
        public bool boolsource = false, booldestinataire = false;

        public Gate(int NbE,Type type,MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            composant = (PorteLogique)Activator.CreateInstance(type, NbE);
            Path ph = composant.GetPath();
            gates.Children.Add(ph);
            Ellipse E0, E1, E2, E3, E4;


            switch (NbE)
            {
                case 2:
                    E0 = entree();
                    E0.Name = "e0";
                    Grid.SetRow(E0, 1);
                    Grid.SetColumn(E0, 0);
                    gates.Children.Add(E0);
                    E1 = entree();
                    E1.Name = "e1";
                    Grid.SetRow(E1, 3);
                    Grid.SetColumn(E1, 0);
                    gates.Children.Add(E1);
                    etr.Add(E0); etr.Add(E1);
                    break;
                case 3:
                    E0 = entree();
                    E0.Name = "e0";
                    Grid.SetRow(E0, 1);
                    Grid.SetColumn(E0, 0);
                    gates.Children.Add(E0);
                    E1 = entree();
                    E1.Name = "e1";
                    Grid.SetRow(E1, 2);
                    Grid.SetColumn(E1, 0);
                    gates.Children.Add(E1);
                    E2 = entree();
                    E2.Name = "e2";
                    etr.Add(E0); etr.Add(E1); etr.Add(E2);
                    Grid.SetRow(E2, 3);
                    Grid.SetColumn(E2, 0);
                    gates.Children.Add(E2);

                    break;
                case 4:
                    E0 = entree();

                    Grid.SetRow(E0, 1);
                    Grid.SetColumn(E0, 0);
                    gates.Children.Add(E0);
                    E1 = entree();

                    Grid.SetRow(E1, 0);
                    Grid.SetColumn(E1, 0);
                    gates.Children.Add(E1);
                    E2 = entree();

                    Grid.SetRow(E2, 3);
                    Grid.SetColumn(E2, 0);
                    gates.Children.Add(E2);
                    E3 = entree();

                    Grid.SetRow(E3, 4);
                    Grid.SetColumn(E3, 0);
                    gates.Children.Add(E3);
                    E0.Name = "e0"; E1.Name = "e1"; E2.Name = "e2"; E3.Name = "e3";
                    etr.Add(E0); etr.Add(E1); etr.Add(E2); etr.Add(E3);
                    break;
                case 5:
                    E0 = entree();

                    Grid.SetRow(E0, 0);
                    Grid.SetColumn(E0, 0);
                    gates.Children.Add(E0);
                    E1 = entree();

                    Grid.SetRow(E1, 1);
                    Grid.SetColumn(E1, 0);
                    gates.Children.Add(E1);
                    E2 = entree();

                    Grid.SetRow(E2, 2);
                    Grid.SetColumn(E2, 0);
                    gates.Children.Add(E2);
                    E3 = entree();

                    Grid.SetRow(E3, 3);
                    Grid.SetColumn(E3, 0);
                    gates.Children.Add(E3);
                    E4 = entree();

                    Grid.SetRow(E4, 4);
                    Grid.SetColumn(E0, 0);
                    gates.Children.Add(E4);
                    etr.Add(E0); etr.Add(E1); etr.Add(E2); etr.Add(E3); etr.Add(E4);
                    E0.Name = "e0"; E1.Name = "e1"; E2.Name = "e2"; E3.Name = "e3"; E4.Name = "e4";

                    break;
            }

            etr.Add(sortie);
            
        }
      


        public Ellipse entree()
        {
            Ellipse E = new Ellipse();
            E.Stroke = System.Windows.Media.Brushes.Black;
            E.StrokeThickness = 4;
            E.HorizontalAlignment = HorizontalAlignment.Right;
            E.VerticalAlignment = VerticalAlignment.Center;
            E.MouseDown += entree_MouseDown;
            E.MouseUp += entree_MouseUp;
            E.Cursor = Cursors.Hand;
            return E;
        }

        private void entree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            Ellipse el = sender as Ellipse;
            //el.Stroke = System.Windows.Media.Brushes.Yellow;
            String nom = el.Name;
            switch (nom)
            {
                case "e0":
                    window.filActif.NumDest = 0;
                    break;
                case "e1":
                    window.filActif.NumDest = 1;
                    break;
                case "e2":
                    window.filActif.NumDest = 2;
                    break;
                case "e3":
                    window.filActif.NumDest = 3;
                    break;
                case "e4":
                    window.filActif.NumDest = 4;
                    break;
            }
            window.filActif.destination = this.composant;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }

        private void entree_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            Ellipse el = sender as Ellipse;
            //el.Stroke = System.Windows.Media.Brushes.Yellow;
            String nom = el.Name;
            switch (nom)
            {
                case "e0":
                    f.NumDest = 0;
                    break;
                case "e1":
                    f.NumDest = 1;
                    break;
                case "e2":
                    f.NumDest = 2;
                    break;
                case "e3":
                    f.NumDest = 3;
                    break;
                case "e4":
                    f.NumDest = 4;
                    break;
            }
            f.destination = composant;
            if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else f.pin.relierP(f.destination, f.NumDest);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);


            booldestinataire = true;

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
             else 
            Circuit.relationSortie(f.source, f.NumSource, f.lampe);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

            booldestinataire = true;
        }
        private void first_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
           (sender as Ellipse).Stroke = Brushes.Turquoise;
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
            composant.Supprimer();
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
