using System;
using System.Collections;
using Projet.Controleurs;
namespace Projet.CirSim
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
            try 
            {
                for (int i = (cmd.Length) - 1; i >= 0; i--)
                {

                    if (cmd[i] == -1)
                    {

                        throw new EntreeNonValideException();
                    }
                    else
                    {
                        commande = commande + cmd[i];
                    }
                }

                int valDecimal = Convert.ToInt32(commande, 2);
                if (entrees[valDecimal] == -1)
                {
                    throw new EntreeNonValideException();
                }
                else
                {
                    sorties[0] = entrees[valDecimal] == 1 ? 1 : 0;
                }    
            }
            catch (EntreeNonValideException)
            {
                Console.WriteLine("erreur !");
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
                this.cmd[numE - entrees.Length] = val;
            }

        }
        
    }
}
