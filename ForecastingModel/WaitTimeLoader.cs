using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastingModel
{
    public class WaitTimeLoader
    {
        public static TimeSeries Load(string dataset)
        {
            //Create an ML.NET ML context
            var context = new MLContext();

            //Load data from the csv files
            var timeSeriesList = new List<TimeSeries>();
            Console.WriteLine($"Loading database wait times form '{dataset}'...");
            IDataView dataView = context.Data.LoadFromTextFile<WaitTime>
                (path: dataset, hasHeader: true, separatorChar: ',');
            WaitTime[] waitTimes = context.Data.CreateEnumerable<WaitTime>
                (dataView, reuseRowObject: false).ToArray();

            //Convert to time series
            var timeSeries = new TimeSeries(
                name: Path.GetFileName(dataset),
                observations: waitTimes.Select(s => s.ToObservation()),
                interval: TimeSpan.FromDays(1),
                group: "Database Wait Times");

            return timeSeries;
        }
    }
}
