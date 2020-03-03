using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class JK : Bascule
    {

        public JK(bool synchronise, int[] tab_entrees) : base ( synchronise, tab_entrees)
        {
            tab_transition = new String[9, 6];
            tab_transition[0, 0] = "Pr";
            tab_transition[0, 1] = "Cl";
            tab_transition[0, 2] = "H";
            tab_transition[0, 4] = "K";
            tab_transition[0, 3] = "J";
            tab_transition[0, 5] = "Q+";
            tab_transition[1, 0] = "0";
            tab_transition[1, 1] = "0";
            tab_transition[1, 2] = "X";
            tab_transition[1, 3] = "X";
            tab_transition[1, 4] = "X";
            tab_transition[1, 5] = "X";
            tab_transition[2, 0] = "0";
            tab_transition[2, 1] = "1";
            tab_transition[2, 2] = "X";
            tab_transition[2, 3] = "X";
            tab_transition[2, 4] = "X";
            tab_transition[2, 5] = "1";
            tab_transition[3, 0] = "X";
            tab_transition[3, 0] = "1";
            tab_transition[3, 1] = "0"; tab_transition[3, 2] = "X"; tab_transition[3, 3] = "X"; tab_transition[3, 4] = "X"; tab_transition[3, 5] = "0";
            tab_transition[4, 0] = "1"; tab_transition[4, 1] = "1"; tab_transition[4, 2] = "s"; tab_transition[4, 3] = "X"; tab_transition[4, 4] = "X"; tab_transition[4, 5] = "Q-";
            tab_transition[5, 0] = "1"; tab_transition[5, 1] = "1"; tab_transition[5, 2] = "D"; tab_transition[5, 3] = "0"; tab_transition[5, 4] = "0"; tab_transition[5, 5] = "Q-";
            tab_transition[6, 0] = "1"; tab_transition[6, 1] = "1"; tab_transition[6, 2] = "D"; tab_transition[6, 3] = "0"; tab_transition[6, 4] = "1"; tab_transition[6, 5] = "0";
            tab_transition[7, 0] = "1"; tab_transition[7, 1] = "1"; tab_transition[7, 2] = "D"; tab_transition[7, 3] = "1"; tab_transition[7, 4] = "0"; tab_transition[7, 5] = "1";
            tab_transition[8, 0] = "1"; tab_transition[8, 1] = "1"; tab_transition[8, 2] = "D"; tab_transition[8, 3] = "1"; tab_transition[8, 4] = "1"; tab_transition[8, 5] = "!Q";

        }
      /*  public void Affich_TT()
        {
            for (int s = 0; s < 9; s++)
            {

                for (int k = 0; k < 6; k++)
                {
                    if (tab_transition[s, k].Length != 2)
                        Console.Write("     " + tab_transition[s, k] + " ");
                    else Console.Write("     " + tab_transition[s, k]);

                    Console.Write("|");

                }
                Console.WriteLine();
            }
        }*/
        public string Evaluer(string precedent , string j, string k ,string Pr, string Cl) 
        {
            
            int c = 3;
            if (Cl == "0" && Pr == "0")  Console.WriteLine("Etat interdit");  
            else
            {
                if (Cl == "1" && Pr == "1")
                {
                    //condition horloge

                    for (int l = 4; l < 9; l++)
                    {
                        if (j == "0" && k == "0") return precedent;

                        else if (k == "1" && j == "1")
                        { if (precedent == "1") return "0"; else return "1"; }
                        else
                       if (tab_transition[l, c] == j && tab_transition[l, c + 1] == k) return tab_transition[l, c + 2];

                    }
                }
                else
                {
                    if (Cl == "1" && Pr == "0") return "1";
                    else return "0";
                }

            }
            return""; 
        }
    }
}
