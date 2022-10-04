
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerDisconnectedPlayerTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerDisconnectedPlayer temp = new ServerPlayerDisconnectedPlayer();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerDisconnectedPlayer output = JsonSerializer.Deserialize<ServerPlayerDisconnectedPlayer>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}