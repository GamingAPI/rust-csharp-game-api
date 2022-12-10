
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerDisconnectedPlayerTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerDisconnectedPlayer temp = new ServerPlayerDisconnectedPlayer();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerDisconnectedPlayerConverter());
            ServerPlayerDisconnectedPlayer output = JsonConvert.DeserializeObject<ServerPlayerDisconnectedPlayer>(json1, new ServerPlayerDisconnectedPlayerConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerDisconnectedPlayerConverter());
            Assert.Equal(json1, json2);
        }
    }
}