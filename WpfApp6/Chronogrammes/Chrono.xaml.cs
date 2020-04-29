using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Configurations;

namespace Projet.Chronogrammes
{
    /// <summary>
    /// Interaction logic for Chrono.xaml
    /// </summary>
    public partial class Chrono : UserControl, INotifyPropertyChanged
    {

        bool paused = false;
        private double _axisMax;
        private double _axisMin;
        int t = 0;



        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }
        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }
        public Chrono()
        {
            InitializeComponent();
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)
                .Y(model => model.Value);
            Charting.For<MeasureModel>(mapper);
            ChartValues = new ChartValues<MeasureModel>();
            DateTimeFormatter = value => new DateTime((long)value).ToString("ss");
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            AxisUnit = TimeSpan.TicksPerSecond;
            SetAxisLimits(DateTime.Now);
            chart.DisableAnimations = true;
            DataContext = this;

        }
        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // 1 
            AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; // 8 
            t++;
        }



        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public void AjoutVal(int v)
        {

            if (!this.paused)
            {


                DateTime now = DateTime.Now;
                ChartValues.Add(new MeasureModel
                {

                    DateTime = now,
                    Value = v
                }); ;

                SetAxisLimits(now);

                // if (ChartValues.Count > 150) ChartValues.RemoveAt(0);



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





    }
    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public int Value { get; set; }
    }
}

/*<lvc:CartesianChart Background="#222E31">
            <lvc:CartesianChart.Series>
                <lvc:LineSeries Name="lineSerie" Values="{Binding Values}" StrokeThickness="4" 
                Stroke="#6BBA45" Fill="Transparent" LineSmoothness="0" PointGeometry="{x:Null}" />
            </lvc:CartesianChart.Series>
        </lvc:CartesianChart>
*/
