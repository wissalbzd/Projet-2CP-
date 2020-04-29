using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class PorteLogique : Composant
    {
        
        public PorteLogique(int nbbit) : base(nbbit)
        {
           // graphique = new Gate(nbBits);
            entrees = new int[nbbit];
            sorties = new int[1];
        }
        public abstract Path GetPath();
        public override int Get_sortie(int num)
        {
            return this.sorties[num];
        }
        
        public override void Set_entrees(int numE, int val)
        {
            this.entrees[numE] = val;
        }

        public  abstract override void Evaluer();

	public void Supprimer()
        {
            foreach (KeyValuePair<int, Enreg> p in relEntree)
            {
                Composant cp = p.Value.composant;
                int ns = p.Value.nEntree;
                if (cp.relSortie.ContainsKey(ns))
                {
                    if (cp.relSortie[ns].Count == 1) { cp.relSortie.Remove(ns); Console.WriteLine("/////// supression////////"); }
                    else
                    {
                        Enreg enreg = new Enreg(this, p.Key);
                        cp.relSortie[ns].Remove(enreg);
                    }
                }
            }
            foreach (KeyValuePair<int, List<Enreg>> p in relSortie)
            {
                foreach (Enreg enreg in p.Value)
                {
                    if (enreg.composant.relEntree.ContainsKey(enreg.nEntree)) { enreg.composant.relEntree.Remove(enreg.nEntree); }
                }
            }
            if (sync) Circuit.Horloge.compoattaches.Remove(this);
            else Circuit.lesComposants.Remove(this);
        }
    }

}
