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

    public class Non : PorteLogique
    {
        /* public Non(int nbbit) : base(nbbit)
         {
             entree = new int[1];
         }*/
        
        public Non() : base(1)
        {}
        public override Path GetPath()
        {
            return null;
        }


        public override void Evaluer()
        {
            try
            {
                if (entrees[0] == -1)
                {
                    throw new EntreeNonValideException();
                }
                else
                {
                    if (entrees[0] == 0) { sorties[0] = 1; }
                    else { sorties[0] = 0; }
                }
            }
            catch (EntreeNonValideException e)
            { e.Afficher(); }
        }
    }
}
