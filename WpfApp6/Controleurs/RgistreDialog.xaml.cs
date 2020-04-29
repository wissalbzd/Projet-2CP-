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

namespace Projet.Controleurs
{
    /// <summary>
    /// Logique d'interaction pour RgistreDialog.xaml
    /// </summary>
    public partial class RgistreDialog : Window
    {
        public String[] modes { get; set; }
        public int[] nbs { get; set; }
        public String[] types { get; set; }

        public string[] dclg { get; set; }
        public RgistreDialog()
        {
            InitializeComponent();
            lemode.SelectedIndex = 0;
            modes = new string[] { "Front montant", "Front déçandant", "Etat haut", "Etat bas" };
            nombre.SelectedItem = 2;
            nbs = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,19,20,21,22,23,24,25,26,27,28,29,30,31,32 };
            types = new string[] { "bit par bit", "bus de données" };
            letype.SelectedIndex = 0;
            dclg = new string[] { "gauche", "droit", "circulaire gauche", "circilaire droit" };
            dcl.SelectedIndex = 0;

            DataContext = this;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public int nb
        {
            get { return (int)nombre.SelectedItem; }
        }

        public String md()
        {

            int i = lemode.SelectedIndex;
            switch (i)
            {
                case 0:
                    return "frontM";
                case 1:
                    return "FrontD";
                case 2:
                    return "etatH";
                case 3:
                    return "etatB";
                default:
                    return "";
            }

        }

        public String type()
        {
            int i = letype.SelectedIndex;
            if (i == 0) return "bit";
            else return "bus";
        }

        public String decalage()
        {
            return (String)dcl.SelectedItem;
        }
    }
}