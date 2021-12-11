using Serilog.Core;
using Serilog.Events;

namespace BlueBank.SharedApplication.Logging
{
    public class StaticPropertyEnricher : ILogEventEnricher
    {
        private readonly string _propertyValue;
        private readonly string _propertyName;

        private LogEventProperty _property;
        private LogEventProperty GetProperty(ILogEventPropertyFactory factory)
            => _property ?? (_property = factory.CreateProperty(_propertyName, _propertyValue));

        public StaticPropertyEnricher(string propertyName, string propertyValue)
        {
            _propertyName = propertyName;
            _propertyValue = propertyValue;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(GetProperty(propertyFactory));
        }
    }
}