using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public static class Circuit
    {
        public static List<Composant> lesSorties = new List<Composant>();
        public static List<LampeControl> lampes = new List<LampeControl>();
        public static List<LampeControl> lampesSync = new List<LampeControl>();
        public static List<PinGraphique> pins = new List<PinGraphique>();
        public static List<Composant> lesComposants = new List<Composant>();
        public static Horloge Horloge
        { set; get; }
        /*public Circuit() { }*/
        public static void relationSortie(Composant c, int s, LampeControl lampe)
        {
            lampe.RelierLampe(c,s);
            if (!lesSorties.Contains(c) && !c.sync)
            { lesSorties.Add(c); }
            lampes.Add(lampe);
        }
        public static void traiter()
        {
            foreach(PinGraphique pin in pins)
            {
                pin.AffecterVal();
            }
            foreach (Composant c in lesSorties)
            { c.Eval(); }
            foreach (LampeControl l in lampes)
            {
                if (l.c.sync)
                {
                    lampes.Remove(l);
                    lampesSync.Add(l);
                }
                else
                {
                    l.activer();
                }
            }
            Horloge.cycle();
            // hna pour chaque compo dans lampeSync  compo.Eval 
           //et hna on allume les lampes reliées au compoSync 

        }
    }
}
