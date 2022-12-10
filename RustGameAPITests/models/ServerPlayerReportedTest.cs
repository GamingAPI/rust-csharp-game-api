
using Asyncapi.Nats.Client.Models;
using NewtonsoftAlias.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerReportedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerReported temp = new ServerPlayerReported();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerReportedConverter());
            ServerPlayerReported output = JsonConvert.DeserializeObject<ServerPlayerReported>(json1, new ServerPlayerReportedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerReportedConverter());
            Assert.Equal(json1, json2);
        }
    }
}