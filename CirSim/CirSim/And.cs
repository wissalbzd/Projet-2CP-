using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class And : PorteLogique
    {
        public And(int nbBits) : base(nbBits)
        { }

        public override void Evaluer()
        { 
            int s = 1;
            int i = 0;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {
                
                if (entrees[i] == 0) { s = 0; trouv = true; }
                else { i++; }
            }
            sorties[0] = s;
        }
    }
}
