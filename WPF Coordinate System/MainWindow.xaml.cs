using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Coordinate_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<KeyValuePair<int, int>> ChartValues
        = new ObservableCollection<KeyValuePair<int, int>>();

        public ObservableCollection<KeyValuePair<int, int>> ChartValues2
        = new ObservableCollection<KeyValuePair<int, int>>();

        List<ObservableCollection<KeyValuePair<int, int>>> sources = new List<ObservableCollection<KeyValuePair<int, int>>>();

        public MainWindow()
        {
            InitializeComponent();
            sources.Add(ChartValues);
            sources.Add(ChartValues2);
            this.lineChart.DataContext = sources;
            //line1.DataContext = ChartValues;
            //line2.DataContext = ChartValues2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int inputX = Convert.ToInt32(this.XTxtInput.Text.ToString());
            int inputY = Convert.ToInt32(this.YTxtInput.Text.ToString());
            ChartValues.Add(new KeyValuePair<int, int>(inputX, inputY));

            ChartValues2.Add(new KeyValuePair<int, int>(inputX, inputY+1));
        }

        private void Selected_Clicked(object sender, SelectionChangedEventArgs e)
        {
            LineSeries s = sender as LineSeries;

            KeyValuePair<int, int> item = (KeyValuePair<int, int>)(s.SelectedItem);

            int x = item.Key;
            int y = item.Value;
        }

    }
}
