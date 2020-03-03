using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class Nand : PorteLogique
    {
        public Nand(int nbbit) : base(nbbit)
        { }
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
