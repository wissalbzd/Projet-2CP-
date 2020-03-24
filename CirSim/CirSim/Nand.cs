using System;
using System.Collections;
using System.Text;

namespace CirSim
{
    class Nand : PorteLogique
    {
        public Nand(int nbbit) : base(nbbit)
        { }
        public override void Evaluer()
        {
            int s = 0;
            int i = 0;
            
            bool exception = false;
            try
            {
                while (i < nbBits)
                {
                    if (entrees[i] == -1) exception = true;
                    if (entrees[i] == 0) { s = 1; break; }
                    else { i++; }
                }
                if (exception && i==nbBits) throw new EntreeNonValideException();
                else sorties[0] = s;
            }catch (EntreeNonValideException)
            {
                Console.WriteLine("erreur");
            }

        }
    }
}
