using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.Controleurs;

namespace Projet.CirSim
{
    class Tv
    {
        public int[,] entrees;
        public int[,] sorties;
        public int e;
        public double ep2;
        public int s;

        public Tv()
        {
            e = Circuit.pins.Count;
            ep2 = Math.Pow(2, e);
            s = Circuit.lampes.Count;
            if (Circuit.Horloge != null) s = s + Circuit.Horloge.compoattaches.Count;
            entrees = new int[(int)ep2, e];
            sorties = new int[(int)ep2, s];
            SetEntree();
            if (Circuit.Horloge == null) SetSortie();
            else SetSortie_seq();
        }
        public void SetEntree()
        {
            for (int i = 0; i < ep2; i++)
            {
                int k = e - 1;
                String binaire = Convert.ToString(i, 2);
                for (int j = binaire.Length - 1; j >= 0; j--)
                {
                    entrees[i, k] = binaire.Substring(j, 1) == "1" ? 1 : 0;
                    k--;
                    Console.WriteLine("le k {0}", k);
                }
                while (k >= 0) { entrees[i, k] = 0; k--; }

            }
        }

        public void EvaluCas(int l)
        {
            for (int i = 0; i < e; i++)
            {
                Circuit.pins[i].valeur = entrees[l, i];
            }
            foreach (PinGraphique pin in Circuit.pins)
            {
                pin.AffecterVal();
            }
            foreach (Composant c in Circuit.lesComposants)
            {
                c.Eval();
            }
            for (int la = 0; la < Circuit.lampes.Count; la++)
            {
                sorties[l, la] = Circuit.lampes[la].c.sorties[Circuit.lampes[la].numS_c];
                Console.WriteLine("indice lampe {0}", la);
                Console.WriteLine(Circuit.lampes[la].c.sorties[Circuit.lampes[la].numS_c]);
                Console.WriteLine("la sortie num {0} est a {1}", l, sorties[l, la]);
            }
        }

        public void EvaluerCas_seq(int l)
        {
            EvaluCas(l);
            foreach (Composant element in Circuit.Horloge.compoattaches)
            { element.Eval(); Console.WriteLine("/////le front {0}", Circuit.Horloge.front); Console.WriteLine(element.sorties[0]); }
            for (int la = 0; la < Circuit.lampesSync.Count; la++)
            {
                int i = la + Circuit.lampes.Count;
                sorties[l, i] = Circuit.lampesSync[la].c.sorties[Circuit.lampesSync[la].numS_c];
            }
        }

        public void SetSortie()
        {
            for (int i = 0; i < ep2; i++)
            {
                EvaluCas(i);
                foreach (Composant c in Circuit.lesComposants) { c.evalue = false; }
            }
        }

        public void SetSortie_seq()
        {
            for (int i = 0; i < ep2; i++)
            {
                EvaluerCas_seq(i);
                foreach (Composant c in Circuit.lesComposants) { c.evalue = false; }
                foreach (Composant c in Circuit.Horloge.compoattaches) { c.evalue = false; }
            }
        }
        public String GetEntree(int l)
        {
            String chaine = "";
            for (int i = 0; i < e; i++)
            {
                chaine = chaine + entrees[l, i].ToString();
            }
            return chaine;
        }

        public String GetSortie(int l)
        {
            String chaine = "";
            for (int i = 0; i < s; i++)
            {
                chaine = chaine + sorties[l, i].ToString();
            }
            return chaine;
        }
    }
}
