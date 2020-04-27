using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;

namespace Projet.CirSim
{
    class ADC : Combinatoire
    {
        
        public int[] entrees2;
        public int Re=0;
        public int Rs;
        

        public ADC(int n) : base(n)
        {
            entrees = new int[n];
            entrees2 = new int[n];
            sorties = new int[n];
        }
        public override void Evaluer()
        {
            int i = 0; int val = 0;
            int r = this.Re;
            while (i < this.entrees.Length)
            {

                val = entrees2[i] + entrees[i] + r;
                this.sorties[i] = val % 2;
                r = val / 2;
                i++;


            }
            this.Rs = r;

        }
    
        public  override int Get_sortie(int num)
        {
            if(num==entrees.Length)
            {
                return this.Rs;
            }
            else
            {
                return this.sorties[num];
            }
        }
        
        public override void Set_entrees(int numE, int val)
        {
            if (numE < entrees.Length)
            {
                this.entrees[numE] = val;
            }
            else if (numE >= entrees.Length && numE < 2 * entrees.Length)
            {
                this.entrees2[numE - entrees.Length] = val;
            }
            else
            {
                this.Re = val;
            }

        }

    }
}
