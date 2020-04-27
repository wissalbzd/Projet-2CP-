using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public class Compteur : Sequentiels
    {

        public string type; //bit ou bus
        public int modulo, i = 0;

        int nb;
        public Compteur() : base(1)
        {

            this.entrees[0] = 1;

        }
        public override void tab_TT()
        { }
        public override void Evaluer()
        {


            if (this.Condition())
            {
                Console.WriteLine("***********************************condition true*****************************");

                if (i <= modulo - 1)
                {

                    Console.WriteLine("************************i actuel en dici  " + this.i);

                    if (type == "bus") sorties[i] = Int32.Parse(Convert.ToString(i, 2));
                    else
                    {

                        int mod = Int32.Parse(Convert.ToString(i, 2));
                        Console.WriteLine("**********************************************sortie actuel " + mod);
                        for (int k = nb - 1; k >= 0; k--)
                        {

                            sorties[k] = mod / (int)Math.Pow(10, k);
                            mod = mod % (int)Math.Pow(10, k);


                        }

                    }
                    this.i = this.i + 1; ;


                }
                else

                {
                    this.i = 0;
                    int mod = Int32.Parse(Convert.ToString(i, 2));
                    Console.WriteLine("**********************************************sortie actuel " + mod);
                    for (int k = nb - 1; k >= 0; k--)
                    {

                        sorties[k] = mod / (int)Math.Pow(10, k);
                        mod = mod % (int)Math.Pow(10, k);


                    }


                }
            }
        }


        public int Nb_ligne_sortie()
        {
            int k = 0;

            while (modulo > Math.Pow(2, k) - 1)
            {

                k++;

            }
           
            return k;
        }
        public void setDebutComptage(int i) { this.i = i; }
        public override int Get_sortie(int num) { return sorties[num]; }
        public void Set_Propriete(string type, int modulo)
        {
            this.modulo = modulo;
            this.type = type;
            this.nb = Nb_ligne_sortie();

            sorties = new int[Nb_ligne_sortie()];
            Console.WriteLine("///////////////////////sortie nb colonnes  " + sorties.GetLength(0));
        }
    }
}
