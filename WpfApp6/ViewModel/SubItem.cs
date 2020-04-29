using System;
using System.Windows.Controls;
using Projet;


namespace BeautySolutions.View.ViewModel
{
    public abstract class SubItem
    {
        public Type typo;
        
        public SubItem(string name)
        {
            Name = name;
            //Screen = screen;
            
        }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
        public abstract void Chosen(MainWindow main);

        
    }
}