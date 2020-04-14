using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Projet.Controleurs;
namespace Projet.CirSim
{


    public class Nand : PorteLogique
    {
        public Nand(int nbbit) : base(nbbit)
        { }
        public override Path GetPath()
        {
            Path ph = new Path();
            ph.Data = StreamGeometry.Parse("M0 1453 l0 -1456 193 6 c665 23 1263 160 1741 399 372 186 632 419 761 681 25 50 53 124 62 162 10 39 18 71 19 73 1 2 21 -6 45 -18 89 -46 203 -11 244 76 24 50 17 139 -14 182 -49 69 -153 92 -232 51 -23 -11 -42 -19 -43 -17 -1 2 -9 35 -19 73 -9 39 -37 112 -62 162 -254 517 -1037 920 -2025 1042 -186 23 -438 41 -577 41 l-93 0 0 -1457z m375 1387 c1060 -77 1925 -458 2237 -985 284 -479 39 -994 -652 -1373 -430 -235 -1095 -396 -1728 -419 l-182 -6 0 1396 0 1397 93 0 c50 0 155 -5 232 -10z m2611 -1304 c29 -29 34 -41 34 -81 0 -40 -5 -52 -34 -81 -29 -29 -41 -34 -81 -34 -40 0 -52 5 -81 34 -29 29 -34 41 -34 81 0 40 5 52 34 81 29 29 41 34 81 34 40 0 52 -5 81 -34z");
            ph.Stroke = Brushes.Black;
            ph.Height = 80;
            ph.Width = 70;
            ph.StrokeThickness = 1;
            ph.Stretch = Stretch.Fill;
            ph.Fill = Brushes.Black;
            Grid.SetColumn(ph, 1);
            Grid.SetRowSpan(ph, 5);
            return ph;
        }
        public override void Evaluer()
        {
            int s = 0;
            int i = 0;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {

                if (entrees[i] == 0) { s = 1; trouv = true; }
                else { i++; }
            }
            sorties[0] = s;
        }
    }
}
