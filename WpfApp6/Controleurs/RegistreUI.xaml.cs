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
    /// Logique d'interaction pour RegistreUI.xaml
    /// </summary>
    public partial class RegistreUI : UserControl
    {
        public MainWindow window;
        public Registre registre;
        bool clic = false;
        Point m_start;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        Vector m_startOffset;
        List<Ellipse> etr = new List<Ellipse>();
        public RegistreUI(string mode, string type, string decalage, int nbBit,MainWindow window)
        {
            InitializeComponent();
            etr.Add(H);
            this.window = window;
            registre = new Registre(nbBit);
            registre.set_Proprietes(type, decalage);
            registre.set_Mode(mode);
            if (registre.nbBits>8)
            {
                gates.Width = registre.nbBits * 8;
                Reg.Width = gates.Width - 5;
            }
           
            for (int i = 1; i <= registre.nbBits; i++)
            {
                ColumnDefinition row = new ColumnDefinition();
                gates.ColumnDefinitions.Add(row);
                Ellipse S = entree();
                Ellipse E = entree();
                etr.Add(E); etr.Add(S);
                E.Name = "e" + i.ToString(); S.Name = "s" + i.ToString();
                Grid.SetRow(E, 0);
                Grid.SetColumn(E, i);
                gates.Children.Add(E);
                Grid.SetRow(S, 2);
                Grid.SetColumn(S, i);
                gates.Children.Add(S);
                E.MouseDown += entree_MouseDown;
                E.MouseUp += entree_MouseUp;
                S.MouseDown += sortie_MouseDown;
                S.MouseUp += sortie_MouseUp;
            }
            Grid.SetColumnSpan(Reg, registre.nbBits+1);

        }
        public Ellipse entree()
        {
            Ellipse E = new Ellipse();
            E.Stroke = System.Windows.Media.Brushes.Black;
            E.StrokeThickness = 4;
            E.Width = 5;
            E.Height = 5;
            E.HorizontalAlignment = HorizontalAlignment.Right;
            E.VerticalAlignment = VerticalAlignment.Center;
            E.Cursor = Cursors.Hand;
            return E;
        }
        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i;
            window.filActif = new Wire();
            Ellipse el = sender as Ellipse;
            String nom = el.Name;
            if (nom.Length < 2) i = Convert.ToInt32(nom[1]); else i = Int32.Parse(nom.Substring(1));
            window.filActif.NumSource = i;
            Console.WriteLine("sortie  " + i + "  Down ");
            window.filActif.source = this.registre;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;




        }

        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.registre;
            int i;
            Ellipse el = sender as Ellipse;
            String nom = el.Name;
            if (nom.Length < 2) i = Convert.ToInt32(nom[1]); else i = Int32.Parse(nom.Substring(1));

            f.NumSource = i;

            if (f.destination != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }

            else Circuit.relationSortie(f.source, f.NumSource, f.lampe);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);


        }
        private void HorlogeDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            Ellipse el = sender as Ellipse;
            //el.Stroke = System.Windows.Media.Brushes.Yellow;

            window.filActif.destination = this.registre;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;

            Console.WriteLine("mouse Down entrée");

        }

        private void HorlogeUP(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;



            if (window.filActif.h == null)
            {
                registre.Aff_Valid(window.filActif.source, window.filActif.NumSource);
                Console.WriteLine("aff valid");
            }
            else
            {
                window.filActif.h.compoattaches.Add(this.registre); Console.WriteLine("compoattaches");
            }
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);


        }
        private void entree_MouseDown(object sender, MouseButtonEventArgs e)
        {


            int i;
            Ellipse el = sender as Ellipse;
            String nom = el.Name;
            window.filActif = new Wire();
            if (nom.Length < 2) i = Convert.ToInt32(nom[1]); else i = Int32.Parse(nom.Substring(1));
            Console.WriteLine("entree  " + i + "  Down ");

            window.filActif.NumDest = i;
            window.filActif.destination = this.registre;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;


        }

        private void entree_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("entree up");
            Wire f = window.filActif;
            int i;
            Ellipse el = sender as Ellipse;
            String nom = el.Name;
            /********************************************************************************************************/
            if (nom.Length < 2) i = Convert.ToInt32(nom[1]); else i = Int32.Parse(nom.Substring(1));
            f.NumDest = i;

            f.destination =this.registre;
            if (f.source != null) { f.source.Relier(f.NumSource, f.destination, f.NumDest); }
            else f.pin.relierP(f.destination, f.NumDest);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);

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
        }
    }
}
