using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    public abstract class PorteLogique : Composant
    {
        public int[] entrees;

        public PorteLogique(int nbbit) : base(nbbit)
        {
            entrees = new int[nbbit];
            sorties = new int[1];
        }
        public override int Get_sortie(int num)
        {
            return this.sorties[num];
        }
        
        public override void Set_entrees(int numE, int val)
        {
            this.entrees[numE] = val;
        }

        public  abstract override void Evaluer();
    }

}
