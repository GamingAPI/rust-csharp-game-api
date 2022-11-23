
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ChatMessageTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ChatMessage temp = new ChatMessage();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ChatMessageConverter());
            ChatMessage output = JsonConvert.DeserializeObject<ChatMessage>(json1, new ChatMessageConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ChatMessageConverter());
            Assert.Equal(json1, json2);
        }
    }
}