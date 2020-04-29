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
    /// Interaction logic for Additionneur.xaml
    /// </summary>
    public partial class Additionneur : UserControl
    {
        public MainWindow window;
        public Combinatoire addi;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        List<Ellipse> entr = new List<Ellipse>();
        List<Ellipse> sort = new List<Ellipse>();
        public Additionneur(Type type, MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            addi = (Combinatoire)Activator.CreateInstance(type, 1);
            if (addi.GetType() == typeof(ADD))
            { createADD(2, 2); le_name.Text = "ADD"; Grid.SetColumnSpan(le_name, 2); }
            else
            { createADD(3, 2); le_name.Text = "ADC"; Grid.SetColumnSpan(le_name, 2); Grid.SetColumn(le_name, 1); }


        }
        public Additionneur(int nbE, MainWindow main)
        {
            InitializeComponent();
            this.window = main;
            addi = (Combinatoire)Activator.CreateInstance(typeof(ADD), nbE);
            createADD(nbE * 2, nbE + 1);
            Grid.SetColumnSpan(le_name, nbE);
            Grid.SetColumn(le_name, nbE - 1);
            le_name.Text = "ADD_" + nbE.ToString() + "bits";


        }
        public Ellipse creerEllipse(int numRow, int numCol, string name)
        {
            Ellipse E = new Ellipse();
            Grid.SetColumn(E, numCol);
            Grid.SetRow(E, numRow);
            E.Stroke = Brushes.Black;
            E.StrokeThickness = 4;
            E.HorizontalAlignment = HorizontalAlignment.Right;
            E.VerticalAlignment = VerticalAlignment.Center;
            E.Cursor = Cursors.Hand;
            /*TextBox nom = new TextBox();
            nom.Text = name;
            Grid.SetColumn(nom,numCol);
            if(numRow==0)Grid.SetRow(nom,2);
            else { Grid.SetRow(nom, 3); }*/
            return E;
        }
        public void createADD(int numE, int numS)
        {

            Ellipse e; string nom;
            int i; int j = 0;
            int maximum = Math.Max(numE, numS) + 1;
            for (i = 0; i < maximum + 1; i++)
            { adder.ColumnDefinitions.Add(new ColumnDefinition()); }
            rectangle.Width = (maximum + 1) * 20;
            rectangle.Height = numS * 15;
            adder.Width = rectangle.Width + 10;
            adder.Height = rectangle.Height + 10;
            Grid.SetColumnSpan(rectangle, maximum + 1);
            Console.WriteLine(Math.Max(numE, numS));
            for (i = 0; i < numE + 1; i++)
            {
                if (addi.GetType() == typeof(ADC) && i == numE - 1) { nom = "RetenueEntrante"; }
                nom = "E" + j.ToString();
                if ((i == (numE - (numE % 2)) / 2))
                { i++; j = 0; }

                e = creerEllipse(0, i, nom);
                e.MouseDown += entree_MouseDown;
                e.MouseUp += entree_MouseUp;
                adder.Children.Add(e);
                entr.Add(e);
                j++;
            }
            for (i = 0; i < numS; i++)
            {
                nom = "S" + i.ToString();
                if (i == numS - 1) { i++; nom = "Retenue"; }
                e = creerEllipse(4, i, nom);
                e.MouseDown += sortie_MouseDown;
                e.MouseUp += sortie_MouseUp;
                sort.Add(e);
                adder.Children.Add(e);
            }

        }
        private void entree_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            Ellipse el = sender as Ellipse;
            window.filActif.NumDest = entr.IndexOf(el);
            window.filActif.destination = this.addi;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }
        private void entree_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            Ellipse el = sender as Ellipse;
            window.filActif.NumDest = entr.IndexOf(el);
            f.destination = this.addi;
            if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else f.pin.relierP(f.destination, f.NumDest);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

            booldestinataire = true;
        }
        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse el = sender as Ellipse;
            window.filActif = new Wire();
            window.filActif.source = this.addi;
            window.filActif.NumSource = sort.IndexOf(el);
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }
        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Ellipse el = sender as Ellipse;
            Wire f = window.filActif;
            f.source = this.addi;
            f.NumSource = sort.IndexOf(el);
            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else { Circuit.relationSortie(f.source, f.NumSource, f.lampe); }
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

            booldestinataire = true;
        }





        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Ellipse E in entr) if (E.IsMouseOver) clic = true;
            foreach (Ellipse E in sort) if (E.IsMouseOver) clic = true;
            if (!clic)
            {
                m_start = e.GetPosition(window);
                m_startOffset = new Vector(tt.X, tt.Y);
                adder.CaptureMouse();
            }
            clic = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clic)
            {
                if (adder.IsMouseCaptured)
                {
                    Vector offset = Point.Subtract(e.GetPosition(window), m_start);

                    tt.X = m_startOffset.X + offset.X;
                    tt.Y = m_startOffset.Y + offset.Y;
                }
            }

        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!clic) adder.ReleaseMouseCapture();
        }


    }
}
