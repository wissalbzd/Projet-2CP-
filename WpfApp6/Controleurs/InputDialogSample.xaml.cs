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
namespace Projet.Controleurs
{
	/// <summary>
	/// Logique d'interaction pour InputDialogSample.xaml
	/// </summary>
	public partial class InputDialogSample : Window
    {
		public int[] nbs { get; set; }
		public InputDialogSample()
		{
			InitializeComponent();
			/*nombre.Background = Brushes.Black;
			nombre.Resources.Add(SystemColors.WindowBrushKey, Brushes.Black);*/
			nombre.SelectedItem = 2;
			nbs = new int[] { 2, 3, 4, 5 };
			DataContext = this;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer.SelectAll();
			txtAnswer.Focus();
		}



		public int nb
		{
			get { return (int)nombre.SelectedItem; }
		}
	}
}
