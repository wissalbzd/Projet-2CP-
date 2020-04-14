using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Bascule : Sequentiels
    {
        public int[] Precedent;

        public Bascule(int nbBits) : base(nbBits) {
            Precedent = new int[6];
            sorties = new int[5];
        }
        
       
       
    }
}
