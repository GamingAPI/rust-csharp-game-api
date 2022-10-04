
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemLootTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemLoot temp = new ServerPlayerItemLoot();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerItemLoot output = JsonSerializer.Deserialize<ServerPlayerItemLoot>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}