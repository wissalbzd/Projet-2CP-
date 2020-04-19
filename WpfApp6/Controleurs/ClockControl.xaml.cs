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
    /// Logique d'interaction pour Clock.xaml
    /// </summary>
    public partial class ClockControl : UserControl
    {
        public MainWindow window;
        public Horloge horloge;
    
        Point m_start;
        Vector m_startOffset;
        
        public ClockControl(MainWindow main)
        {
            InitializeComponent();
            this.window = main;
        }

        private void Sortie_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            horloge.compoattaches.Add((Sequentiels)f.source);
        }

        private void Sortie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.h = this.horloge;
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
         
            if (!sortie.IsMouseOver)


            {
                m_start = e.GetPosition(window);
                m_startOffset = new Vector(tt.X, tt.Y);
                gates.CaptureMouse();
            }
         
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!sortie.IsMouseOver)
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
            if (!sortie.IsMouseOver) gates.ReleaseMouseCapture();
        }

    }
}
