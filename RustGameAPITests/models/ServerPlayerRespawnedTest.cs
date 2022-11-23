
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerRespawnedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerRespawned temp = new ServerPlayerRespawned();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerRespawnedConverter());
            ServerPlayerRespawned output = JsonConvert.DeserializeObject<ServerPlayerRespawned>(json1, new ServerPlayerRespawnedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerRespawnedConverter());
            Assert.Equal(json1, json2);
        }
    }
}