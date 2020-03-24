using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class Or : PorteLogique
    {

        public Or(int nbbit) : base(nbbit)
        {
            // int[] sorties = new int[1];

            entrees = new int[nbbit];
          

        }
        public override void Evaluer()
        {
            int s = 0;
            int i = 0 ;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {

                try
                {
                    if (entrees[i] == 1) { s = 1; trouv = true; }
                    else
                    {
                        if (entrees[i] == -1)
                        {
                            while (!trouv && i < nbBits)
                            {
                                if (entrees[i] == 1) { s = 1; trouv = true; }
                                else { i++; }
                            }

                            if (!trouv) { throw new EntreeNonValideException(); }
                        }
                        else
                        { i++; }
                    }
                   sorties[0] = s;
                }
                catch (EntreeNonValideException e)
                { e.Afficher(); }
            } 
        }


    }
}
// if (Array.Exists(this.entrees, element => element == 1))
                        //{ s = 1; trouv = true; }