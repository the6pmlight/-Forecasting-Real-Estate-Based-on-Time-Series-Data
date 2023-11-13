using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastingModel
{
    public class ForecastDetails
    {
        public string AlgorithmName { get; }
        public Observation[] Forecast { get; }
        public RegressionMetrics RegressionMetrics { get; }

        public ForecastDetails(
            string algorithmName,
            IEnumerable<Observation> forecast,
            RegressionMetrics regressionMetrics)
        {
            AlgorithmName = algorithmName;
            Forecast = forecast.ToArray();
            RegressionMetrics = regressionMetrics;
        }
    }
}
