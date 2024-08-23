using ChatMigration.Interfaces;

namespace ChatMigration.Services
{
    public class ChatHistoryMigrationService: IChatHistoryMigrationService
    {

        private readonly ISlackService _slackService;
        private readonly ITeamsService _teamsService;

        public ChatHistoryMigrationService(ISlackService slackService, ITeamsService teamsService)
        {
            _slackService = slackService;
            _teamsService = teamsService;
        }

        public async Task MigrateChatHistoryAsync()
        {
            var messages = await _slackService.GetChatHistoryAsync();
            await _teamsService.PostChatHistoryAsync(messages);
        }
    }
}
