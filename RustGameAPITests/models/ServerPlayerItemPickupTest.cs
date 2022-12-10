
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemPickupTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemPickup temp = new ServerPlayerItemPickup();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerItemPickupConverter());
            ServerPlayerItemPickup output = JsonConvert.DeserializeObject<ServerPlayerItemPickup>(json1, new ServerPlayerItemPickupConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerItemPickupConverter());
            Assert.Equal(json1, json2);
        }
    }
}