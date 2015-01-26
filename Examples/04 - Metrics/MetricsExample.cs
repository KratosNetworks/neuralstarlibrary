using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Performance;

namespace Metrics
{
    public class MetricsExample
    {
        #region Private Variables
        User.SessionStatus _status;
        #endregion

        #region Private Methods
        private void Start()
        {
            _status = User.Login("a", "a");

            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Login Successful");
            } else {
                Console.WriteLine("Was not able to login");
            }
        }

        private void Stop()
        {
            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Logging out...");
                User.Logout();
            }
        }
        #endregion

        #region Public Methods
        public void CreateMetric()
        {
            try {
                Start();

                Metric performanceMetric = new AiMetrix.BusinessObject.Performance.Metric();

                performanceMetric.MetricName = "Average Furlongs Travelled";
                performanceMetric.MetricType = "Gauge";
                performanceMetric.MeasurementUnit = "raw";
                performanceMetric.MetricGroup = "Test Metrics";
                performanceMetric.Save();

                //Metric.SetAggregationEnabled(metricID, enabled);
                //Metric.SetMeasurementUnit(metricID, "hz");
                //Metric.SetDopplerColorID(metricID, dopplerColorID);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        /*
        try {
            Start();
        } catch (Exception ex) {
            Console.WriteLine("An exception has occured: " + ex.ToString());
        } finally {
            Stop();
        }
        */
        #endregion
    }
}