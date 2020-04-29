using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{


    class D : Bascule
    {
        public int i = 0;
        public int d;
        public D() : base(1)
        {
            entrees = new int[1];
        }

        public override void tab_TT()
        {
            tab_transition = new String[5, 4];
            tab_transition[0, 0] = "D";
            tab_transition[0, 1] = "CLK";
            tab_transition[0, 2] = "Q+";
            tab_transition[0, 3] = "Q/";
            tab_transition[1, 0] = "0";
            tab_transition[1, 1] = "0";
            tab_transition[1, 2] = "Q-";
            tab_transition[1, 3] = "(Q-/)";
            tab_transition[2, 0] = "0";
            tab_transition[2, 1] = "1";
            tab_transition[2, 2] = "0";
            tab_transition[2, 3] = "1";
            tab_transition[3, 0] = "1";
            tab_transition[3, 1] = "0";
            tab_transition[3, 2] = "Q-";
            tab_transition[3, 3] = "(Q-/)";
            tab_transition[4, 0] = "1";
            tab_transition[4, 1] = "1";
            tab_transition[4, 2] = "1";
            tab_transition[4, 3] = "0";
        }

        // Methode d'evaluation de la sortie pendant un top d'horloge
        public override void Evaluer()
        {
            if (this.Condition())
            {
                i = 0;

                d = entrees[0];
                if (mode == "EtatH" || mode == "EtatB") sorties[i] = Precedent;

                else sorties[i] = d;

                Precedent = sorties[i];
            }
            this.Complementaire();
        }

    }
}
