using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class Non : PorteLogique
    {
        /* public Non(int nbbit) : base(nbbit)
         {
             entree = new int[1];
         }*/
        public Non() : base(1)
        {}

        public override void Evaluer()
        {
            if (entrees[0] == 0) { sorties[0] = 1; }
            else { sorties[0] = 0; }
        }
    }
}
