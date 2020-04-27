using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
using System.Threading;
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
            
        }
        public static void traiter()
        {
            for (int i = lampes.Count - 1; i >= 0; i--)
            {
                if (lampes[i].c.sync)
                {
                    lampesSync.Add(lampes[i]);
                    lampes.RemoveAt(i);
                }
            }
            foreach (PinGraphique pin in pins)
            {
                pin.AffecterVal();
            }
            foreach (Composant c in lesComposants)
            { 
                c.Eval();
            }
            foreach (LampeControl l in lampes)
            {
              
                    l.activer();
               
            }
            Console.WriteLine("*********************//****/*******");
            
            // hna pour chaque compo dans lampeSync  compo.Eval 
           //et hna on allume les lampes reliées au compoSync 

        }
    }
}
