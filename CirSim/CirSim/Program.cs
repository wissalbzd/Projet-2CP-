/*using System;

namespace CirSim
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int[] tab = { 10, 20, 30, 40 };
          //  JK jk = new JK(true , tab);
            T t = new T(true, tab);
           // string tab[10,10] =JK.tab_transion;
            String r= t.Evaluer("0","1");
           // Console.WriteLine("resultat " + r);

        }
    }
}*/
/*using System;
using System.Collections;


namespace CirSim
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] entree = new int[3] { 1,1,1};
         XOR or = new XOR(3);
          //  Non or = new Non();
            or.entrees = entree;
             or.Evaluer();
            Console.WriteLine(or.sorties[0]);
           /* or.sorties[0] = 1;
            Console.Write(or.sorties[0]);
            /*Or b  = new Or();
            //Console.WriteLine(b.sortie[0]);
            Horloge horloge = new Horloge(2);
            // horloge.chrono1(3);
            //Console.WriteLine(horloge.chrono2(3));
            Nand c = new Nand();
            //Console.WriteLine(c.sortie[0]);
            Nor d = new Nor();
            //Console.WriteLine(d.sortie[0]);
            Non e = new Non();
            //Console.WriteLine(e.sortie[0]);
            Xor f = new Xor();
            Console.WriteLine(f.sortie[0]);*/



   /*     }
    }
}*/


using System;

namespace CirSim
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Demux d = new Demux(2);
             d.entrees[0] = 1;
             d.cmd[0] = 0;
             d.cmd[1] = 0;
             d.evaluer();*/
            Encodeur a = new Encodeur(2);
            a.entrees[0] = 0;
            a.entrees[1] = 1;
           
            a.Evaluer();
            foreach (int c in a.sorties)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("la ret");
            

        }
    }
}


