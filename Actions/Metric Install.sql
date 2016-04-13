INSERT INTO MetricGroup( MetricGroupID, MetricGroup ) VALUES( CheckSum('Web Site Metrics'), 'Web Site Metrics' )

INSERT INTO Metric( MetricID, MetricGroupID, MetricName, MetricType, MeasurementUnit, DopplerColorID, LastUpdateTime, IsCalculatedMetric)
VALUES ( CONVERT(bigint, HASHBYTES('SHA1', 'WordCount')), CheckSum('Web Site Metrics'), 'WordCount',  'Gauge', 'words', 1, GETDATE(), 0)

select MetricID from Metric where MetricName = 'WordCount'