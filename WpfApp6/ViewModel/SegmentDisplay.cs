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
   public class SegmentDisplay : SubItem
    {
        public Type type;
        public SegmentDisplay(string name) : base(name)
        {
            
        }
        public override void Chosen(MainWindow main)
        {
           Segment_Display instance = new Segment_Display(main,3);
            main.grid.Children.Add(instance);

        }
    }
}
