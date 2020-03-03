using System;
using System.Collections;

namespace CirSim
{
    public class Mux : Combinatoire
    {
        public int[] cmd;
        public Mux(int nbBits) : base(nbBits)
        {
            cmd = new int[nbBits];
            double n = Math.Pow(2, nbBits);
            entrees = new int[(int)n];
            sorties = new int[1];
        }

        public override void Evaluer()
        {
            String commande = "";
            foreach (int i in cmd)
            {
                commande = commande + i.ToString();
            }

            int valDecimal = Convert.ToInt32(commande, 2);

            sorties[0] = entrees[valDecimal] == 1 ? 1 : 0;
        }
    }
}
