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
    /// Logique d'interaction pour SeqDialog.xaml
    /// </summary>
    public partial class SeqDialog : Window
    {
        public String[] modes { get; set; }
        public SeqDialog()
        {
            InitializeComponent();
            lemode.SelectedIndex = 0;
            modes = new string[] { "Front montant", "Front déçandant", "Etat haut", "Etat bas" };
            DataContext = this;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
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
    }
}
