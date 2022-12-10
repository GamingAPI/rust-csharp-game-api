
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerPositionTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerPosition temp = new PlayerPosition();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new PlayerPositionConverter());
            PlayerPosition output = JsonConvert.DeserializeObject<PlayerPosition>(json1, new PlayerPositionConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new PlayerPositionConverter());
            Assert.Equal(json1, json2);
        }
    }
}