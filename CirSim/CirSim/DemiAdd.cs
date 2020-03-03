using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class DemiAdd : Combinatoire
    {
        public int r = 0;
        public int[] entrees2;

        public DemiAdd(int nbBits) : base(nbBits)
        {
            entrees = new int[nbBits];
            entrees2 = new int[nbBits];
            sorties = new int[nbBits];

        }

        public override void Evaluer()
        {
            for (int i = 0; i < nbBits; i++)
            {
                int s = entrees[i] + entrees2[i] + this.r;
                sorties[i] = s % 2;
                this.r = s / 2;
            }
        }
    }
}
