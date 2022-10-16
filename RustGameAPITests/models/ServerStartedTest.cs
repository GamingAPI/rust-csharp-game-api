
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerStartedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerStarted temp = new ServerStarted();
            temp.Timestamp = "Test";
            string json = JsonSerializer.Serialize(temp);
            ServerStarted output = JsonSerializer.Deserialize<ServerStarted>(json);
            string json2 = JsonSerializer.Serialize(output);
            Assert.Equal(json, json2);
        }
    }
}