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
    class BoxShowSubItem : SubItem
    {
        public Type type;
        
        public BoxShowSubItem(string name,Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            InputDialogSample inputDialog = new InputDialogSample();
            if (inputDialog.ShowDialog() == true)
            {
                
                Console.WriteLine("******************************************");

                Gate instance = new Gate(inputDialog.nb, this.type,main);
                Circuit.lesComposants.Add(instance.composant);
                Console.WriteLine("******************************************");
                Console.WriteLine(this.type);
                //Grid.SetRow(instance.graphique, 0);
                //Grid.SetColumn(instance.graphique, 0);
                main.grid.Children.Add(instance);
                //return g;
            }
        }
    }
}
