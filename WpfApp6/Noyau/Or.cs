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

    class Or : PorteLogique
    {
       
        public Or(int nbbit) : base(nbbit)
        { }
        public override Path GetPath()
        {
            Path ph = new Path();
            ph.Data = StreamGeometry.Parse("M120 1923 c0 -3 26 -38 59 -77 215 -260 322 -554 322 -881 0 -329 -108 -623 -335 -909 -16 -20 -26 -40 -22 -44 4 -4 110 -7 234 -7 197 0 242 3 340 23 224 45 439 134 614 254 110 74 290 245 393 372 86 107 205 284 205 306 0 25 -142 228 -242 345 -181 212 -349 346 -563 450 -145 71 -271 115 -420 146 -81 17 -145 22 -342 25 -134 2 -243 1 -243 -3z m385 -13 c303 -29 593 -134 825 -298 174 -123 427 -399 550 -600 l32 -52 -47 -75 c-111 -179 -315 -409 -471 -531 -249 -195 -548 -307 -889 -333 -125 -10 -306 -3 -320 11 -4 4 8 26 28 50 127 157 235 389 283 608 26 120 27 429 1 548 -49 223 -145 426 -282 597 l-56 70 53 6 c90 10 178 9 293 -1z"); ph.Height = 80;
            ph.Width = 70;
            ph.Height = 80;
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
            int s = 0;
            int i = 0 ;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {

                try
                {
                    if (entrees[i] == 1) { s = 1; trouv = true; }
                    else
                    {
                        if (entrees[i] == -1)
                        {
                            while (!trouv && i < nbBits)
                            {
                                if (entrees[i] == 1) { s = 1; trouv = true; }
                                else { i++; }
                            }

                            if (!trouv) { throw new EntreeNonValideException(); }
                        }
                        else
                        { i++; }
                    }
                   sorties[0] = s;
                }
                catch (EntreeNonValideException e)
                { e.Afficher(); }
            } 
        }


    }
}
// if (Array.Exists(this.entrees, element => element == 1))
                        //{ s = 1; trouv = true; }