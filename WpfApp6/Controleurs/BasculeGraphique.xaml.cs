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
    /// Logique d'interaction pour BasculeGraphique.xaml
    /// </summary>
    public partial class BasculeGraphique : UserControl
    {
        public Bascule composant;
        public MainWindow window;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        List<Ellipse> etr = new List<Ellipse>();
        Ellipse E0, E1, E2;
        Label L1, L2, H, L0;
       
        public BasculeGraphique(Type type,string Mode, MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            composant = (Bascule)Activator.CreateInstance(type);
            composant.set_Mode(Mode);
            /*******************************************************Ellipse***************************************************/
            E0 = entree();
            E0.Name = "e0";
            Grid.SetRow(E0, 0);
            Grid.SetColumn(E0, 0);
            gates.Children.Add(E0);
            etr.Add(E0);
            E1 = entree();
            Grid.SetRow(E1, 2);
            Grid.SetColumn(E1, 0);
            gates.Children.Add(E1);
            etr.Add(E1);
            /****************************************************************Label******************************************/
            L0 = Set_Label();
            Grid.SetRow(L0, 0);
            Grid.SetColumn(L0, 1);
            gates.Children.Add(L0);

            L1 = Set_Label();
            Grid.SetRow(L1, 2);
            Grid.SetColumn(L1, 1);
            gates.Children.Add(L1);

            H = Set_Label();
            H.Content = "H";
            Grid.SetColumn(H, 1);
            gates.Children.Add(H);
            Ellipse h = entree();
            h.Name = "H";
            etr.Add(h);
            Grid.SetColumn(h, 0);
            gates.Children.Add(h);

            if (type == typeof(JK) || type == typeof(RST))
            {
                /******************************************************Horloge*******************************************/
                Grid.SetRow(H, 1);
                Grid.SetRow(h, 1);

                /******************************************************Ellipse************************************************/


                if (type == typeof(JK))
                {
                    /******************************************************Ellipse*********************************************/
                    Ellipse E2 = entree();
                    E2.Name = "e2";
                    E2.VerticalAlignment = VerticalAlignment.Top;
                    E2.Margin = new Thickness(3, -3, 50, 9);
                    Grid.SetRow(E2, 0);
                    Grid.SetColumn(E2, 1);
                    gates.Children.Add(E2);
                    etr.Add(E2);
                    Ellipse E3 = entree();
                    E3.Name = "e3";
                    E3.VerticalAlignment = VerticalAlignment.Top;
                    E3.Margin = new Thickness(12, -3, 20, 10);
                    Grid.SetRow(E3, 0);
                    Grid.SetColumn(E3, 1);
                    gates.Children.Add(E3);
                    etr.Add(E3);

                    /*****************************************Label***************************************************/
                    L0.Content = "J"; L1.Content = "K";
                    Label L2 = Set_Label();
                    L2.Content = "Pr";
                    L2.Margin = new Thickness(14, 0, 10, 0);
                    Grid.SetRow(L2, 0);
                    Grid.SetColumn(L2, 1);
                    gates.Children.Add(L2);

                    Label L3 = Set_Label();
                    L3.Content = "Clr";
                    L3.Margin = new Thickness(35, 0, 10, 0);
                    Grid.SetRow(L3, 0);
                    Grid.SetColumn(L3, 1);
                    gates.Children.Add(L3);


                }
                else
                {
                    L0.Content = "R"; L1.Content = "S";

                }

            }
            else
            {

                /******************************************************Horloge*******************************************/
                Grid.SetRow(H, 2);
                Grid.SetRow(h, 2);


                if (type == typeof(D))
                {
                    L0.Content = "D";
                }
                else L0.Content = "T";
            }
            etr.Add(S1); etr.Add(S2);
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
        public Label Set_Label()
        {
            Label L = new Label();
            L.HorizontalContentAlignment = HorizontalAlignment.Left;
            return L;
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
                case "H":
                    window.filActif.destination = this.composant;
                    Console.WriteLine("mouse Down entrée");
                    break;
            }
            if (nom != "H") window.filActif.destination = this.composant;
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
                case "H":
                    Console.WriteLine("mouse Up entree");
                    if (window.filActif.h == null)
                    {
                        composant.Aff_Valid(window.filActif.source, window.filActif.NumSource);
                        Console.WriteLine("aff valid");
                    }
                    else
                    {
                        window.filActif.h.compoattaches.Add(this.composant); Console.WriteLine("compoattaches");
                    }
                    break;
            }

            if (nom != "H")
            {
                f.destination = composant; Console.WriteLine("!h");
                if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }

                else f.pin.relierP(f.destination, f.NumDest);

            }
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

            booldestinataire = true;

        }

        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.source = this.composant;
            if (S1.IsMouseOver) window.filActif.NumSource = 0; else window.filActif.NumSource = 1;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }

        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.composant;
            if (S1.IsMouseOver) f.NumSource = 0; else f.NumSource = 1;
            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }

            else Circuit.relationSortie(f.source, f.NumSource, f.lampe);
            window.filActif.source = this.composant;
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
