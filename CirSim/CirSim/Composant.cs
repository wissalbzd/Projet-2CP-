using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public abstract class Composant
    {
        public int[] entrees;
        public int[] sorties;
        public int nbBits;
        public bool evalue = false;
        public Composant(int nbBits)
        { this.nbBits = nbBits; }
        public Dictionary<int, List<Enreg>> relSortie = new Dictionary<int, List<Enreg>>();
        public Dictionary<int, Enreg> relEntree = new Dictionary<int, Enreg>();
        public abstract void Evaluer();
        public abstract int Get_sortie(int num);
        public abstract void Set_entrees(int numE, int val);
        
        
        public void Relier(int numS, Composant c, int numE)
        {
            if (this.Equals(c))
            {
                c.Set_entrees(numE, -1); 
            }
            else
            {
                Enreg enreg = new Enreg(c, numE);
                Enreg enreg2 = new Enreg(this, numS);
                c.relEntree.Add(numE, enreg2);
                if (relSortie.ContainsKey(numS))
                {
                    relSortie[numS].Add(enreg);
                }
                else
                {
                    List<Enreg> l = new List<Enreg>();
                    l.Add(enreg);
                    relSortie.Add(numS, l);
                }
            }
        }

        public void Eval()
        {
            if (!evalue)
            {
                if (this.relEntree.Count != 0)
                {
                    foreach (KeyValuePair<int, Enreg> rel in this.relEntree)
                    {

                        rel.Value.composant.Eval();
                    }
                }

                Evaluer();
                foreach (KeyValuePair<int, List<Enreg>> compSortie in relSortie)
                {
                    foreach (Enreg enreg in compSortie.Value)
                    {
                        
                        enreg.composant.Set_entrees(enreg.nEntree, this.Get_sortie(compSortie.Key));
                    }
                }
                evalue = true;

            }
        }

       
        
    }
}


