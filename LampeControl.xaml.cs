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
        int numS_c;
        public MainWindow window;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;
        
        public LampeControl(MainWindow main)
        {
            InitializeComponent();
            this.window = main;
        }
        public void RelierLampe(Composant compo ,int numS)
        {
            this.c = compo;
            this.numS_c = numS;
            if (c.sync)
            {
                Circuit.lampesSync.Add(this);
                Circuit.lampes.Remove(this);
            }
        }
        public void activer()
        {
            if (c.sorties[numS_c] == 1)
            {
                le_path.Fill = Brushes.Turquoise;
            }
            else
            {
                le_path.Fill = Brushes.Gray;
            }
            
        }

        private void E_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.lampe = this;
        }

        private void E_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            Circuit.relationSortie(f.source, f.NumSource, this);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (E.IsMouseOver) clic = true;
            if(!clic)
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
