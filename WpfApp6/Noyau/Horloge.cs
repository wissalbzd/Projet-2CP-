using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Horloge
    {

        int cy = 5;
        public List<Sequentiels> compoattaches = new List<Sequentiels>();
        public List<Composant> compoSync = new List<Composant>();
        public bool stop = false;
        public bool etat = true;
        public int front = 1;

        public void cycle()
        {

            int et = -1;
            int i = 0;

            while (!stop)
            {
                foreach (Composant c in compoSync )
                { c.evalue = false; }
                foreach (Composant c in compoattaches)
                { c.evalue = false; }
                foreach (Sequentiels element in compoattaches)
                {element.Eval();}
                foreach (Composant c in this.compoSync)
                {c.Eval();}
                foreach(LampeControl l in Circuit.lampesSync)
                {l.activer();}


                System.Threading.Thread.Sleep(100);
                if (front == 1) { et = 1; etat = true; } else { et = 0; etat = false; }

                foreach (Composant c in compoSync)
                { c.evalue = false; }
                foreach (Composant c in compoattaches)
                { c.evalue = false; }
                foreach (Sequentiels element in compoattaches)
                {element.Eval();}
                foreach(Composant c in this.compoSync)
                {c.Eval();}
                foreach (LampeControl l in Circuit.lampesSync)
                {l.activer();}


                System.Threading.Thread.Sleep(1000);
                if (et == 1) front = 0; else front = 1;
                et = -1;
               

            }





        }
    }
}
