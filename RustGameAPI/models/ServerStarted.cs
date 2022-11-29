extern alias NewtonsoftAlias;
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias::Newtonsoft.Json;
  using NewtonsoftAlias::Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerStartedConverter))]
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
    public override ServerStarted ReadJson(JsonReader reader, System.Type objectType, ServerStarted existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerStarted value = new ServerStarted();

    if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerStarted value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.Timestamp != null)
  {
    jo.Add("timestamp", JToken.FromObject(value.Timestamp, serializer));
  }
    if (value.AdditionalProperties != null)
    {
    foreach (var unwrapProperty in value.AdditionalProperties)
    {
      var hasProp = jo[unwrapProperty.Key]; 
      if (hasProp != null) continue;
      jo.Add(unwrapProperty.Key, JToken.FromObject(unwrapProperty.Value, serializer));
    }
  }

    jo.WriteTo(writer);
  }

    public override bool CanRead => true;
    public override bool CanWrite => true;
  }
}