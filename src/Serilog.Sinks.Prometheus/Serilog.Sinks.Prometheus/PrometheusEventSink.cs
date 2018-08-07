using System.Collections.Concurrent;
using Prometheus;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Sinks.Prometheus
{
	internal class PrometheusEventSink : ILogEventSink
	{
		private readonly string _counterNameTemplate;
		private readonly string _counterDescription;
		private readonly ConcurrentDictionary<string, Counter> _countersCache = new ConcurrentDictionary<string, Counter>();

		public PrometheusEventSink(string counterNameTemplate, string counterDescription)
		{
			_counterNameTemplate = counterNameTemplate;
			_counterDescription = counterDescription;
		}

		public void Emit(LogEvent logEvent)
		{
			var counterName = string.Format(_counterNameTemplate, logEvent.Level.ToString().ToLower());
			var counterDescription = string.Format(_counterDescription, logEvent.Level);

			var counter = _countersCache.GetOrAdd(counterName, n => Metrics.CreateCounter(counterName, counterDescription));
			counter.Inc();
		}
	}
}