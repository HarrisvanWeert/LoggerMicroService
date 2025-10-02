namespace LoggerAPI.Models
{
    public class ApiClient
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ApiKey { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
    }
}
