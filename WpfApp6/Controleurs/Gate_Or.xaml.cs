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
using Projet.Controleurs;
namespace Projet.Controleurs
{
    /// <summary>
    /// Interaction logic for Gate_Or.xaml
    /// </summary>
    public partial class Gate_Or : UserControl
    {
        public PorteLogique composant;
        public MainWindow window;
        bool clic = false;

        Point m_start;
        Vector m_startOffset;
        List<Ellipse> etr = new List<Ellipse>();
        public Gate_Or(int NbE, Type type, MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            composant = (PorteLogique)Activator.CreateInstance(type, NbE);
            Path ph = composant.GetPath();
            gates.Children.Add(ph);
            if (type == typeof(XOR))
            { sortie.Margin = new Thickness(-5, 0, 0, 0); }
            Ellipse E;

            switch (NbE)
            {
                case 2:

                    E = entree();
                    E.Name = "e0";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);
                    break;

                case 3:
                    E = entree();
                    E.Name = "e0";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);


                    E = entree();
                    E.Name = "e1";
                    E.Margin = new Thickness(0, 0, -16, 0);
                    Grid.SetRow(E, 2);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e2";
                    Grid.SetRow(E, 3);
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);
                    break;

                case 4:

                    E = entree();
                    E.Margin = new Thickness(0, 0, -7, 0);  // 0 2 4
                    E.Name = "e0";
                    Grid.SetRow(E, 0);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e2";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e3";
                    if (type == typeof(XOR))
                    { E.Margin = new Thickness(0, 0, -8, 0); }
                    else { E.Margin = new Thickness(0, 0, -6, 0); }
                    Grid.SetRow(E, 4);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);
                    break;

                case 5:
                    E = entree();
                    E.Name = "e1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e3";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);

                    E = entree();
                    E.Name = "e0";
                    E.Margin = new Thickness(0, 0, -7, 0);
                    Grid.SetRow(E, 0);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);


                    E = entree();
                    E.Name = "e4";
                    if (type == typeof(XOR))
                    {
                        E.Margin = new Thickness(0, 0, -8, 0); // 0 1 2 3 4
                    }
                    else
                    {
                        E.Margin = new Thickness(0, 0, -6, 0);
                    }
                    Grid.SetRow(E, 4);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);


                    E = entree();
                    E.Name = "e2";
                    E.Margin = new Thickness(0, 0, -16, 0);
                    Grid.SetRow(E, 2);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    gates.Children.Add(E);
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
            return E;
        }


        public bool boolsource = false, booldestinataire = false;
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

        Line ligne;
        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.composant;
            f.NumSource = 0;
            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            // else relier avec la lampe 

            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            Line l1 = new Line(), l2 = new Line();
            //ligne = window.filActif.fil.DrawLigne(l2,l1);
            window.filActif.fil.DrawLigne(l2, l1);
            this.window.grid.Children.Add(l1);

            this.window.grid.Children.Add(l2);

            booldestinataire = true;
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
            if (boolsource == true)
            {
                window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
                ligne = window.filActif.fil.DrawLine();
                this.window.grid.Children.Add(ligne);
            }
            if (booldestinataire == true)
            {
                window.filActif.fil.source = e.GetPosition(this.window.grid);
                ligne = window.filActif.fil.DrawLine();
                this.window.grid.Children.Add(ligne);
            }
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
