using Serilog;

namespace BlueBank.SharedApplication.Logging
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration SetApplicationName(this LoggerConfiguration configuration, string appName)
        {
            configuration.Enrich.With(new StaticPropertyEnricher("appName", appName));
            return configuration;
        }
        public static LoggerConfiguration SetEnvironmentName(this LoggerConfiguration configuration, string environmentName)
        {
            configuration.Enrich.With(new StaticPropertyEnricher("environment", environmentName));
            return configuration;
        }
    }
}