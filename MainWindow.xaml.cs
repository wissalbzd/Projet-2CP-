using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projet.CirSim;
using Projet.Controleurs;

namespace Projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  Wire filActif;
        
        public MainWindow()
        {
            InitializeComponent();
           
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new NotSubItem("NON"));
            menuRegister.Add(new BoxShowSubItem("ET", typeof(And)));
            menuRegister.Add(new BoxShowSubItem_Or("OU", typeof(Or)));
            menuRegister.Add(new BoxShowSubItem_Or("XOR", typeof(XOR)));
            menuRegister.Add(new BoxShowSubItem_Or("NOR", typeof(Nor)));
            menuRegister.Add(new BoxShowSubItem("NAND", typeof(Nand)));
            var item0 = new ItemMenu("PLogiques", menuRegister);

            var menuScheduler = new List<SubItem>();
            menuScheduler.Add(new BoxShowSubItem("ADD", typeof(ADD)));
            menuScheduler.Add(new BoxShowSubItem("ADC",typeof(ADC)));
            menuScheduler.Add(new BoxShowSubItem("Decodeur", typeof(Decodeur)));
            menuScheduler.Add(new BoxShowSubItem("Encodeur", typeof(Encodeur)));
            menuScheduler.Add(new BoxShowSubItem("Mux",typeof(Mux)));
            menuScheduler.Add(new BoxShowSubItem("Demux",typeof(Demux)));
            var item1 = new ItemMenu("Combinatoires  ", menuScheduler);

            var menuReports = new List<SubItem>();
            menuReports.Add(new BoxShowSubItem("Bascule T", typeof(T)));
            menuReports.Add(new BoxShowSubItem("Bascule D", typeof(T)));
            menuReports.Add(new BoxShowSubItem("Bascule RST", typeof(T)));
            menuReports.Add(new BoxShowSubItem("Bascule JK", typeof(JK)));
            menuReports.Add(new BoxShowSubItem("Compteurs", typeof(JK)));
            menuReports.Add(new BoxShowSubItem("Registres",typeof(JK)));
            var item2 = new ItemMenu("Sequentils   ", menuReports);

            var menuExpenses = new List<SubItem>();
            //menuExpenses.Add(new SubItem("File", typeof(Lampe)));
            menuExpenses.Add(new LampeSubItem("Lampe"));
            menuExpenses.Add(new PinSubItem("Pin"));
            var item3 = new ItemMenu("Outils", menuExpenses);

            
            Menu.Children.Add(new UserControlMenuItem(item0,this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            
        }

        private void Simuler_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background=Brushes.Turquoise ;
            Circuit.traiter();
        }

        private void Simuler_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.Turquoise;
        }

        private void Simuler_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.Transparent;
        }
    }
    }

// <materialDesign:PopupBox PlacementMode="BottomAndAlignRightEdges" HorizontalAlignment="Right" Margin="15"/>