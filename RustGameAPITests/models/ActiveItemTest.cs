
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ActiveItemTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ActiveItem temp = new ActiveItem();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ActiveItemConverter());
            ActiveItem output = JsonConvert.DeserializeObject<ActiveItem>(json1, new ActiveItemConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ActiveItemConverter());
            Assert.Equal(json1, json2);
        }
    }
}