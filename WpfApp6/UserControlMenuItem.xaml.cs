using BeautySolutions.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
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

namespace Projet
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        ItemMenu itemMenu;
        MainWindow main;
        public UserControlMenuItem(ItemMenu itemMenu,MainWindow main)
        {
            InitializeComponent();
            this.itemMenu = itemMenu;
            this.main = main;
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            


            this.DataContext = itemMenu;
        }

        private void ExpanderMenu_MouseEnter(object sender, MouseEventArgs e)
        {

            //(sender as TextBlock).Foreground = Brushes.Turquoise;
            
        }

        private void ExpanderMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            //(sender as TextBlock).Foreground = Brushes.White;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubItem a = this.ListViewMenu.SelectedItem as SubItem;
            if(a != null)
            { a.Chosen(this.main); }
            
            //Thread.Sleep(20);
            this.ListViewMenu.SelectedItems.Clear();
            //this.ListViewMenu.UnselectAll();
            //this.ListViewMenu.SelectedItem = null;
        }

        private void ListViewMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
