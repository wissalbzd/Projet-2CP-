using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.Controleurs;

namespace Projet.CirSim
{

    public class Wire
    {
        public Composant source = null;
        public Composant destination = null;
        public int NumSource;
        public int NumDest;
        public PinGraphique pin = null;
        public LampeControl lampe = null;
        public Horloge h;
        public Fil fil;
        public Wire()
        {
            this.fil = new Fil();
        }
    }
}
