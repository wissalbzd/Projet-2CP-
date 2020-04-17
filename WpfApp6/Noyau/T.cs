using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    class T : Bascule
    {
        public int i;
        public  int t ;
        public T() : base(1)
        {
            tab_transition = new String[3, 2];
            this.i = 0;
        }
        public override  void tab_TT() 
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

         
            t = entrees[1];
            Precedent[0] = entrees[0];


            if (t == 0) sorties[i] = Precedent[i];
            else if (Precedent[i] == 1) sorties[i] = 0; else sorties[i] = 1; 
            Precedent[i + 1] = sorties[i];

           
            //******************************Test********************************* if (T == 0) T = 1; else T = 0;
            this.i=this.i+1;
        
    }

       
      
    }
}
