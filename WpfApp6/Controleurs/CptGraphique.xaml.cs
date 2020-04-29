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
    /// Logique d'interaction pour Compteur.xaml
    /// </summary>
    public partial class CptGraphique : UserControl
    {
        public MainWindow window;
        public Compteur compteur;
        bool clic = false;
        int modulo;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        List<Ellipse> etr = new List<Ellipse>();
        public CptGraphique(string mode, int modulo,string typeC,int val, MainWindow window)
        {
            InitializeComponent();

            this.window = window;
            compteur = new Compteur();
            compteur.Set_Propriete(typeC, modulo);
            compteur.set_Mode(mode);
            compteur.setDebutComptage(val);
            this.modulo = compteur.modulo;
            if (compteur.Nb_ligne_sortie() >8 )
            {
                gates.Height = compteur.Nb_ligne_sortie() * 8;
                Cpt.Height = gates.Height;
            }
           
            if (compteur.type=="bit")
             {

                for (int i = 0; i < compteur.Nb_ligne_sortie(); i++)
                {
                    RowDefinition row = new RowDefinition();
                    gates.RowDefinitions.Add(row);
                    Ellipse E = entree();
                    etr.Add(E);
                    E.Name = "e" + i.ToString();
                    Grid.SetRow(E, i);
                    Grid.SetColumn(E, 2);
                    gates.Children.Add(E);
                }
                Grid.SetRowSpan(Cpt, compteur.modulo);
                Grid.SetRow(H, compteur.Nb_ligne_sortie()/2);


            }
            else
             {

             }
           

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
            E.MouseDown += sortie_MouseDown;
            E.MouseUp += sortie_MouseUp;
            E.Cursor = Cursors.Hand;
            return E;
        }
        private void sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i;
            window.filActif = new Wire();
            Ellipse el = sender as Ellipse;
            String nom = el.Name;
            if (nom.Length<2)  i = Convert.ToInt32(nom[1]); else i= Int32.Parse(nom.Substring(1));
            window.filActif.NumSource = i;
            Console.WriteLine("sortie  " + i + "  Down ");
            window.filActif.source = this.compteur;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;


        }

        private void sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            f.source = this.compteur;
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
           
            window.filActif.destination = this.compteur;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
        }

        private void HorlogeUP(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
           
               
                    
                    if (window.filActif.h == null)
                    {
                        compteur.Aff_Valid(window.filActif.source, window.filActif.NumSource);
                        Console.WriteLine("aff valid");
                    }
                    else
                    {
                        window.filActif.h.compoattaches.Add(this.compteur); Console.WriteLine("compoattaches");
                    }
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
    }
}
