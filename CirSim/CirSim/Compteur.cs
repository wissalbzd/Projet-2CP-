using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class Compteur : Sequentiels
    {
        int validation = 1;
        int i,modulo;
        int[] Q;
           public Compteur(int modulo) : base(1) { this.i = 0; this.modulo = modulo; sorties = new int[modulo]; }
        public override void tab_TT()
        { }
        public override void Evaluer()
        {

            if (i < modulo - 1)
            {
                this.i++;
                sorties[i] = Int32.Parse(Convert.ToString(i, 2));
            }
            else this.i = 0;
        }
        public void Decompo(int i)
        {

        }
        public override int Get_sortie(int num) { return num; }
        public override void Set_entrees(int numE, int val) { }
    }
}
