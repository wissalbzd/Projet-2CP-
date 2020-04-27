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
using System.Windows.Threading;
using Projet.CirSim;
namespace Projet.Controleurs
{
    /// <summary>
    /// Logique d'interaction pour Segment_Display.xaml
    /// </summary>
    public partial class Segment_Display : UserControl
    {

        Sequentiels composant;
        MainWindow window;
        public Segment_Display(MainWindow window)
        {
            int val=0;
            InitializeComponent();
            int[] sorties = new int[] {1,0,0,0 };
            this.window = window; this.composant = composant;
            for (int i = 0; i < sorties.GetLength(0); i++)
            {
                //val += (int) (composant.sorties[i] * Math.Pow(10, i));
                val += (int)(sorties[i] * Math.Pow(10, i));
                Console.WriteLine(val + "  sortie  "+sorties[i]);
            }
            //val = Int32.Parse(Convert.ToString(val, 10));
            Console.WriteLine("************val***************" + val);

        }
        public void SetValues(int Output)
        {
            if (Output == 0)
            {

            }
            else
            {

            }
        }
        public void init()
        {
            StackPanel l1 = huite();
            l1.HorizontalAlignment = HorizontalAlignment.Center;
            gates.Children.Add(l1);

        }
        public StackPanel huite()
        {
            StackPanel panel = new StackPanel();
            panel.Background= new SolidColorBrush(Colors.Gray);
            panel.HorizontalAlignment = HorizontalAlignment.Left;
            panel.VerticalAlignment = VerticalAlignment.Top;
            panel.Orientation = Orientation.Horizontal;
            panel.Height = 25;
            panel.Width = 2;
            
            return panel;
        }

    }
}
