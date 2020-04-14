using Projet;
using Projet.Controleurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySolutions.View.ViewModel
{
    class PinSubItem:SubItem
    {
        public PinSubItem(string name) : base(name)
        {

        }
        public override void Chosen(MainWindow main)
        {
            PinGraphique instance = new PinGraphique(main);
            main.circuit.pins.Add(instance);
            main.grid.Children.Add(instance);
        }
    }
}
