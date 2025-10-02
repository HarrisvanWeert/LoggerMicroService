using LoggerAPI.Models;
using LoggerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly LogRepository _logRepository;

        public LogsController(LogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogEntry log)
        {
            if (log == null || string.IsNullOrEmpty(log.Message) || string.IsNullOrEmpty(log.LogLevel))
                return BadRequest("LogLevel and Message are required");

            await _logRepository.AddLogAsync(log);
            return Ok(new { message = "Log created", logid = log.Id});
        }

    }
}
