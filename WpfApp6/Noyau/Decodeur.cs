using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;

namespace Projet.CirSim
{

    class Decodeur : Combinatoire
    {

        public Decodeur(int nb_lig) : base(nb_lig)
        { this.entrees = new int[nbBits]; }
        public override void Evaluer()
        {
            try
            {
                int i = 0;
                int sortie_active = 0;
                while (i < entrees.Length)
                {
                    if (entrees[i] == -1)
                    {
                        throw new EntreeNonValideException();
                    }
                    else
                    {
                        sortie_active += (int)entrees[i] * (int)Math.Pow(2, i);
                        i++;
                    }
                }
                int sortie_length = (int)Math.Pow(2, entrees.Length);
                sorties = new int[sortie_length];
                Initialiser(this.sorties, 0);
                sorties[sortie_active] = 1;
            }
            catch (EntreeNonValideException e)
            { e.Afficher(); }

        }
        private void Initialiser(int[] tab, int x)
        {
            for (int i = 0; i < tab.Length; i++)
            { tab[i] = x; }
        }
        

    }
}
