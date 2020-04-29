using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;

/*
 *  Copyright (C) 2011 Steve Kollmansberger
 * 
 *  This file is part of Logic Gate Simulator.

 *
 *  Logic Gate Simulator is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Logic Gate Simulator is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Logic Gate Simulator.  If not, see <http://www.gnu.org/licenses/>.
 */

using Projet.CirSim;
namespace Projet.Controleurs
{
    /// <summary>
    /// An animated wire which can show a flow of current from an origin to destination.
    /// </summary>
    public partial class PinGraphique : UserControl
    {
        
        public MainWindow window;
        public int valeur = 0;
        public Point actuel;
        bool clic = false;
        Point m_start;
        Vector m_startOffset;
        Line ligne;
        public bool boolsource = false, booldestinataire = false;
        public Dictionary<int, List<Composant>> relEntree = new Dictionary<int, List<Composant>>();
        public PinGraphique(MainWindow main)
        {
            InitializeComponent();
            this.window = main;
        }
        public void AffecterVal()
        {
            foreach(KeyValuePair <int,List < Composant>> p in relEntree)
            {
                foreach(Composant c in p.Value)
                {
                    
                    c.Set_entrees(p.Key, this.valeur);
                }
            }
        }
        public void relierP(Composant g, int numE)
        {

            if (relEntree.ContainsKey(numE))
            {
                relEntree[numE].Add(g);
            }
            else
            {
                List<Composant> l = new List<Composant>();
                l.Add(g);
                relEntree.Add(numE, l);
            }


        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (E.IsMouseOver) clic = true;
            if (!clic)
            {
                actuel = e.GetPosition(window);
                m_start = e.GetPosition(window);
                m_startOffset = new Vector(tt.X, tt.Y);
                p.CaptureMouse();
            }
            clic = false;
            
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clic)
            { 
                if (p.IsMouseCaptured)
                {
                    Vector offset = Point.Subtract(e.GetPosition(window), m_start);

                    tt.X = m_startOffset.X + offset.X;
                    tt.Y = m_startOffset.Y + offset.Y;
                }
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!E.IsMouseOver)

                p.ReleaseMouseCapture();
        }



        private void E_MouseDown(object sender, MouseButtonEventArgs e)
        {
            window.filActif = new Wire();
            window.filActif.pin = this;
            window.filActif.fil.source = e.GetPosition(this.window.grid);
            boolsource = true;
            Console.WriteLine("PinGraphique");
           
        }

        private void E_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wire f = window.filActif;
            this.relierP(f.destination, f.NumDest);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);
            window.filActif.fil.destination = Mouse.GetPosition(this.window.grid);
            ligne = window.filActif.fil.DrawLine();
            this.window.grid.Children.Add(ligne);
        }

        private void Switch(object sender, MouseButtonEventArgs e)
        {
            if (actuel == e.GetPosition(window))
            {
                if (valeur == 0) valeur = 1; else valeur = 0;
                if (valeur == 0)
                {
                    path.Fill = Brushes.Gray;
                    inter.Fill = Brushes.Transparent;
                }
                else
                {
                    path.Fill = Brushes.SeaGreen;
                    inter.Fill = Brushes.LightCyan;
                }
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Circuit.pins.Remove(this);
            window.grid.Children.Remove(this);
        }
        private void Copier_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Pivoter_Click(object sender, RoutedEventArgs e)
        {
            if (vv.Angle == 0) { vv.Angle = 90; }
            else
            {
                if (vv.Angle == 90) { vv.Angle = 180; }
                else
                {
                    if (vv.Angle == 180) { vv.Angle = -90; }
                    else
                    {
                        if (vv.Angle == -90) { vv.Angle = 0; }
                    }
                    
                }
                
            }
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as MenuItem).Background = Brushes.Turquoise;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as MenuItem).Background = Brushes.Black;
        }
    }
}
