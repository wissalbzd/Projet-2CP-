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
   public class CptSubItem : SubItem
    {
        public Type type;
        public CptSubItem(string name) : base(name)
        {
            
        }
        public override void Chosen(MainWindow main)
        {
           Segment_Display instance = new Segment_Display(main);
            main.grid.Children.Add(instance);

            // instance.compteur.set_Mode("frontM");
            // main.circuit.lesComposants.Add(instance);

            //main.grid.SetRow(instance.graphique, 0);
            //main.Grid.SetColumn(instance.graphique, 0);
            // main.grid.Children.Add(instance);
        }
    }
}
