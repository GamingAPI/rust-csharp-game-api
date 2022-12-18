namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerDisconnectedPlayerConverter))]
  public class ServerPlayerDisconnectedPlayer
  {
    private string id;
    private Dictionary<string, object>? additionalProperties;

    public string Id 
    {
      get { return id; }
      set { id = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class ServerPlayerDisconnectedPlayerConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerDisconnectedPlayer value = new ServerPlayerDisconnectedPlayer();
    if(jo["id"] != null) {
    value.Id = jo["id"].ToObject<string>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "id");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerPlayerDisconnectedPlayer value = (ServerPlayerDisconnectedPlayer)objValue;
    JObject jo = new JObject();
    if (value.Id != null)
  {
    jo.Add("id", JToken.FromObject(value.Id, serializer));
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
  
    public override bool CanConvert(System.Type objectType)
    {
      return true;
    }
  }
}