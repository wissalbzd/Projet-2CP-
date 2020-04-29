using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Combinatoire : Composant
    {
        //public int[] entrees;
        public Combinatoire(int nbBits):base(nbBits)
        {  }
        public override int Get_sortie(int num)
        {
            return this.sorties[num];
        }

        public override void Set_entrees(int numE, int val)
        {
            this.entrees[numE] = val;
        }


	 public void Supprimer()
        {
            foreach (KeyValuePair<int, Enreg> p in relEntree)
            {
                Composant cp = p.Value.composant;
                int ns = p.Value.nEntree;
                if (cp.relSortie.ContainsKey(ns))
                {
                    if (cp.relSortie[ns].Count == 1) { cp.relSortie.Remove(ns); Console.WriteLine("/////// supression////////"); }
                    else
                    {
                        Enreg enreg = new Enreg(this, p.Key);
                        cp.relSortie[ns].Remove(enreg);
                    }
                }
            }
            foreach (KeyValuePair<int, List<Enreg>> p in relSortie)
            {
                foreach (Enreg enreg in p.Value)
                {
                    if (enreg.composant.relEntree.ContainsKey(enreg.nEntree)) { enreg.composant.relEntree.Remove(enreg.nEntree); }
                }
            }
            if (sync) Circuit.Horloge.compoattaches.Remove(this);
            else Circuit.lesComposants.Remove(this);
        }
    }
}
