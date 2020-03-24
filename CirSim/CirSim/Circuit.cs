using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class Circuit
    {
        public List<Composant> lesSorties = new List<Composant>();
        public List<Lampe> lampes = new List<Lampe>();
        public List<Composant> lesComposants = new List<Composant>();
        public Circuit() { }
        public void relationSortie(Composant c, int s, Lampe lampe)
        {
            lampe.RelierLampe(s, c);
            if (!lesSorties.Contains(c))
            { lesSorties.Add(c); }
            lampes.Add(lampe);
        }
        public void traiter()
        {
            foreach (Composant c in lesSorties)
            { c.Eval(); }
        }
    }
}
