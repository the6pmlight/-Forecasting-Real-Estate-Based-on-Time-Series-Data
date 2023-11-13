﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastingModel
{
    public class TimeSeriesAnalysis
    {
        public TimeSeries TimeSeries { get; }
        public Observation[] Historical { get; }
        public Observation[] Actual { get; }
        public ForecastDetails[] Forecasts { get; }
        public RegressionMetrics LinearRegressionMetric { get; set; }
        public RegressionMetrics SingularSpectrumMetric { get; set; }

        public TimeSeriesAnalysis(
            TimeSeries timeSeries,
            IEnumerable<Observation> historical,
            IEnumerable<Observation> actual,
            IEnumerable<ForecastDetails> forecasts)
        {
            TimeSeries = timeSeries;
            Historical = historical.ToArray();
            Actual = actual.ToArray();
            Forecasts = forecasts.ToArray();
        }
    }
}
