using System;
using System.Collections.Generic;
using System.Text;
using Projet.Controleurs;
namespace Projet.CirSim
{

    class Compteur : Sequentiels
    {

        string type; //bit ou bus
        int i, modulo;
        public int[,] Q;
        public Compteur(int modulo, string type) : base(1)
        {
            this.i = 0; this.modulo = modulo; entrees[0] = 1; this.type = type; mode = "frontD";

            if (type == "bit")
            {
                sorties = new int[100]; Q = new int[100, 100];
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



            if (entrees[0] == 1) //entree de validation
            {
                if (i < modulo - 1)
                {


                    if (type == "bus") sorties[i] = Int32.Parse(Convert.ToString(i, 2));
                    else
                    {
                        sorties[i] = Int32.Parse(Convert.ToString(i, 2));
                        int mod = sorties[i]; int nb = Nb_ligne_sortie();

                        for (int k = nb; k >= 0; k--)
                        {

                            Q[i, k] = mod / (int)Math.Pow(10, k);
                            mod = mod % (int)Math.Pow(10, k);


                        }

                    }
                    this.i++;

                }
                else this.i = 0;



            }



        }


        public int Nb_ligne_sortie() // Calcul le nombre de bits pour la sortie
                                     // eg: pour 8bits en etrée elle retourne 3 (2^3=8)
        {

            int mod = modulo;
            //convertir au decimal
            int k = 0;
            Console.WriteLine(mod);
            while (mod > 0)
            {
                mod = mod / 10;
                k++;


            }
            return k;
        }

        public override int Get_sortie(int num) { return num; }
        public int Get_sortieB(int num) { return Q[this.i, num]; } //i num du cycle
    }
}
