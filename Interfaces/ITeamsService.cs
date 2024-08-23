using ChatMigration.Models;

namespace ChatMigration.Interfaces
{
    public interface ITeamsService
    {
        Task PostChatHistoryAsync(IEnumerable<ChatMessage> messages);
    }
}
