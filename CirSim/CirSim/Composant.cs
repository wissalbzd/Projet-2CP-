using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public abstract class Composant

    {
        public int[] sorties ;
        public int nbBits;
        public Composant (int nbBits)
        { this.nbBits = nbBits; }
        Dictionary<int, List<Enreg>> relation = new Dictionary<int, List<Enreg>>();
         public abstract void Evaluer();
        public void Relier(int numS, Composant c, int numE)
        {
            Enreg enreg = new Enreg(c, numE);
            if (relation.ContainsKey(numS))
            {
                relation[numS].Add(enreg);
            }
            else
            {
                List<Enreg> l = new List<Enreg>();
                l.Add(enreg);
                relation.Add(numS, l);
            }

        }
    }
}
