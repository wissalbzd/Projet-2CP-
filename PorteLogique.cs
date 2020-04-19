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

    public abstract class PorteLogique : Composant
    {
        
        public PorteLogique(int nbbit) : base(nbbit)
        {
           // graphique = new Gate(nbBits);
            entrees = new int[nbbit];
            sorties = new int[1];
        }
        public abstract Path GetPath();
        public override int Get_sortie(int num)
        {
            return this.sorties[num];
        }
        
        public override void Set_entrees(int numE, int val)
        {
            this.entrees[numE] = val;
        }

        public  abstract override void Evaluer();
    }

}
