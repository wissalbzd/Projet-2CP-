using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Horloge
    {

        int cy = 5;
       
        public List<Composant> compoattaches = new List<Composant>();
        public bool stop = false;
        public bool etat = true;
        public int front = 1;

        public void cycle()
        {

            int et = -1;
            int i = 0;

            while (!stop)
            {


                this.evaluation();
                System.Threading.Thread.Sleep(100);
                if (front == 1) { et = 1; etat = true; } else { et = 0; etat = false; }
                front = -1;
                this.evaluation();
                System.Threading.Thread.Sleep(1000);
                if (et == 1) front = 0; else front = 1;
                et = -1;
                i++;

            }
        }
        public void evaluation()
        {
            
            foreach (Composant c in compoattaches)
            { c.evalue = false; }
            foreach (Composant element in compoattaches)
            { Console.WriteLine("compoattache eval"); if (element.sorties == null) Console.WriteLine(" null :'(   "); element.Eval(); for (int i = 0; i < element.sorties.GetLength(0); i++) Console.WriteLine("sortie " + i + "   de l'element :" + element.sorties[i]);  }
            
            foreach (LampeControl l in Circuit.lampesSync)
            { Console.WriteLine("lampe eval first"); l.activer(); }

        }
       
    }
}
