  public void cycle()
        {
            int et = -1;
            int i = 0;
            
            while (i<cy*2)
            {
                foreach (Composant c in compoSync )
                { c.evalue = false; }
                foreach (Bascule c in compoattaches)
                { c.evalue = false; /*Console.WriteLine("sortie    " +c.sorties[0]); */ }
                foreach (Sequentiels element in compoattaches)
                {element.Eval();}
                foreach (Bascule c in this.compoSync)
                { c.Eval(); }
                foreach(LampeControl l in Circuit.lampesSync)
                { l.activer();  }
                this.WaitNSeconds(2);
                //System.Threading.Tasks.Task.Delay(5000);
                if (front == 1) { et = 1; etat = true; } else { et = 0; etat = false; }
                front = -1;
                foreach (Composant c in compoSync)
                { c.evalue = false; }
                foreach (Composant c in compoattaches)
                { c.evalue = false; }
                foreach (Sequentiels element in compoattaches)
                {element.Eval();}
                foreach(Composant c in this.compoSync)
                {c.Eval();}
                foreach (LampeControl l in Circuit.lampesSync)
                {l.activer();}

                Console.WriteLine("i = " + i);
               
                if (et == 1) front = 0; else front = 1;
                et = -1;
                
               
                i++;

            }





        }
