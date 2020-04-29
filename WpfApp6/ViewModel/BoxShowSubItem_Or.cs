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

    class BoxShowSubItem_Or :SubItem
    {
        Type type;
        public BoxShowSubItem_Or(string name, Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            InputDialogSample inputDialog = new InputDialogSample();
            if (inputDialog.ShowDialog() == true)
            {
                
                Gate_Or instance = new Gate_Or(inputDialog.nb, this.type,main);
                Circuit.lesComposants.Add(instance.composant);
                Console.WriteLine(this.type);
                main.grid.Children.Add(instance);
                
            }
        }

    }
}
