namespace LoggerAPI.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public string? CorrelationId { get; set; }
        public string? RequestPath { get; set; }
        public DateTime Timestamp { get; set; }
        public int ApiClientId { get; set; }
        public ApiClient ApiClient { get; set; }
    }
}
