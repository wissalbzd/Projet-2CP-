using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    class Compteur : Sequentiels
    {
        string type; //bit ou bus
        int i,modulo,j=0;
         public int[,] Q;
        int nb;
           public Compteur(int modulo,string type) : base(1) { this.i = 0; this.modulo = modulo;  entrees[0] = 1; this.type = type;  mode = "frontD";
            this.nb = Nb_ligne_sortie();
            if (type == "bit") { sorties = new int[100]; Q = new int[100, 100];
            }
            else
            {
                sorties = new int[modulo];
            }
        }
        public override void tab_TT()
        { }
        public override void Evaluer()
        {

          
           
            if (entrees[0]== 1) //entree de validation
            {
                if (i < modulo - 1)
                {


                    if (type == "bus") sorties[i] = Int32.Parse(Convert.ToString(i, 2));
                    else
                    {
                        sorties[j] = Int32.Parse(Convert.ToString(i, 2));
                        int mod = sorties[j]; 

                        for (int k = nb; k >= 0; k--)
                        {

                            Q[j, k] = mod / (int)Math.Pow(10, k);
                            mod = mod % (int)Math.Pow(10, k);
                           

                        }
                       
                    }
                    this.i++;
                    this.j++;
                
                }
                else this.i = 0;



            }
        }
          
        
        public int Nb_ligne_sortie() 
        {
            int k = 0;
           
            while (modulo>Math.Pow(2,k)-1)
            {
                
                k++;
                
            }
            return k;
        }
        public void setDebutComptage(int i) { this.i = i; }
        public override int Get_sortie(int num) { return sorties[num]; }
        public int Get_sortieB(int numL , int numC) { return Q[numL, numC]; } //i num du cycle le poids faible 0
       
    }
}
