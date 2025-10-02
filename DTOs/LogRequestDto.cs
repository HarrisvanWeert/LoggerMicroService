namespace LoggerAPI.DTOs
{
    public class LogRequestDto
    {
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string? CorrelationId { get; set; }
        public string? Exception { get; set; }
        public string? RequestPath { get; set; }
    }
}
