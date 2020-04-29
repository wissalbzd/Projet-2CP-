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
    class LampeSubItem : SubItem
    {
        public LampeSubItem(string name):base (name)
        {

        }
        public override void Chosen(MainWindow main)
        {
            LampeControl instance = new LampeControl(main);
            //Circuit.lampes.Add(instance);
            main.grid.Children.Add(instance);
        }
    }
}
