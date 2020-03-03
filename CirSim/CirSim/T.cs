using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class T : Bascule
    {
        public T(bool synchronise, int[] tab_entrees) : base(synchronise, tab_entrees)
        {
            tab_transition = new String[3, 2];

            tab_transition[0, 0] = "T";
            tab_transition[0, 1] = "Q";
            tab_transition[1, 0] = "0";
            tab_transition[1, 1] = "Q";
            tab_transition[2, 0] = "1";
            tab_transition[2, 1] = "!Q";
        }
        public string Evaluer(string T,string Q)
        {
            if (T == "0") return Q; else if (Q == "0") return "1"; else return "0";
            
        }
    }
}
