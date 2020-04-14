using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class  Sequentiels : Composant
    {
        
        public static String[,] tab_transition { get; set; }
        Horloge h;

        protected Sequentiels(int nbBits) : base (nbBits) { }
        
        public void Clock(Horloge h) { this.h = h; h.compoattaches.Add (this);  }
        public  abstract  void tab_TT();
        public void chronogramme(int[] tab_transition) { }
        public void Affich_TT()
        {
            for (int s = 0; s < tab_transition.GetLength(0); s++)
            {

                for (int k = 0; k < tab_transition.GetLength(1); k++)
                {
                    if (tab_transition[s, k].Length != 2)
                        Console.Write("     " + tab_transition[s, k] + " ");
                    else Console.Write("     " + tab_transition[s, k]);

                    Console.Write("|");

                }
                Console.WriteLine();
            }
        }
        public abstract override int Get_sortie(int num);
        public abstract override void Set_entrees(int numE, int val);
    }
}
