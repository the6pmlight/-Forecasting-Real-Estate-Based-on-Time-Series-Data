using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlot.Plotly;

namespace ForecastingModel
{
    public static class ChartBuilder
    {
        public static PlotlyChart BuildChart(TimeSeriesAnalysis analysis)
        {
            IEnumerable<Trace> traces = BuildTraces(analysis);
            PlotlyChart chart = BuildPlotlyChart(analysis.TimeSeries.Name, traces);
            return chart;
        }

        private static PlotlyChart BuildPlotlyChart(string chartTitle, IEnumerable<Trace> traces)
        {
            PlotlyChart chart = Chart.Plot(traces);

            var layout = new Layout.Layout { title = chartTitle };
            chart.WithLayout(layout);
            chart.Width = 800;
            chart.Height = 600;
            chart.WithXTitle("Date");
            chart.WithYTitle("Price - Million VND/m2");
            chart.WithLegend(true);

            return chart;
        }

        private static IEnumerable<Trace> BuildTraces(TimeSeriesAnalysis analysis)
        {
            yield return BuildTrace("Historical", analysis.Historical);
            yield return BuildTrace("Actual", analysis.Actual);

            foreach(ForecastDetails forecastDetails in analysis.Forecasts)
            {
                string name = $"{forecastDetails.AlgorithmName} Forecast";
                yield return BuildTrace(name, forecastDetails.Forecast);
            }
        }

        private static Trace BuildTrace(string name, IEnumerable<Observation> observations)
        {
            DateTime[] dates = observations.Select(s => s.Date).ToArray();
            float[] values = observations.Select(s => s.Value).ToArray();

            return new Scatter()
            {
                name = name,
                x = dates,
                y = values
            };
        }
    }
}
