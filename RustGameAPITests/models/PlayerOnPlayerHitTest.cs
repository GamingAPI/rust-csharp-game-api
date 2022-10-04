
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerOnPlayerHitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerOnPlayerHit temp = new PlayerOnPlayerHit();
            string json = JsonSerializer.Serialize(temp);
            PlayerOnPlayerHit output = JsonSerializer.Deserialize<PlayerOnPlayerHit>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}