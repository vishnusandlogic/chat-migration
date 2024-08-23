namespace ChatMigration.Interfaces
{
    public interface IChatHistoryMigrationService
    {
        Task MigrateChatHistoryAsync();
    }
}
