using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projet.CirSim;

namespace Projet.Views
{
    /// <summary>
    /// Logique d'interaction pour TvWindow.xaml
    /// </summary>
    public partial class TvWindow : Window
    {
        Tv tab;
        public TvWindow()
        {
            InitializeComponent();
            SetTv();

        }
        public TvWindow(String cas)
        {
            InitializeComponent();
            frontM.IsEnabled = true;
            FrontD.IsEnabled = true;
            etatH.IsEnabled = true;
            etatB.IsEnabled = true;
            switch (cas)
            {
                case "frontM":
                    Circuit.Horloge.front = 1;
                    Circuit.Horloge.et = -1;
                    frontM.Background = Brushes.Turquoise;
                    frontM.Foreground = Brushes.White;
                    break;
                case "frontD":
                    Circuit.Horloge.front = 0;
                    Circuit.Horloge.et = -1;
                    FrontD.Background = Brushes.Turquoise;
                    FrontD.Foreground = Brushes.White;
                    break;
                case "etatH":
                    Circuit.Horloge.front = -1;
                    Circuit.Horloge.et = 1;
                    etatH.Background = Brushes.Turquoise;
                    etatH.Foreground = Brushes.White;
                    break;
                case "etatB":
                    Circuit.Horloge.front = -1;
                    Circuit.Horloge.et = 0;
                    etatB.Background = Brushes.Turquoise;
                    etatB.Foreground = Brushes.White;
                    break;
            }
            SetTv();
        }

        public void SetTv()
        {
            tab = new Tv();

            for (int i = 0; i < tab.ep2; i++)
            {

                Label l1 = new Label();
                l1.Content = tab.GetEntree(i);
                entreepanel.Children.Add(l1);
                Label l2 = new Label();
                l2.Content = tab.GetSortie(i);
                sortiepanel.Children.Add(l2);
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TvWindow t = new TvWindow("frontM");
            t.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Composant c in Circuit.Horloge.compoattaches)
            {
                for (int i = 0; i < c.sorties.Length; i++) { c.sorties[i] = 0; }
            }
            TvWindow t = new TvWindow("frontD");
            t.Show();
            this.Close();
        }

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Fill = Brushes.Red;
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Fill = Brushes.Transparent;
        }

        private void frontM_Click(object sender, RoutedEventArgs e)
        {
            foreach (Composant c in Circuit.Horloge.compoattaches)
            {
                for (int i = 0; i < c.sorties.Length; i++) { c.sorties[i] = 0; }
            }
            TvWindow t = new TvWindow("frontM");
            t.Show();
            this.Close();
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.Turquoise;
            b.Foreground = Brushes.White;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = Brushes.Transparent;
            b.Foreground = Brushes.Turquoise;
        }

        private void etatH_Click(object sender, RoutedEventArgs e)
        {
            foreach (Composant c in Circuit.Horloge.compoattaches)
            {
                for (int i = 0; i < c.sorties.Length; i++) { c.sorties[i] = 0; }
            }
            TvWindow t = new TvWindow("etatH");
            t.Show();
            this.Close();
        }

        private void etatB_Click(object sender, RoutedEventArgs e)
        {
            foreach (Composant c in Circuit.Horloge.compoattaches)
            {
                for (int i = 0; i < c.sorties.Length; i++) { c.sorties[i] = 0; }
            }
            TvWindow t = new TvWindow("etatB");
            t.Show();
            this.Close();
        }

        private void FrontD_Click(object sender, RoutedEventArgs e)
        {
            foreach (Composant c in Circuit.Horloge.compoattaches)
            {
                for (int i = 0; i < c.sorties.Length; i++) { c.sorties[i] = 0; }
            }
            TvWindow t = new TvWindow("frontD");
            t.Show();
            this.Close();
        }
    }
}
