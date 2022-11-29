extern alias NewtonsoftAlias;
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias::Newtonsoft.Json;
  using NewtonsoftAlias::Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerDisconnectedConverter))]
  public class ServerPlayerDisconnected
  {
    private string disconnectedTimestamp;
    private ServerPlayerDisconnectedPlayer player;
    private string reason;
    private Dictionary<string, dynamic> additionalProperties;

    public string DisconnectedTimestamp 
    {
      get { return disconnectedTimestamp; }
      set { disconnectedTimestamp = value; }
    }

    public ServerPlayerDisconnectedPlayer Player 
    {
      get { return player; }
      set { player = value; }
    }

    public string Reason 
    {
      get { return reason; }
      set { reason = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerDisconnectedConverter : JsonConverter<ServerPlayerDisconnected>
  {
    public override ServerPlayerDisconnected ReadJson(JsonReader reader, System.Type objectType, ServerPlayerDisconnected existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerDisconnected value = new ServerPlayerDisconnected();

    if(jo["disconnected_timestamp"] != null) {
    value.DisconnectedTimestamp = jo["disconnected_timestamp"].ToObject<string>(serializer);
  }
  if(jo["player"] != null) {
    value.Player = jo["player"].ToObject<ServerPlayerDisconnectedPlayer>(serializer);
  }
  if(jo["reason"] != null) {
    value.Reason = jo["reason"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "disconnected_timestamp" || prop.Name != "player" || prop.Name != "reason");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerDisconnected value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.DisconnectedTimestamp != null)
  {
    jo.Add("disconnected_timestamp", JToken.FromObject(value.DisconnectedTimestamp, serializer));
  }
  if (value.Player != null)
  {
    jo.Add("player", JToken.FromObject(value.Player, serializer));
  }
  if (value.Reason != null)
  {
    jo.Add("reason", JToken.FromObject(value.Reason, serializer));
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