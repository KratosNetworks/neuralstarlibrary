using System;
using System.Collections.Generic;
using System.Text;

namespace MetricsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MetricsExample example = new MetricsExample();
            //example.CreateMetric();

            int metricValue = 0;
            
            if (args.Length == 1)
            {
                metricValue = int.Parse(args[0]);
            }

            example.SubmitMetrics(metricValue);
        }
    }
}