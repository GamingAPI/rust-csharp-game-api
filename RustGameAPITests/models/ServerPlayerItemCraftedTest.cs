
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemCraftedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemCrafted temp = new ServerPlayerItemCrafted();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerItemCraftedConverter());
            ServerPlayerItemCrafted output = JsonConvert.DeserializeObject<ServerPlayerItemCrafted>(json1, new ServerPlayerItemCraftedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerItemCraftedConverter());
            Assert.Equal(json1, json2);
        }
    }
}