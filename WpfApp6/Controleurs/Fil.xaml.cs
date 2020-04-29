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
using Projet.Controleurs;

namespace Projet.Controleurs
{
    /// <summary>
    /// Logique d'interaction pour Fil.xaml
    /// </summary>
    public partial class Fil : UserControl
    {
        public MainWindow window;
        public Fil()
        {
            InitializeComponent();
        }
        public Point source, destination;

        public Line DrawLine()

        {
                Line ln = new Line();
            /* ln.X1 = this.source.X;

             ln.Y1 = this.source.Y;

             ln.X2 = this.destination.X;

             ln.Y2 = this.source.Y;*/
            ln.X1 = this.source.X;

            ln.Y1 = this.source.Y;

            ln.X2 = this.destination.X;

            ln.Y2 = this.destination.Y;
            ln.Stroke = Brushes.Black;
                
                return ln;

            

        }
        public void DrawLigne(Line l1, Line l2)

        {


             Line l = new Line();

            Line ln = new Line();
            ln.X1 = this.source.X;

            ln.Y1 = this.source.Y;

            ln.X2 = this.destination.X;

            ln.Y2 = this.source.Y;

            ln.Stroke = Brushes.Black;

            l.X1 = this.destination.X;
                l.Y1 = this.source.Y;
                l.X2 = this.destination.X;
                l.Y2 = this.destination.Y;
            l.Stroke = Brushes.Red;

            l1 = ln; l2 = l;
            
            
        }

    }
}