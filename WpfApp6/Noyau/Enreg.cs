using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Enreg
    {
        public Composant composant;
        public int nEntree;

        public Enreg(Composant composant, int nEntree)
        {
            this.composant = composant;
            this.nEntree = nEntree;
        }
    }
}
