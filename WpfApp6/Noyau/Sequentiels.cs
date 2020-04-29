using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class  Sequentiels : Composant
    {

        public static String[,] tab_transition { get; set; }
        
        public string mode;
        public Enreg Validation;
        protected Sequentiels(int nbBits) : base(nbBits) 
        { this.sync = true;
          entrees = new int[nbBits];
        }
        public abstract void tab_TT();
        public void chronogramme(int[] tab_transition) { }
        public void Affich_TT()
        {
            for (int s = 0; s < tab_transition.GetLength(0); s++)
            {

                for (int k = 0; k < tab_transition.GetLength(1); k++)
                {
                    if (tab_transition[s, k].Length != 2)
                        Console.Write("     " + tab_transition[s, k] + " ");
                    else Console.Write("     " + tab_transition[s, k]);

                    Console.Write("|");

                }
                Console.WriteLine();
            }
        }
        public bool Condition()
        {
          if(Validation==null)
          {
                if ((this.mode == "frontM" && Circuit.Horloge.front == 1) || (this.mode == "fronD" && Circuit.Horloge.front == 0) || (this.mode == "etatH" && Circuit.Horloge.et==1) || (this.mode == "etatB" && Circuit.Horloge.et==0))
                { Console.WriteLine("true"); return true; }
                else { return false;  }
            }
          else
          {
              if(Validation.composant.sorties[Validation.nEntree]==0)
                { Console.WriteLine("true valid"); return false; }
                else { Console.WriteLine("false valid"); return false; }
          }

        }
        public void Aff_Valid(Composant composant,int numS)
        {
            this.Validation.composant = composant;
            this.Validation.nEntree = numS;
        }
        public void set_Mode(string mode) { this.mode = mode; }
        public abstract override int Get_sortie(int num);
        public override void Set_entrees(int numE, int val) { entrees[numE] = val; }

        public void Supprimer()
        {
            foreach (KeyValuePair<int, Enreg> p in this.relEntree)
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
            foreach (KeyValuePair<int, List<Enreg>> p in this.relSortie)
            {
                foreach (Enreg enreg in p.Value)
                {
                    if (enreg.composant.relEntree.ContainsKey(enreg.nEntree)) { enreg.composant.relEntree.Remove(enreg.nEntree); }
                }
            }
            if (this.sync && Circuit.Horloge != null)
            {
                if (Circuit.Horloge.compoattaches.Contains(this)) Circuit.Horloge.compoattaches.Remove(this);
            }
            if (!this.sync) Circuit.lesComposants.Remove(this);
        }


    }
}
