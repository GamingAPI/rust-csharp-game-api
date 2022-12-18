
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerConnectedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerConnected temp = new ServerPlayerConnected();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerConnectedConverter());
            ServerPlayerConnected output = JsonConvert.DeserializeObject<ServerPlayerConnected>(json1, new ServerPlayerConnectedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerConnectedConverter());
            Assert.Equal(json1, json2);
        }
    }
}