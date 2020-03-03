using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public abstract class Combinatoire : Composant
    {
        public int[] entrees;
        public Combinatoire(int nbBits):base(nbBits)
        {  }

    }
}
