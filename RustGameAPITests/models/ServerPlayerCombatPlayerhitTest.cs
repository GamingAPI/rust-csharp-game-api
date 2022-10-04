
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerCombatPlayerhitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerCombatPlayerhit temp = new ServerPlayerCombatPlayerhit();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerCombatPlayerhit output = JsonSerializer.Deserialize<ServerPlayerCombatPlayerhit>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}