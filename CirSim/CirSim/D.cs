using System;
using System.Collections.Generic;
using System.Text;

 class D : Bascule
{
        public int i;
        public int d;	
        public D() : base(5) { this.i = 0; }

    public void tab_TT()
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
    public override void Evaluer(bool etat)
    {
        
        if (i == 0){
        Precedent[0] = entrees[0];
        d = entrees[1];
        }
        


        
            if (H.etat == true)
            {
                sorties[i] = Precedent[i];
            }
            else
            {
                if (d == 0)
                {
                    sorties[i] = 0;
                }
                if (d == 1)
                {
                    sorties[i] = 1;
                }
            }

            i++;
            Precedent[i] = sorties[i-1];

        }

    }

    public override int Get_sortie() { return num; }
    public override void Set_entrees(int numE, int val) { 
           entrees[numE] = val;
    }
}
