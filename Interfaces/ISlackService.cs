using ChatMigration.Models;

namespace ChatMigration.Interfaces
{
    public interface ISlackService
    {
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync();
    }
}
