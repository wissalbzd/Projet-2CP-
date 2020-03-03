using System;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    public class Demux : Combinatoire
    {
        
        public int[] cmd;

        public Demux(int nbBits) : base(nbBits)
        {
            cmd = new int[nbBits];
            double n = Math.Pow(2, nbBits);
            sorties = new int[(int)n];
            entrees = new int[1];
        }

        public override void Evaluer()
        {
            String commande = "";
            foreach (int i in cmd)
            {
                commande = commande + i.ToString();
            }
            int indice = Convert.ToInt32(commande, 2);
            int val = (int)entrees[0];

            for (int i = 0; i < Math.Pow(2, nbBits); i++)
            {
                if (i == indice)
                    sorties[indice] = val == 1 ? 1 : 0;
                else
                    sorties[i] = val == 1 ? 0 : 1;

            }
        }
    }
}

