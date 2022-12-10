
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class Test
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
             temp = new ();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new Converter());
             output = JsonConvert.DeserializeObject<>(json1, new Converter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new Converter());
            Assert.Equal(json1, json2);
        }
    }
}