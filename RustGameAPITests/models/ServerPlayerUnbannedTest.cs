
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerUnbannedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerUnbanned temp = new ServerPlayerUnbanned();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerUnbanned output = JsonSerializer.Deserialize<ServerPlayerUnbanned>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}