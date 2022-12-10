
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            Player temp = new Player();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new PlayerConverter());
            Player output = JsonConvert.DeserializeObject<Player>(json1, new PlayerConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new PlayerConverter());
            Assert.Equal(json1, json2);
        }
    }
}