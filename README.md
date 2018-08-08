# Serilog.Sinks.Prometheus
A Serilog sink that writes log events to the Prometheus.

# Usage

```c#
Log.Logger = new LoggerConfiguration()
				.WriteTo.Prometheus("events_{0}", "Total count events of level {0}")
				.CreateLogger();
```

This will create prometheus counters with name "events_{Event.LogLevel}" and description "Total count events of level {Event.LogLevel}" containing total count of appropriate events.
