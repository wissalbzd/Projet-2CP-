using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    class T : Bascule
    {
        //public int[] entrees;
        public int i;
        public int t;

        public T() : base(1)
        {
            ; entrees = new int[1];
            tab_transition = new String[3, 2];
            i = 0;
        }
        public override void tab_TT()
        {

            tab_transition[0, 0] = "T";
            tab_transition[0, 1] = "Q";
            tab_transition[1, 0] = "0";
            tab_transition[1, 1] = "Q";
            tab_transition[2, 0] = "1";
            tab_transition[2, 1] = "!Q";
        }

        public override void Evaluer()
        {
            if (this.Condition())
            {
                int i = 0;
                int t = entrees[0];



                if (t == 0) sorties[i] = Precedent;
                else if (Precedent == 1) sorties[i] = 0; else sorties[i] = 1;
                Precedent = sorties[i];
                this.Complementaire();

            }

            //******************************Test********************************* if (T == 0) T = 1; else T = 0;
            //this.i=this.i+1;

        }



    }
}
