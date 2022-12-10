
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerHitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerHit temp = new PlayerHit();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new PlayerHitConverter());
            PlayerHit output = JsonConvert.DeserializeObject<PlayerHit>(json1, new PlayerHitConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new PlayerHitConverter());
            Assert.Equal(json1, json2);
        }
    }
}