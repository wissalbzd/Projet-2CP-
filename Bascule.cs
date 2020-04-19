using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Bascule : Sequentiels
    {
        public int[] Precedent;

        public Bascule(int nbBits) : base(nbBits)
        {
            Precedent = new int[100];
            sorties = new int[99];
        }

        public override int Get_sortie(int num)
        {
            return sorties[num];
        }



    }
}
