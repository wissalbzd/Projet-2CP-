using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projet;
using Projet.CirSim;
using Projet.Controleurs;

namespace BeautySolutions.View.ViewModel

{
    class SeqSubItem : SubItem
    {
        Type type;
        public SeqSubItem(string name, Type type) : base(name)
        {
            this.type = type;
        }
        public override void Chosen(MainWindow main)
        {
            if (type != typeof(Compteur) && type != typeof(Registre))
            {
                SeqDialog dialog = new SeqDialog();
                if (dialog.ShowDialog() == true)
                {

                    BasculeGraphique instance = new BasculeGraphique(type, dialog.md(), main);
                    main.grid.Children.Add(instance);
                }

            }
            else
            {
                if (type == typeof(Compteur))
                {
                    CptDialog dialog = new CptDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        // BasculeGraphique instance = new BasculeGraphique(type, dialog.md(), main);
                         CptGraphique instance = new CptGraphique(dialog.md(),dialog.nb,dialog.type(),dialog.valeurInit(), main);
                         main.grid.Children.Add(instance);
                    }
                }
                else
                {
                    RgistreDialog dial = new RgistreDialog();
                    if (dial.ShowDialog() == true)
                    {
                         RegistreUI instance = new RegistreUI(dial.md(), dial.type(),dial.decalage(), dial.nb, main);
                         main.grid.Children.Add(instance);
                    }
                }
                
            }


            // main.circuit.lesComposants.Add(instance);

            //main.grid.SetRow(instance.graphique, 0);
            //main.Grid.SetColumn(instance.graphique, 0);

        }
    }
}