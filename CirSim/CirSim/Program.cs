using System;
using System.Collections.Generic;
namespace CirSim
{
    class Program
    {
        static void Main(string[] args)
        {
            /* int[] entrées1 = new int[5] { 1, 0, 0, 1, 1 };
             int[] entrées2 =  new int[5] { 1, 1,1,1,1 };

             JK jk = new JK();
             jk.entrees = entrées1;

             JK t = new JK();
             t.entrees = entrées2;
             Horloge h = new Horloge();
             t.tab_TT();
             // foreach (string element in T.tab_transition) { Console.WriteLine( element); }
             jk.Clock(h);
             t.Clock(h);
             h.cycle();
             Console.WriteLine("Sortie T");
             for (int j = 0; j < t.sorties.GetLength(0); j++) { Console.WriteLine("Precedent : " + t.Precedent[j] + "  | sortie   :   " + t.sorties[j]); }
             Console.WriteLine("\n\nSortie jk \n");
             for (int j = 0; j < t.sorties.GetLength(0); j++) { Console.WriteLine("Precedent : " + jk.Precedent[j] + "  | sortie   :   " + jk.sorties[j]); }
             */
            Horloge h = new Horloge();
            Compteur cpt = new Compteur(8);
            cpt.Clock(h);
            h.cycle();
            for (int j = 0; j < cpt.sorties.GetLength(0); j++) { Console.WriteLine( " | sortie   :   " + cpt.sorties[j]); }




        }
    }
}


