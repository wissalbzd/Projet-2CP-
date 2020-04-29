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

    class MuxSubItem : SubItem
    {
        Type type;
        public MuxSubItem(string name, Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            InputDialogSample inputDialog = new InputDialogSample();
            if (inputDialog.ShowDialog() == true)
            {

                MUX instance = new MUX(inputDialog.nb, this.type, main);
               // main.Circuit.lesComposants.Add(instance.composant);
               // Console.WriteLine(this.type);
                main.grid.Children.Add(instance);

            }
        }

    }
}