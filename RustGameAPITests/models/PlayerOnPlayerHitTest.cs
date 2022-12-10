
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerOnPlayerHitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerOnPlayerHit temp = new PlayerOnPlayerHit();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new PlayerOnPlayerHitConverter());
            PlayerOnPlayerHit output = JsonConvert.DeserializeObject<PlayerOnPlayerHit>(json1, new PlayerOnPlayerHitConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new PlayerOnPlayerHitConverter());
            Assert.Equal(json1, json2);
        }
    }
}