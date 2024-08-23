using ChatMigration.Interfaces;
using ChatMigration.Models;
using Newtonsoft.Json;
using System.Threading.Channels;

namespace ChatMigration.Services
{

    public class SlackService: ISlackService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public SlackService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync()
        {
            var client = _httpClientFactory.CreateClient("SlackClient");
            //var response = await client.GetAsync($"conversations.history?channel={channelId}");

            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    var messages = JsonConvert.DeserializeObject<IEnumerable<ChatMessage>>(content);
            //    return messages;
            //}
            //throw new Exception("Failed to retrieve chat history from Slack.");

            var response = await client.GetAsync("api/conversations.list");
            var content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(content);
            var channels = new List<Models.Channel>();

            foreach (var channel in result.channels)
            {
                channels.Add(new Models.Channel
                {
                    Id = channel.id,
                    Name = channel.name
                });
            }
            return null;
            //foreach (var channel in result.channels)
            //{
            //    if (channel.name == channelName)
            //    {
            //        return channel.id;
            //    }
            //}
            //throw new Exception($"Channel with name {channelName} not found.");
        }
    }
}
