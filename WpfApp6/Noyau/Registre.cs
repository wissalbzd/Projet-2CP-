using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.CirSim
{
    public class Registre : Sequentiels
    {

            public string decalage,type;
            public Registre(int nbBits) : base(nbBits)
            {
                entrees = new int[nbBits];
                sorties = new int[nbBits];
            }
            public override void tab_TT()
            { }
            public override void Evaluer()
            {
            if (this.Condition())
            {
                Console.WriteLine("*****************evaaaaaaaaaaaaaallllllllllllllll***********");
                for (int z = 0; z < nbBits; z++)
                {
                    Console.WriteLine(" entree   " + z + "  :   " + entrees[z]);  
                }
                switch (decalage)
                {
                    case "gauche":
                        for (int z = 0; z < nbBits - 1; z++)
                        {
                            sorties[z] = entrees[z + 1];
                        }
                        sorties[nbBits - 1] = 0;
                        break;
                    case "droite":
                        Console.WriteLine("droite");
                        for (int z = nbBits - 1; z > 0; z--)
                        {
                            sorties[z] = entrees[z - 1];
                        }
                        sorties[0] = 0;
                        break;
                    case "circulaire droit":
                        int k = entrees[nbBits - 1];
                        for (int j = nbBits - 1; j > 0; j--)
                        {
                            sorties[j] = entrees[j - 1];
                        }
                        sorties[0] = k;

                        break;
                    case "circulaire gauche":
                        int l = entrees[0];
                        for (int m = 0; m < nbBits - 1; m++)
                        {
                            sorties[m] = entrees[m + 1];
                        }
                        sorties[nbBits - 1] = l;


                        break;




                }
                this.entrees = this.sorties;
               }
            }
            public override int Get_sortie(int num) { return sorties[num]; }
            public void set_Proprietes(string type,string decalage)
            {
                this.decalage = decalage;
                this.type = type;
                
                
            }
    }
}


