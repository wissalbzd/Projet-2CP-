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
    /// Interaction logic for MUX.xaml
    /// </summary>
    public partial class MUX : UserControl
    {
        public Combinatoire composant;
        public MainWindow window;
        bool clic = false;
        bool fin = false;
        Point m_start;
        Vector m_startOffset;
        List<Ellipse> etr = new List<Ellipse>();
        public MUX(int NbE, Type type, MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            composant = (Combinatoire)Activator.CreateInstance(type, NbE);
            // Path ph = composant.GetPath();
            // main.grid.Children.Add(ph);
            Ellipse E;


            switch (NbE)
            {
                /*case 2:

                    E = entree();
                    E.Name = "E0";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 5);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "cmd";
                    E.Height = 250;
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 0);
                    Grid.SetColumn(E, 1);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    border.Child = new TextBlock() { Text = "MUX \n 2-1" };
                    break;*/

                case 4:
                    E = entree();
                    E.Name = "E0";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E2";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 5);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);


                    E = entree();
                    E.Name = "E3";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 7);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);


                    E = entree();
                    E.Name = "cmd1";
                    E.Height = 250;
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 0);
                    Grid.SetColumn(E, 1);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "cmd2";
                    E.Height = 250;
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 0);
                    Grid.SetColumn(E, 2);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    border.Child = new TextBlock() { Text = "MUX \n 4-1" };
                    break;

                case 8:

                    E = entree();
                    E.Margin = new Thickness(0, 0, -7, 0);  // 0 2 4
                    E.Name = "E0";
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E1";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 2);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E2";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 3);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E3";
                    Grid.SetRow(E, 4);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);


                    E = entree();
                    E.Margin = new Thickness(0, 0, -7, 0);  // 0 2 4
                    E.Name = "E4";
                    Grid.SetRow(E, 5);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E5";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 6);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E6";
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 7);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "E7";
                    Grid.SetRow(E, 8);
                    Grid.SetColumn(E, 0);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "cmd1";
                    E.Height = 250;
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 1);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "cmd2";
                    E.Height = 250;
                    E.Margin = new Thickness(0, 0, -14, 0);
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 2);
                    etr.Add(E);
                    combitoires.Children.Add(E);

                    E = entree();
                    E.Name = "cmd3";
                    E.Height = 250;
                    Grid.SetRow(E, 1);
                    Grid.SetColumn(E, 3);
                    etr.Add(E);
                    combitoires.Children.Add(E);
                    break;

                case 2:
                    for (int i = 0; i < 16; i++)
                    {
                        rectangle.Height = 200;
                        combitoires.Height = 300;
                        E = entree();
                        string name = "e";
                        name += i;
                        E.Name = name;
                        Grid.SetRow(E, i + 1);
                        Grid.SetColumn(E, 0);
                        etr.Add(E);
                        combitoires.Children.Add(E);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        E = entree();
                        string name = "cmd";
                        name += i + 1;
                        E.Name = name;
                        E.Height = 150;
                        Grid.SetRow(E, 1);
                        Grid.SetColumn(E, i + 1);
                        etr.Add(E);
                        combitoires.Children.Add(E);
                    }

                    break;


            }
            etr.Add(S);
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
                case "e5":
                    window.filActif.NumDest = 5;
                    break;
                case "e6":
                    window.filActif.NumDest = 6;
                    break;
                case "e7":
                    window.filActif.NumDest = 7;
                    break;
            }
            window.filActif.destination = this.composant;
        }

        private void entree_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Ellipse E = new Ellipse();
            fin = true;
            Wire f = window.filActif;
            Ellipse el = sender as Ellipse;
            //el.Stroke = System.Windows.Media.Brushes.Yellow;
            String nom = el.Name;
            E.Stroke = System.Windows.Media.Brushes.Red;
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
                case "e5":
                    f.NumDest = 5;
                    break;
                case "e6":
                    f.NumDest = 6;
                    break;
                case "e7":
                    f.NumDest = 7;
                    break;
            }
            f.destination = composant;
            if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else f.pin.relierP(f.destination, f.NumDest);

        }
        FrameworkElement obj1 = null;
        Line ln = null;
        bool isDown;
        Point pt = new Point();
        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.source = this.composant;
            window.filActif.NumSource = 0;

            foreach (FrameworkElement item in this.window.grid.Children)
            {
                obj1 = item;
                obj1.Focus();
            }
            if (obj1 != null)
            {
                isDown = true;
                ln = new Line();
                ln.MouseMove += sortie_MouseMouve;
                ln.Stroke = Brushes.Red;
                ln.StrokeThickness = 2.0;

                //point origine et dest centre par rapport à l'image
                ln.X1 = Mouse.GetPosition(obj1).X;
                ln.Y1 = Mouse.GetPosition(obj1).Y;
                ln.X2 = Mouse.GetPosition(obj1).X;
                ln.Y2 = Mouse.GetPosition(obj1).Y;


                //on l'ajoute à canvas =>sinon on le voit pas
                //quitte à l'enlever si on ne clique pas bouton droit 
                this.window.grid.Children.Add(ln);
            }
        }

        private void sortie_MouseMouve(object sender, MouseEventArgs e)
        {
            if (isDown && e.LeftButton == MouseButtonState.Pressed)//boutton gauche presse?
            {
                pt = e.GetPosition(this.window.grid);
                // l'user promene sa souris sur le canvas

                ln.X2 = Mouse.GetPosition(window).X;
                ln.Y2 = Mouse.GetPosition(window).Y;

            }
        }

        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.composant;
            f.NumSource = 0;
            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            // else relier avec la lampe 
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Ellipse E in etr) if (E.IsMouseOver) clic = true;
            if (!clic)
            {
                m_start = e.GetPosition(window);
                m_startOffset = new Vector(tt.X, tt.Y);
                combitoires.CaptureMouse();

            }
            clic = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clic)
            {
                if (combitoires.IsMouseCaptured)
                {
                    Vector offset = Point.Subtract(e.GetPosition(window), m_start);

                    tt.X = m_startOffset.X + offset.X;
                    tt.Y = m_startOffset.Y + offset.Y;


                }
            }
            if (isDown && e.LeftButton == MouseButtonState.Pressed)//boutton gauche presse?
            {
                if (!fin)
                {
                    pt = e.GetPosition(this.window.grid);
                    // l'user promene sa souris sur le canvas

                    pt.X = ln.X1;
                    pt.Y = ln.Y1;

                }
            }
        }



        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!clic) combitoires.ReleaseMouseCapture();
        }
        int cpt = 0;

        Point spt, ept;
        private void cnv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)

        {
            spt = e.GetPosition(cnv);

        }

        private void cnv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)

        {

            //ept = e.GetPosition(cnv);

            //DrawLine(spt, ept);

        }



        private void cnv_MouseMove(object sender, MouseEventArgs e)

        {


            if ((e.LeftButton == MouseButtonState.Pressed))

            {

                ept = e.GetPosition(cnv);

            }

            DrawLine(spt, ept);


        }

        void DrawLine(Point spt, Point ept)

        {

            Line link = new Line();

            link.X1 = spt.X;

            link.Y1 = spt.Y;

            link.X2 = ept.X;

            link.Y2 = ept.Y;

            link.Stroke = Brushes.Black;

            //if (cnv.Children.Contains(link) == true)

            //{

            cnv.Children.Clear();

            //}

            cnv.Children.Add(link);

        }

    }

}