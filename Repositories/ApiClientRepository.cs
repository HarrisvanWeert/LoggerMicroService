using LoggerAPI.Data;
using LoggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerAPI.Repositories
{
    public class ApiClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ApiClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LogEntry>> GetLogsForService(string serviceName)
        {
            return await _context.LogEntries
                .Include(l => l.ApiClient)
                .Where(l => l.ApiClient.ServiceName == serviceName)
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }

        public async Task<ApiClient> RegisterClientAsync(string serviceName)
        {
            var apiKey = Guid.NewGuid().ToString("N");

            var client = new ApiClient
            {
                ServiceName = serviceName,
                ApiKey = apiKey,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.ApiClients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }


    }
}
