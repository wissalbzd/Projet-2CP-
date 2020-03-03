using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    abstract class PorteLogique : Composant
    {
        public int[] entrees;

        public PorteLogique(int nbbit) : base(nbbit)
        {
            entrees = new int[nbbit];
            sorties = new int[1];
            //int[] sorties = new int[1];
            //    sorties[0] = 1;

            
        }
        
        public  abstract override void Evaluer();
    }

}
