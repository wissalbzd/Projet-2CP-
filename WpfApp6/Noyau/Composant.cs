using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using Projet.Chronogrammes;
using Projet.Controleurs;
namespace Projet.CirSim
{

    public abstract class Composant
    {

        public int[] entrees;
        public int[] sorties;
        public int nbBits;
        public bool sync = false;
        public bool evalue;
        public List<Chrono> MesChronos = new List<Chrono>();
        public Composant(int nbBits)
        { this.nbBits = nbBits; }
        public Dictionary<int, List<Enreg>> relSortie = new Dictionary<int, List<Enreg>>();
        public Dictionary<int, Enreg> relEntree = new Dictionary<int, Enreg>();
        public abstract void Evaluer();
        public abstract int Get_sortie(int num);
        public abstract void Set_entrees(int numE, int val);
        // public abstract Path Give_Path();

        public void Relier(int numS, Composant c, int numE)
        {
            bool contient = false;
            Enreg enreg = new Enreg(c, numE);
            if (this.Equals(c))
            {
                c.Set_entrees(numE, -1);
            }
            else
            {
                foreach (Enreg enregC in this.relEntree.Values)
                {
                    if (enregC.composant.Equals(c))
                    {
                        contient = true;
                        c.Set_entrees(numE, -1);
                    }
                }
                if (!contient)
                {
                    Enreg enreg2 = new Enreg(this, numS);
                    if (!relEntree.ContainsValue(enreg2)) c.relEntree.Add(numE, enreg2);
                }
            }
            if (relSortie.ContainsKey(numS))
            {
                relSortie[numS].Add(enreg);
            }
            else
            {
                List<Enreg> l = new List<Enreg>();
                l.Add(enreg);
                relSortie.Add(numS, l);
            }
            if (c.GetType() != typeof(Sequentiels) && this.sync && !c.sync)
            {
                c.Synchro();
            }
            else
            {
                if (c.GetType() == typeof(Sequentiels)) { Circuit.Horloge.compoattaches.Add(c); }
            }

        }
        public void Synchro()
        {
            foreach (KeyValuePair<int, List<Enreg>> compSortie in relSortie)
            {
                foreach (Enreg enreg in compSortie.Value)
                {

                    enreg.composant.Synchro();
                }
            }
            this.sync = true;
            Circuit.Horloge.compoattaches.Add(this);
            Circuit.lesComposants.Remove(this);
            foreach (KeyValuePair<int, List<Enreg>> compSortie in relSortie)
            {
                foreach (Enreg enreg in compSortie.Value)
                {
                    if (enreg.composant.GetType() != typeof(Sequentiels))
                    {
                        enreg.composant.sync = true;
                        Circuit.Horloge.compoattaches.Add(enreg.composant);
                        Circuit.lesComposants.Remove(enreg.composant);
                    }
                }
            }
        }

        public void Eval()
        {
            if (!this.evalue)
            {
                if (this.relEntree.Count != 0)
                {
                    foreach (KeyValuePair<int, Enreg> rel in this.relEntree)
                    {

                        rel.Value.composant.Eval();
                    }
                }

                Evaluer();
                Console.WriteLine(this.GetType());
                Console.Write(this.sorties[0]);
                this.evalue = true;
                foreach (KeyValuePair<int, List<Enreg>> compSortie in relSortie)
                {
                    foreach (Enreg enreg in compSortie.Value)
                    {

                        enreg.composant.Set_entrees(enreg.nEntree, this.Get_sortie(compSortie.Key));
                    }
                }
            }
        }

        public void SyncChrono()
        {
            int i = 0;
            if (this.MesChronos.Count != 0)
            {
                foreach (Chrono chrono in MesChronos)
                {
                    chrono.AjoutVal(this.sorties[i]);
                    i++;
                }
            }
        }
    }
}


