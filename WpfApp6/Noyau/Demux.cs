using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
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

                int indice = Convert.ToInt32(commande, 2);
                if (entrees[0] == -1)
                {
                    throw new EntreeNonValideException();
                }
                else
                {
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
            catch(EntreeNonValideException)
            {
                Console.WriteLine("Erreur");
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

