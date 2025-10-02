using LoggerAPI.Data;
using LoggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LoggerAPI.Repositories
{
    public class LogRepository
    {
        private readonly ApplicationDbContext _context;

        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(LogEntry log)
        {
            _context.LogEntries.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
