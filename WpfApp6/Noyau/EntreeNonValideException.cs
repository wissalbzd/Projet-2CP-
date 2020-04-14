using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.CirSim

{
    class EntreeNonValideException : Exception
    {
        public EntreeNonValideException():base("entree non valide") { }
        public void Afficher()
        {
            Console.WriteLine("ERROR");
        }
    }
}
