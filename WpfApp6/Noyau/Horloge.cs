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
        public bool stop = true;
        public bool etat = true;


        public void cycle()
        {

            int front = 1, et = -1;
            int i = 0;

            while (i < cy * 2)
            {
                foreach (Sequentiels element in compoattaches)
                {


                    if (element.mode == "frontM")
                    {
                        // Console.WriteLine("frontM");
                        if (front == 1) { element.Evaluer(); }
                    }
                    if (element.mode == "frontD")
                    {

                        if (front == 0) { element.Evaluer(); }
                        Console.WriteLine("frontD");
                    }
                    if (element.mode == "EtatH")
                    {
                        // Console.WriteLine("etat");
                        if (etat) { element.Evaluer(); }

                    }


                }
                System.Threading.Thread.Sleep(100);
                if (front == 1) { et = 1; etat = true; } else { et = 0; etat = false; }
                front = -1;

                foreach (Sequentiels element in compoattaches)
                {
                    if (element.mode == "EtatH")
                    {
                        // Console.WriteLine("etat");
                        if (etat) { element.Evaluer(); }

                    }
                    if (element.mode == "EtatB")
                    {
                        if (!etat) { element.Evaluer(); }
                        // Console.WriteLine("!etat");

                    }
                }
                System.Threading.Thread.Sleep(1000);
                if (et == 1) front = 0; else front = 1;
                et = -1;
                i++;
            }





        }

    }
}
