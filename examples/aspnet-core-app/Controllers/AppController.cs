using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notion.Client;

namespace aspnet_core_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private readonly INotionClient _notionClient;

        public AppController(ILogger<AppController> logger, INotionClient notionClient)
        {
            _logger = logger;
            _notionClient = notionClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _notionClient.Users.ListAsync());
        }
    }
}