using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class Lampe
    {
        Composant c;
        int numS_c;
        protected bool etat;
        public Lampe()
        { }
        public void RelierLampe(int numS, Composant compo)
        {
            this.c = compo;
            this.numS_c = numS;
        }
        public void Colorer()
        { }

    }
}
