using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Performance;
using AiMetrix.BusinessObject.Inventory;

namespace MetricsExample
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

                Metric performanceMetric = new Metric();

                performanceMetric.MetricName = "Average Furlongs Travelled";
                performanceMetric.MetricType = "Gauge";
                performanceMetric.MeasurementUnit = "ms";
                performanceMetric.MetricGroup = "Test Metrics";
                performanceMetric.Save();
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void SubmitMetrics(int metricValue)
        {
            try
            {
                Start();

                Guid NSObjectID = NSObjects.GetByDisplayName("Test Object")[0].NSObjectID;
                
                MeasurementCollector mc = new MeasurementCollector();
                mc.AddPointMeasurement(NSObjectID, 4619608813928850246, metricValue, DateTime.UtcNow);
                mc.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            }
            finally
            {
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