using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    public class And : PorteLogique
    {
        public And(int nbBits) : base(nbBits)
        { }

        public override void Evaluer()
        {
            int s = 1;
            int i = 0;
            bool trouv = false;
            while ((i < nbBits) && (!trouv))
            {
                try
                {
                    if (entrees[i] == 0) { s = 0; trouv = true; }
                    else
                    {
                        if (entrees[i] == -1)
                        {
                            while (!trouv && i < nbBits)
                            {
                                if (entrees[i] == 0) { s = 0; trouv = true; }
                                else { i++; }
                            }

                            if (!trouv) { throw new EntreeNonValideException(); }
                        }
                        else
                        { i++; }
                    }
                    sorties[0] = s;
                }
                catch(EntreeNonValideException e) 
                { e.Afficher(); }
            }

        }
    }

}
    
//if (Array.Exists(this.entrees, element => element == 0))
                       // { s = 0; trouv = true; }
                        //else we throw an exception