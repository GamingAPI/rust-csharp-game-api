
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerPositionTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerPosition temp = new PlayerPosition();
            string json = JsonSerializer.Serialize(temp);
            PlayerPosition output = JsonSerializer.Deserialize<PlayerPosition>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}