using System;
using System.Collections.Generic;
using System.Text;

 class RST : Bascule
{
        public int i;
        public int R;
        public int S;

	public RST (){ this.i = 0;}
        
    public void tab_TT()
    {
        tab_transition = new String[9, 5];
        tab_transition[0, 0] = "Clk";
        tab_transition[0, 1] = "R";
        tab_transition[0, 2] = "S";
        tab_transition[0, 3] = "Q";
        tab_transition[0, 4] = "Q/";
        tab_transition[1, 0] = "0";
        tab_transition[1, 1] = "0";
        tab_transition[1, 2] = "0";
        tab_transition[1, 3] = "Q-";
        tab_transition[1, 4] = "(Q-)/";
        tab_transition[2, 0] = "0";
        tab_transition[2, 1] = "0";
        tab_transition[2, 2] = "1";
        tab_transition[2, 3] = "Q-";
        tab_transition[2, 4] = "(Q-)/";
        tab_transition[3, 0] = "0";
        tab_transition[3, 1] = "1";
        tab_transition[3, 2] = "0";
        tab_transition[3, 3] = "Q-";
        tab_transition[3, 4] = "(Q-)/";
        tab_transition[4, 0] = "0";
        tab_transition[4, 1] = "1";
        tab_transition[4, 2] = "1";
        tab_transition[4, 3] = "Q-";
        tab_transition[4, 4] = "(Q-)/";
        tab_transition[5, 0] = "1";
        tab_transition[5, 1] = "0";
        tab_transition[5, 2] = "0";
        tab_transition[5, 3] = "Q-";
        tab_transition[5, 4] = "(Q-)/";
        tab_transition[6, 0] = "1";
        tab_transition[6, 1] = "0";
        tab_transition[6, 2] = "1";
        tab_transition[6, 3] = "1";
        tab_transition[6, 4] = "0";
        tab_transition[7, 0] = "1";
        tab_transition[7, 1] = "1";
        tab_transition[7, 2] = "0";
        tab_transition[7, 3] = "0";
        tab_transition[7, 4] = "1";
        tab_transition[8, 0] = "1";
        tab_transition[8, 1] = "1";
        tab_transition[8, 2] = "1";
        tab_transition[8, 3] = "0";
        tab_transition[8, 4] = "0"; //Cas spésifique
    }

    public override Evaluer(bool etat)
    {
        
        if (i == 0){
        Precedent[0] = entrees[0];
        R = entrees[1];
        S = entrees[2];}
        
            
            if (H.etat == true)
            {
                sorties[i] = Precedent[i];  // Memorisation
            }
            else
            {
                if ((R == 0) && (S == 0))
                {
                    sorties[i] = Precedent[i];
                }
                if ((R == 1) && (S == 0))
                {
                    sorties[i] = 0;
                }
                if ((R == 0) && (S == 1))
                {
                    sorties[i] = 1;
                }
                if ((R == 1) && (S == 1))
                {
                    sorties[i] = 0; // Ici Q/ == 0 non pas 1 ATTENTION!!!!!!!!!
                }
            }

            i++;
            Precedent[i] = sorties[i-1];
        
    }

   /* public override int Get_sortie_R() { return num1; } 
    public override int Get_sortie_S() { return num2; }*/
    public override void Set_entrees(int numE, int val) { 
           entrees[numE] = val;
    }

}
