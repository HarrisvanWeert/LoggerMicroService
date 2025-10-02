using LoggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApiClient> ApiClients { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
    }

}
