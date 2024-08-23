using ChatMigration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatMigration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatMigrationController : Controller
    {
        private readonly IChatHistoryMigrationService _migrationService;

        public ChatMigrationController(IChatHistoryMigrationService migrationService)
        {
            _migrationService = migrationService;
        }

        [HttpPost("migrate")]
        public async Task<IActionResult> MigrateChatHistory()
        {
            await _migrationService.MigrateChatHistoryAsync();
            return Ok("Chat history migrated successfully.");
        }
    }
}
