extern alias NewtonsoftAlias;
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias::Newtonsoft.Json;
  using NewtonsoftAlias::Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerDisconnectedPlayerConverter))]
  public class ServerPlayerDisconnectedPlayer
  {
    private string id;
    private Dictionary<string, dynamic> additionalProperties;

    public string Id 
    {
      get { return id; }
      set { id = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerDisconnectedPlayerConverter : JsonConverter<ServerPlayerDisconnectedPlayer>
  {
    public override ServerPlayerDisconnectedPlayer ReadJson(JsonReader reader, System.Type objectType, ServerPlayerDisconnectedPlayer existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerDisconnectedPlayer value = new ServerPlayerDisconnectedPlayer();

    if(jo["id"] != null) {
    value.Id = jo["id"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "id");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerDisconnectedPlayer value, JsonSerializer serializer)
  {
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

    public override bool CanRead => true;
    public override bool CanWrite => true;
  }
}