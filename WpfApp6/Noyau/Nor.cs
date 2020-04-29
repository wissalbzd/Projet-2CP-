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

    class Nor : PorteLogique
    {
        

        public Nor(int nbbit) : base(nbbit)
        { }
        public override Path GetPath()
        {
            Path ph = new Path();
            ph.Data = StreamGeometry.Parse("M11 1961 c-11 -7 0 -24 51 -80 160 -173 278 -403 329 -644 29 -133 31 -360 6 -489 -47 -234 -165 -477 -321 -661 -49 -58 -54 -68 -39 -75 28 -11 298 -6 403 7 338 45 658 182 915 391 100 81 287 278 374 392 62 83 76 96 92 88 37 -20 89 -12 120 19 24 24 29 38 29 76 0 65 -39 105 -102 105 -24 0 -53 -6 -63 -14 -17 -12 -24 -6 -81 71 -134 183 -321 371 -481 487 -244 176 -549 290 -875 325 -118 13 -338 14 -357 2z m401 -26 c352 -47 683 -192 938 -414 131 -114 289 -287 379 -415 36 -52 40 -64 35 -97 -4 -23 -1 -51 6 -69 12 -29 10 -33 -61 -128 -89 -117 -276 -312 -379 -395 -265 -214 -595 -346 -962 -386 -115 -13 -295 -14 -302 -3 -3 4 13 28 34 53 108 127 215 320 270 490 90 274 86 581 -11 856 -58 163 -160 335 -274 461 l-57 62 139 0 c76 0 186 -7 245 -15z m1519 -891 c52 -55 11 -144 -66 -144 -65 0 -107 86 -67 137 35 46 94 48 133 7z");
            ph.Height = 80;
            ph.Width = 70;
            ph.Stroke = new SolidColorBrush(Colors.Black);
            ph.StrokeThickness = 1;
            ph.Stretch = Stretch.Fill;
            ph.Fill = Brushes.Black;
            Grid.SetColumn(ph, 1);
            Grid.SetRowSpan(ph, 5);
            return ph;
        }
        public override void Evaluer()
        {
            int s = 1;
            int i = 0;
            bool exception = false;
            try
            {
                while (i < nbBits) 
                {
                    if (entrees[i] == -1) { exception = true; }
                    if (entrees[i] == 1) { s = 0; break ; }
                    else { i++; }
                }
                if (exception && i==nbBits) throw new EntreeNonValideException();
                else sorties[0] = s;
            }catch (EntreeNonValideException)
            {
                Console.WriteLine("erreur");
            }
        }
    }
}
