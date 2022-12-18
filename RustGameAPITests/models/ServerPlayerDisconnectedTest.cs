
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerDisconnectedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerDisconnected temp = new ServerPlayerDisconnected();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerDisconnectedConverter());
            ServerPlayerDisconnected output = JsonConvert.DeserializeObject<ServerPlayerDisconnected>(json1, new ServerPlayerDisconnectedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerDisconnectedConverter());
            Assert.Equal(json1, json2);
        }
    }
}