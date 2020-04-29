using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Bascule : Sequentiels
    {
        public int Precedent;

        public Bascule(int nbBits) : base(nbBits)
        {

            sorties = new int[2];
        }

        public override int Get_sortie(int num)
        {
            return sorties[num];
        }
        public void Complementaire()
        {
            if (sorties[0] == 1) sorties[1] = 0; else sorties[1] = 1;
        }


    }
}
