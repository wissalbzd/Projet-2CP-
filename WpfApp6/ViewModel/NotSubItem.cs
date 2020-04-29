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
    public class NotSubItem : SubItem
    {
       
        public NotSubItem(string name ) : base(name)
        {
            
        }
        public override void Chosen(MainWindow main) 
        {
            NotControl instance = new NotControl(main);
            Circuit.lesComposants.Add(instance.composant);

            //main.grid.SetRow(instance.graphique, 0);
            //main.Grid.SetColumn(instance.graphique, 0);
            main.grid.Children.Add(instance);
        }
    }
}
