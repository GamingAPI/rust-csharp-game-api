
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
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
            temp.Timestamp = "Test";
            temp.AdditionalProperties = new Dictionary<string, dynamic>();
            temp.AdditionalProperties.Add("TEsting", 123);
            temp.AdditionalProperties.Add("TEsting2", "test");
            ServerStarted temp2 = new ServerStarted();
            temp2.Timestamp = "Test";
            //temp.AdditionalProperties.Add("TEsting3", temp2);
            temp.AdditionalProperties.Add("TEsting4", true);
            string json = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerStartedConverter());
            ServerStarted output = JsonConvert.DeserializeObject<ServerStarted>(json, new ServerStartedConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerStartedConverter());
            Assert.Equal(json, json2);
        }
    }
}