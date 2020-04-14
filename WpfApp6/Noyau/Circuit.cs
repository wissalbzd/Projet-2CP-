using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Circuit
    {
        public List<Composant> lesSorties = new List<Composant>();
        public List<LampeControl> lampes = new List<LampeControl>();
        public List<PinGraphique> pins = new List<PinGraphique>();
        public List<Composant> lesComposants = new List<Composant>();
        public Circuit() { }
        public void relationSortie(Composant c, int s, LampeControl lampe)
        {
            lampe.RelierLampe(c,s);
            if (!lesSorties.Contains(c))
            { lesSorties.Add(c); }
            lampes.Add(lampe);
        }
        public void traiter()
        {
            foreach(PinGraphique pin in pins)
            {
                pin.AffecterVal();
            }
            foreach (Composant c in lesSorties)
            { c.Eval(); }
            foreach (LampeControl l in lampes)
            { l.activer(); }

        }
    }
}
