using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public class Bascule : Sequentiels
    {
        protected int[] tab_entrees { get; set; }

        public Bascule(bool synchronise, int[] tab_entrees) : base(synchronise)
        {
            this.tab_entrees = tab_entrees;
        }
       
    }
}
