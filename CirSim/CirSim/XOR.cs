using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class XOR : PorteLogique
    {
        public XOR(int nbbit) : base(nbbit)
        { this.entrees = new int[nbbit]; }
        public override void Evaluer()
        {
            int cpt = 0;
            
            for (int i = 0; i < nbBits; i++)
            {
                
                if (entrees[i] == 1) { cpt++; }
            }
            if (cpt % 2 == 0) { sorties[0] = 0; }
            else { sorties[0] = 1; }
        }
    }
}
