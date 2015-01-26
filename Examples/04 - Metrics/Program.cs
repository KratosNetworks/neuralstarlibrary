using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MetricsExample example = new MetricsExample();
            example.CreateMetric();

            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
    }
}