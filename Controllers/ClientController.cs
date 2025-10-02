namespace LoggerAPI.Controllers
{
    using LoggerAPI.Repositories;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="ClientController" />
    /// </summary>
    [ApiController]
    [Route("/api[controller]")]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Defines the _config
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Defines the _clientRepo
        /// </summary>
        private readonly ApiClientRepository _clientRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="config">The config<see cref="IConfiguration"/></param>
        /// <param name="clientRepo">The clientRepo<see cref="ApiClientRepository"/></param>
        public ClientController(IConfiguration config, ApiClientRepository clientRepo)
        {
            _config = config;
            _clientRepo = clientRepo;
        }

        /// <summary>
        /// The RegisterClient
        /// </summary>
        /// <param name="serviceName">The serviceName<see cref="string"/></param>
        /// <param name="adminKey">The adminKey<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterClient(
    [FromBody] string serviceName,
    [FromHeader(Name = "X-Admin-Key")] string adminKey)
        {
            var expectedKey = _config["AdminApiKey"]; // pulls from the active config (dev/prod/etc.)

            if (adminKey != expectedKey)
                return Unauthorized("Invalid admin key");

            var client = await _clientRepo.RegisterClientAsync(serviceName);

            return Ok(new { client.Id, client.ServiceName, client.ApiKey });
        }
    }
}
