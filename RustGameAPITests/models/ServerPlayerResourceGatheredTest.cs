
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerResourceGatheredTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerResourceGathered temp = new ServerPlayerResourceGathered();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerResourceGatheredConverter());
            ServerPlayerResourceGathered output = JsonConvert.DeserializeObject<ServerPlayerResourceGathered>(json1, new ServerPlayerResourceGatheredConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerResourceGatheredConverter());
            Assert.Equal(json1, json2);
        }
    }
}