using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet;
using Projet.CirSim;
using Projet.Controleurs;

namespace BeautySolutions.View.ViewModel
{
    class ClockSubItem : SubItem
    {
        public ClockSubItem(string name) : base(name)
        {

        }
        public override void Chosen(MainWindow main)
        {
            ClockControl instance = new ClockControl(main);
           // Circuit.lampes.Add(instance);
            main.grid.Children.Add(instance);
        }
    }
}
