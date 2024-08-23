using ChatMigration.Interfaces;
using ChatMigration.Models;
using Newtonsoft.Json;
using System.Text;

namespace ChatMigration.Services
{
    public class TeamsService: ITeamsService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TeamsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task PostChatHistoryAsync(IEnumerable<ChatMessage> messages)
        {
            var client = _httpClientFactory.CreateClient("TeamsClient");
            var content = new StringContent(JsonConvert.SerializeObject(messages), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/chat.post", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to post chat history to Teams.");
            }
        }
    }
}
