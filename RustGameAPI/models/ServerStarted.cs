namespace Asyncapi.Nats.Client.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
  using System.Linq;
    public class ServerStarted
  {
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string Timestamp 
    {
      get { return timestamp; }
      set { timestamp = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
    public class ServerStartedConverter : JsonConverter<ServerStarted>
    {
        private readonly Type[] _types;

        public ServerStartedConverter(params Type[] types)
        {
            _types = types;
        }

        public override void WriteJson(JsonWriter writer, ServerStarted value, JsonSerializer serializer)
        {
            JObject jo = new JObject();

            if (value.Timestamp != null)
            {
                jo.Add("timestamp", JToken.FromObject(value.Timestamp, serializer));
            }
            // Unwrap additional properties in object
            if (value.AdditionalProperties != null)
            {
                foreach (var additionalProperty in value.AdditionalProperties)
                {
                    var hasProp = jo[additionalProperty.Key]; 
                    if (hasProp != null) continue;
                    jo.Add(additionalProperty.Key, JToken.FromObject(additionalProperty.Value, serializer));
                }
            }

            jo.WriteTo(writer);
        }

        public override ServerStarted ReadJson(JsonReader reader, Type objectType, ServerStarted existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            ServerStarted value = new ServerStarted();
            value.Timestamp = (string)jo["timestamp"];
            var additionalProperties = jo.Properties().Where((prop) => prop.Name != "timestamp");
            var coreProperties = jo.Properties().Where((prop) => prop.Name == "timestamp");
            value.AdditionalProperties = new Dictionary<string, dynamic>();

            foreach (var additionalProperty in additionalProperties)
            {
                value.AdditionalProperties[additionalProperty.Name] = JsonConvert.DeserializeObject(additionalProperty.Value.ToString());
            }
            return value;
        }

        public override bool CanRead => true;
        public override bool CanWrite => true;
    }
}