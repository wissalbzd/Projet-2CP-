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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using System.Windows.Threading;
using System.IO;
using System.Net;
//using System.Timers;
using Projet.CirSim;

namespace Projet.Chronogrammes
{
    /// <summary>
    /// Interaction logic for Chrono.xaml
    /// </summary>
    public partial class Chrono : UserControl
    {
        CartesianChart chart;
        StepLineSeries series;
        bool paused = false;
        
        
        public ChartValues<int> values { get; set; }
        
        public Chrono()
        {
            InitializeComponent();
            this.ConstruireGraph();
            DataContext = this;
            chart.DataContext = series;
        }
        public void AjoutVal(int v)
        {
            if (!this.paused)
            {
                this.values.Add(v);
            }
        }
       
        public void Activate()
        {
            this.paused = false;
        }
        public void Pause()
        {
            this.paused = true;
        }
        private void ConstruireGraph()
        {
            chart = new CartesianChart();
            charts.Children.Add(chart);

            series = new StepLineSeries();
            series.PointGeometry = null;
            series.Stroke = Brushes.Black;
            series.Fill = Brushes.Black;
            chart.Series.Add(series);

            values = new ChartValues<int>();
            series.Values = values;
        }
       
        

    }
}

/*<lvc:CartesianChart Background="#222E31">
            <lvc:CartesianChart.Series>
                <lvc:LineSeries Name="lineSerie" Values="{Binding Values}" StrokeThickness="4" 
                Stroke="#6BBA45" Fill="Transparent" LineSmoothness="0" PointGeometry="{x:Null}" />
            </lvc:CartesianChart.Series>
        </lvc:CartesianChart>
*/