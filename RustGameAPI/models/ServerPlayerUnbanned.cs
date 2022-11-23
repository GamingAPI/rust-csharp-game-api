namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerUnbannedConverter))]
  public class ServerPlayerUnbanned
  {
    private string steamId;
    private string name;
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string Name 
    {
      get { return name; }
      set { name = value; }
    }

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

  public class ServerPlayerUnbannedConverter : JsonConverter<ServerPlayerUnbanned>
  {
    public override ServerPlayerUnbanned ReadJson(JsonReader reader, System.Type objectType, ServerPlayerUnbanned existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerUnbanned value = new ServerPlayerUnbanned();

    if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["name"] != null) {
    value.Name = jo["name"].ToObject<string>(serializer);
  }
  if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "steam_id" || prop.Name != "name" || prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerUnbanned value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.Name != null)
  {
    jo.Add("name", JToken.FromObject(value.Name, serializer));
  }
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