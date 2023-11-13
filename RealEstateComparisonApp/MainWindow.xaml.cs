using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using XPlot.Plotly;
//using XPlot.Plotly.Graph;
using Microsoft.Win32;
using ForecastingModel;
using Microsoft.ML.Data;

namespace RealEstateComparisonApp
{
    public partial class MainWindow : Window
    {
        private List<TimeSeries> timeSeriesList = new List<TimeSeries>();

        public MainWindow()
        {
            InitializeComponent();
            AddYearsItemToComboBox();
        }

        private void AddYearsItemToComboBox()
        {
            int currentYear = DateTime.Now.Year;
            cboYear.Items.Add("All");

            for (int year = currentYear; year >= 2000; year--)
            {
                cboYear.Items.Add(year.ToString());
            }

            cboYear.SelectedItem = currentYear.ToString();
        }

        private void btnPickDataset_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                txtDataset.Text = string.Join(";", openFileDialog.FileNames);
            }
        }

        private async void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            string[] fileNames = txtDataset.Text.Split(';');
            List<Scattergl> scatters = new List<Scattergl>();
            timeSeriesList = new List<TimeSeries>();

            foreach (string fileName in fileNames)
            {
                TimeSeries timeSeries = WaitTimeLoader.Load(fileName);
                timeSeriesList.Add(timeSeries);

                IEnumerable<Observation> recordsForYear = GetRecordsForSelectedYear(timeSeries);

                DateTime[] dates = recordsForYear.Select(o => o.Date).ToArray();
                float[] values = recordsForYear.Select(o => o.Value).ToArray();

                scatters.Add(new Scattergl()
                {
                    x = dates,
                    y = values,
                    name = System.IO.Path.GetFileName(fileName),
                    mode = "lines"
                });
            }

            PlotlyChart chart = Chart.Plot(scatters);
            chart.WithTitle($"Price Comparison Year {cboYear.Text}");
            chart.Width = (int)this.Width - 100;
            chart.Height = (int)this.Height - 100;
            chart.WithXTitle("Date");
            chart.WithYTitle("Price - Million VND/m2");
            chart.WithLegend(true);

            await myWebBrowser.EnsureCoreWebView2Async();
            myWebBrowser.NavigateToString(chart.GetHtml());
        }

        private IEnumerable<Observation> GetRecordsForSelectedYear(TimeSeries timeSeries)
        {
            if (cboYear.Text == "All")
            {
                return timeSeries.Observations;
            }
            else
            {
                int targetYear = int.Parse(cboYear.Text);
                return timeSeries.Observations.Where(record => record.Date.Year == targetYear);
            }
        }


    }
}
