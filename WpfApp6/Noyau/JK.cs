using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class JK : Bascule
    {
        //public int[] entrees;
        public int i;
        public int j, k;
        public JK() : base(4)
        {
            this.i = 0;
            entrees = new int[4];
        }
        public override void tab_TT()
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

        public override void Evaluer()
        {
            if (this.Condition() || (entrees[2] != entrees[3]))
            {
                int i = 0;
                int j = entrees[0], k = entrees[1];
                int Pr = entrees[2]; int Cl = entrees[3];


                try { if (Cl == 0 && Pr == 0) throw new EntreeNonValideException(); }
                catch (EntreeNonValideException)
                {
                    Console.WriteLine("Erreur");
                }

                if (Cl == 1 && Pr == 0)
                {
                    sorties[i] = 1; Precedent = sorties[i];
                }

                else if (Cl == 1 && Pr == 1)
                {
                    {
                        if (j == 0 && k == 0) sorties[i] = Precedent;

                        else if (j == 1 && k == 1) { if (Precedent == 1) sorties[i] = 0; else sorties[i] = 1; }

                        else if (j == 1) sorties[i] = 1; else sorties[i] = 0;
                        Precedent = sorties[i];
                    }



                    //*******************************Test**************************************************


                }
            }
            this.Complementaire();
        }

    }

}
