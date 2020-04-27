using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projet;
using Projet.CirSim;
using Projet.Controleurs;

namespace BeautySolutions.View.ViewModel

{
    class RegSubItem : SubItem
    {
        Type type;
        public RegSubItem(string name, Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            //RegistreUI instance = new RegistreUI( main);
            // main.circuit.lesComposants.Add(instance);

            //main.grid.SetRow(instance.graphique, 0);
            //main.Grid.SetColumn(instance.graphique, 0);
            //main.grid.Children.Add(instance);
        }
    }
}
