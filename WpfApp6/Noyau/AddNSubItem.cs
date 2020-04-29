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
    class AddNSubItem : SubItem
    {
        public AddNSubItem(string name) : base(name)
        {

        }
        public override void Chosen(MainWindow main)
        {
            InputDialogSample inputDialog = new InputDialogSample();
            if (inputDialog.ShowDialog() == true)
            {

                Additionneur instance = new Additionneur(inputDialog.nb, main);
                Circuit.lesComposants.Add(instance.addi);
                main.grid.Children.Add(instance);

            }
        }
    }
}