
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemLootTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemLoot temp = new ServerPlayerItemLoot();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerItemLootConverter());
            ServerPlayerItemLoot output = JsonConvert.DeserializeObject<ServerPlayerItemLoot>(json1, new ServerPlayerItemLootConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerItemLootConverter());
            Assert.Equal(json1, json2);
        }
    }
}