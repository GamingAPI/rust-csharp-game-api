
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerUnbannedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerUnbanned temp = new ServerPlayerUnbanned();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerUnbannedConverter());
            ServerPlayerUnbanned output = JsonConvert.DeserializeObject<ServerPlayerUnbanned>(json1, new ServerPlayerUnbannedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerUnbannedConverter());
            Assert.Equal(json1, json2);
        }
    }
}