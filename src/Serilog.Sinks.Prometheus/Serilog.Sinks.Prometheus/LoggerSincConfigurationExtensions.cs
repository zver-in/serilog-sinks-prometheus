using Serilog.Configuration;

namespace Serilog.Sinks.Prometheus
{
	public  static class LoggerSincConfigurationExtensions
	{
		public static LoggerConfiguration Prometheus(this LoggerSinkConfiguration sinkConfiguration, string counterNameTemplate, string counterDescription)
		{
			return sinkConfiguration.Sink(new PrometheusEventSink(counterNameTemplate, counterDescription));
		}
	}
}