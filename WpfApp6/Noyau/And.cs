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
    public class And : PorteLogique
    {
        public And(int nbBits) : base(nbBits)
        { }
        public override Path GetPath()
        {
            Path ph = new Path();
            ph.Data = StreamGeometry.Parse("M 15,12 v 40 h 15 a 2,2 1 0 0 0,-40 h -15");
            ph.Stroke = Brushes.Black;
            ph.Height = 80;
            ph.Width = 70;
            ph.StrokeThickness = 1;
            ph.Stretch = Stretch.Fill;
            Grid.SetColumn(ph, 1);
            Grid.SetRowSpan(ph, 5);
            return ph;
        }
        public override void Evaluer()
        {
            int s = 1;
            int i = 0;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {
                try
                {
                    if (entrees[i] == 0) { s = 0; trouv = true; }
                    else
                    {
                        if (entrees[i] == -1)
                        {
                            while (!trouv && i < nbBits)
                            {
                                if (entrees[i] == 0) { s = 0; trouv = true; }
                                else { i++; }
                            }

                            if (!trouv) { throw new EntreeNonValideException(); }
                        }
                        else
                        { i++; }
                    }
                    sorties[0] = s;
                }
                catch(EntreeNonValideException e) 
                { e.Afficher(); }
            }

        }
    }

}
    
//if (Array.Exists(this.entrees, element => element == 0))
                       // { s = 0; trouv = true; }
                        //else we throw an exception