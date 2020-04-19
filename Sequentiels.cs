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
        { this.sync = true; }
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
          if((mode=="frontM" && Circuit.Horloge.front==1) || (mode=="fronD" && Circuit.Horloge.front==0) || (mode=="etatH" && Circuit.Horloge.etat) || (mode=="etatB" && !Circuit.Horloge.etat))
            { return true; }
            else return false;
          }
          else
          {
              if(Validation.composant.sorties[Validation.nEntree]==0)
                { return false; }
                else { return false; }
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


    }
}
