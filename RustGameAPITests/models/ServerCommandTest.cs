
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerCommandTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerCommand temp = new ServerCommand();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerCommandConverter());
            ServerCommand output = JsonConvert.DeserializeObject<ServerCommand>(json1, new ServerCommandConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerCommandConverter());
            Assert.Equal(json1, json2);
        }
    }
}