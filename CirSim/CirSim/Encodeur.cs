﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CirSim
{
    class Encodeur : Combinatoire
    {
        // index 0 le plus faible poid
        public Encodeur(int nb_lig) : base(nb_lig)
        { }
        public override void Evaluer()
        {

            int sortie_val = Array.IndexOf(this.entrees, 1);//exception si plus d'une ligne est activ en entree;
            sorties = new int[Nb_ligne_sortie()];
            Initialiser(sorties, 0);
            int i = 0;
            while (sortie_val >= 0 && i < Nb_ligne_sortie())
            {

                sorties[i] = (sortie_val & 1) == 1 ? 1 : 0;
                i++;
                sortie_val >>= 1;

            }

        }

        private int Nb_ligne_sortie() // Calcul le nombre de bits pour la sortie
                                      // eg: pour 8bits en etrée elle retourne 3 (2^3=8)
        {
            int i = 1;
            while (Math.Pow(2, i) < entrees.Length)
            {
                i++;
            }
            return i;
        }
        private void Initialiser(int[] tab, int x)
        {
            for (int i = 0; i < tab.Length; i++)
            { tab[i] = x; }
        }
    }
}
