
using Asyncapi.Nats.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerCombatPlayerhitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerCombatPlayerhit temp = new ServerPlayerCombatPlayerhit();            
            string json1 = JsonConvert.SerializeObject(temp, Formatting.Indented, new ServerPlayerCombatPlayerhitConverter());
            ServerPlayerCombatPlayerhit output = JsonConvert.DeserializeObject<ServerPlayerCombatPlayerhit>(json1, new ServerPlayerCombatPlayerhitConverter());
            string json2 = JsonConvert.SerializeObject(output, Formatting.Indented, new ServerPlayerCombatPlayerhitConverter());
            Assert.Equal(json1, json2);
        }
    }
}