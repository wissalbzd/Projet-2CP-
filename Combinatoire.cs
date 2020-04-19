using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Combinatoire : Composant
    {
        //public int[] entrees;
        public Combinatoire(int nbBits):base(nbBits)
        {  }
        public override int Get_sortie(int num)
        {
            return this.sorties[num];
        }

        public override void Set_entrees(int numE, int val)
        {
            this.entrees[numE] = val;
        }

    }
}
