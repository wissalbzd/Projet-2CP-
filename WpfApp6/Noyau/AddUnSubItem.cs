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
    class AddUnSubItem : SubItem
    {
        public Type type;
        public AddUnSubItem(string name, Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            Additionneur instance = new Additionneur(this.type, main);
            Circuit.lesComposants.Add(instance.addi);
            main.grid.Children.Add(instance);

        }
    }
}