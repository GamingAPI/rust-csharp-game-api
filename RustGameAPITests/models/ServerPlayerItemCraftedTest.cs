
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemCraftedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemCrafted temp = new ServerPlayerItemCrafted();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerItemCrafted output = JsonSerializer.Deserialize<ServerPlayerItemCrafted>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}