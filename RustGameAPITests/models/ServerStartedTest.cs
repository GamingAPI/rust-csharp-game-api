
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerStartedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerStarted temp = new ServerStarted();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerStartedConverter());
            ServerStarted output = JsonConvert.DeserializeObject<ServerStarted>(json1, new ServerStartedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerStartedConverter());
            Assert.Equal(json1, json2);
        }
    }
}