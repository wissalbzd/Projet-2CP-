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
using Projet.Views;
using Projet.Chronogrammes;
using Projet.Controleurs;
using System.Threading;

namespace Projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Wire filActif;
        Thread threadCycle;
        ChronosWindow windowChronos;
        //Thread threadEvaluation;
        public MainWindow()
        {
            InitializeComponent();

            windowChronos = new ChronosWindow();
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new NotSubItem("NON"));
            menuRegister.Add(new BoxShowSubItem("ET", typeof(And)));
            menuRegister.Add(new BoxShowSubItem_Or("OU", typeof(Or)));
            menuRegister.Add(new BoxShowSubItem_Or("XOR", typeof(XOR)));
            menuRegister.Add(new BoxShowSubItem_Or("NOR", typeof(Nor)));
            menuRegister.Add(new BoxShowSubItem("NAND", typeof(Nand)));
            var item0 = new ItemMenu("PLogiques", menuRegister);

            var menuScheduler = new List<SubItem>();
            menuScheduler.Add(new AddUnSubItem("ADD", typeof(ADD)));
            menuScheduler.Add(new AddUnSubItem("ADC", typeof(ADC)));
            menuScheduler.Add(new AddNSubItem("ADnbits"));
            menuScheduler.Add(new BoxShowSubItem("Decodeur", typeof(Decodeur)));
            menuScheduler.Add(new BoxShowSubItem("Encodeur", typeof(Encodeur)));
            menuScheduler.Add(new MuxSubItem("Mux", typeof(Mux)));
            menuScheduler.Add(new BoxShowSubItem("Demux", typeof(Demux)));
            var item1 = new ItemMenu("Combinatoires  ", menuScheduler);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SeqSubItem("Bascule T", typeof(T)));
            menuReports.Add(new SeqSubItem("Bascule D", typeof(D)));
            menuReports.Add(new SeqSubItem("Bascule RST", typeof(RST)));
            menuReports.Add(new SeqSubItem("Bascule JK", typeof(JK)));
            menuReports.Add(new SeqSubItem("Compteurs", typeof(Compteur)));
            menuReports.Add(new SeqSubItem("Registres", typeof(JK)));
            var item2 = new ItemMenu("Sequentils   ", menuReports);

            var menuExpenses = new List<SubItem>();
            //menuExpenses.Add(new SubItem("File", typeof(Lampe)));
            menuExpenses.Add(new LampeSubItem("Lampe"));
            menuExpenses.Add(new PinSubItem("Pin"));
            menuExpenses.Add(new ClockSubItem("Horloge"));
            menuExpenses.Add(new SegmentDisplay("Segment Display"));
            var item3 = new ItemMenu("Outils", menuExpenses);


            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));

        }



        private void icon_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Path).Fill = Brushes.Turquoise;
        }

        private void icon_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Path).Fill = Brushes.White;
        }

        private void Arreter_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = Brushes.Red;

        }

        private void Arreter_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = Brushes.White;
        }

        private void simuler_MouseDown(object sender, MouseButtonEventArgs e)
        {
            simuler.Fill = Brushes.Turquoise;
            arreter.IsEnabled = true;
            Circuit.traiter(windowChronos);
            if (Circuit.Horloge != null)
            {
                Chrono.IsEnabled = true;
                //Circuit.Horloge.stop = false;
                threadCycle = new Thread(Circuit.Horloge.cycle);
                // threadEvaluation = new Thread(Circuit.Horloge.evaluation);
                threadCycle.Start();
                //threadEvaluation.Start();

            }
        }

        private void tabv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Circuit.pins.Count != 0)
            {
                if (Circuit.Horloge == null)
                {
                    TvWindow t = new TvWindow();
                    t.Show();
                }
                else
                {
                    TvWindow t = new TvWindow("frontM");
                    t.Show();
                }
            }

        }

        private void arreter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Circuit.Horloge != null) Circuit.Horloge.stop = true;
        }

        private void Chrono_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Path).Fill = Brushes.Turquoise;
            windowChronos.Show();
            windowChronos.ActiverChrono();
        }
    }
}

// <materialDesign:PopupBox PlacementMode="BottomAndAlignRightEdges" HorizontalAlignment="Right" Margin="15"/>