using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Projet.Chronogrammes;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Horloge
    {
        public int horloge_val = 0;
        int cy = 5;
        public Chrono chrono { set; get; }
        public List<Composant> compoattaches = new List<Composant>();
        public bool stop = false;

        public int front = 1;
        public int et = -1;
        public void cycle()
        {
            while (!stop)
            {
                this.evaluation();
                System.Threading.Thread.Sleep(100);
                if (front == 1) { et = 1; horloge_val = 1; } else { et = 0; horloge_val = 0; }
                front = -1;
                this.evaluation();
                System.Threading.Thread.Sleep(1000);
                if (et == 1) { front = 0; horloge_val = 0; } else { front = 1; horloge_val = 1; }
                et = -1;
            }
        }
        public void evaluation()
        {

            foreach (Composant c in compoattaches)
            { c.evalue = false; }
            foreach (Composant element in compoattaches)
            { Console.WriteLine("compoattache eval"); element.Eval(); }
            chrono.AjoutVal(horloge_val);
            foreach (Composant element in compoattaches)
            { Console.WriteLine("compoattache eval"); element.SyncChrono(); }
            foreach (LampeControl l in Circuit.lampesSync)
            { Console.WriteLine("lampe eval first"); l.activer(); }

        }

    }
}
