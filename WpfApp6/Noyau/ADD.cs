using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;

namespace Projet.CirSim
{

    class ADD : Combinatoire
    {
        public int r = 0;
        public int[] entrees2;

        public ADD(int nbBits) : base(nbBits)
        {
            entrees = new int[nbBits];
            entrees2 = new int[nbBits];
            sorties = new int[nbBits];

        }

        public override void Evaluer()
        {
            try
            {
                for (int i = 0; i < nbBits; i++)
                {
                    if (entrees[i] == -1 || entrees[i] == -1) throw new EntreeNonValideException();
                    int s = entrees[i] + entrees2[i] + this.r;
                    sorties[i] = s % 2;
                    this.r = s / 2;
                }
            }
            catch(EntreeNonValideException)
            {
                Console.WriteLine("erreur");
            }
        }

        public  override int Get_sortie(int num)
        {
            if (num == entrees.Length)
            {
                return this.r;
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
            else
            {
                this.entrees2[numE - entrees.Length] = val;
            }

        }
    }
}
