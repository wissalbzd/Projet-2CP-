using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public abstract class  Sequentiels
    {
        //Horloge horloge;
       protected bool synchronise;
       protected int[] tab_sortie;
        protected String[,] tab_transition;
        protected String expression { get; }
       
            public Sequentiels(bool synchronise)
        {
            this.synchronise = synchronise;
           
        }
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

    }
}
