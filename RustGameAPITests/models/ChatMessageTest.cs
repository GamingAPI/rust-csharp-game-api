
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ChatMessageTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ChatMessage temp = new ChatMessage();
            string json = JsonSerializer.Serialize(temp);
            ChatMessage output = JsonSerializer.Deserialize<ChatMessage>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}