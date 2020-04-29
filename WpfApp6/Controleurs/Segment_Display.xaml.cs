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
        int Bit; 
        int[,] Output = new int[9, 8];
        List<StackPanel> StackList = new List<StackPanel>();
        public Segment_Display(MainWindow window,int Bit)
        {
            int C=Bit;
            this.window = window;
            InitializeComponent();
            this.Bit = Bit;
            for (int i=0; i<Bit;i++)
            {
                ColumnDefinition cln = new ColumnDefinition();
                gates.Width = Bit * 40;

                //cln.Width = ColumnDefinition.Width.Value(40);
                gates.ColumnDefinitions.Add(cln);
                huite(i,C);
               

            }
            C--;
           
            /*for (int i=1;i<Output.GetLength(2);i++)
            {
                foreach (StackPanel element in StackList)
                {

                }
            }*/
            /*for (int i = 0; i < sorties.GetLength(0); i++)
            {
                val += (int)(sorties[i] * Math.Pow(10, i));
                Console.WriteLine(val + "  sortie  "+sorties[i]);
            }*/
            //val = Int32.Parse(Convert.ToString(val, 10));
            //Console.WriteLine("************val***************" + val);

        }
        public int SetValues(int valeur)
        {
            int i = 0;
            while (i < Output.GetLength(0))
            {
                if (valeur == Output[i, 0]) return i; break;
                i++;

            }
            return i;




        }
        public StackPanel Stack()
        {
            StackPanel panel = new StackPanel();
            panel.Background = new SolidColorBrush(Colors.Gray);
            panel.HorizontalAlignment = HorizontalAlignment.Left;
            panel.VerticalAlignment = VerticalAlignment.Top;
            panel.Orientation = Orientation.Horizontal;
            panel.Height = 24;
            panel.Width = 2;
            StackList.Add(panel);
            return panel;

        }

        public void huite(int i, int C)
        {
            string NL = "Colonne" + C.ToString();
          //  List<StackPanel> "Colonne" + C.ToString() = new List<StackPanel>();
            StackPanel panel1 = Stack();
            panel1.Margin = new Thickness(2, 8, 20, 10);
            StackPanel panel2 = Stack();
            panel2.Margin = new Thickness(2, 36, 20, -20);

            /******************************************************************************************************/
            StackPanel panel3 = Stack();
            panel3.Margin = new Thickness(25, 8, 13, 10);
            StackPanel panel4 = Stack();
            panel4.Margin = new Thickness(25, 36, 13, -20);
            /********************************************************************************************************/
            StackPanel panel5 = Stack();
            panel5.RenderTransform = new RotateTransform(-90);
            panel5.Height = 20;

            panel5.Margin = new Thickness(4, 7, 20, 12);
            /* StackPanel panel6 = Stack();
             panel6.RenderTransform = new RotateTransform(-90);
             panel6.Height = 20;
             panel6.Margin = new Thickness(4, 34, 20, -20);*/

            StackPanel panel7 = Stack();
            panel7.RenderTransform = new RotateTransform(-90);
            panel7.Height = 20;
            panel7.Margin = new Thickness(4, 62, 20, -30);
            /*********************************************************************************************************/
            foreach (StackPanel element in StackList)
            {
                Grid.SetColumn(element, i);
                Grid.SetRow(element, 0);
                gates.Children.Add(element);
            }
            StackList.Clear();




        }

    }
}
