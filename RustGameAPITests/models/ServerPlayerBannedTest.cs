
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerBannedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerBanned temp = new ServerPlayerBanned();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerBannedConverter());
            ServerPlayerBanned output = JsonConvert.DeserializeObject<ServerPlayerBanned>(json1, new ServerPlayerBannedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerBannedConverter());
            Assert.Equal(json1, json2);
        }
    }
}