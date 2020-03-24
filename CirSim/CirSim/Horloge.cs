using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public class Horloge
    {
        int cy = 10;
        public List<Sequentiels> compoattaches = new List<Sequentiels>();
        public bool stop = true;
        public void cycle() 
        {
            bool front = true,etat=true;
            int i = 0;
            while (i<cy)
            {
                if (front) foreach (Sequentiels element in compoattaches) element.Evaluer();
                System.Threading.Thread.Sleep(1000);
                front = false;
                // Console.WriteLine("front descendant");
                etat = !etat;
                System.Threading.Thread.Sleep(1000);
                front = true;
                i++;
            }
        }

    }
}
