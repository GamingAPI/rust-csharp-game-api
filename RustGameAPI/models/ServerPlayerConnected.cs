namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerConnectedConverter))]
  public class ServerPlayerConnected
  {
    private string connectedTimestamp;
    private Player player;
    private Dictionary<string, dynamic> additionalProperties;

    public string ConnectedTimestamp 
    {
      get { return connectedTimestamp; }
      set { connectedTimestamp = value; }
    }

    public Player Player 
    {
      get { return player; }
      set { player = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerConnectedConverter : JsonConverter<ServerPlayerConnected>
  {
    public override ServerPlayerConnected ReadJson(JsonReader reader, System.Type objectType, ServerPlayerConnected existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerConnected value = new ServerPlayerConnected();

    if(jo["connected_timestamp"] != null) {
    value.ConnectedTimestamp = jo["connected_timestamp"].ToObject<string>(serializer);
  }
  if(jo["player"] != null) {
    value.Player = jo["player"].ToObject<Player>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "connected_timestamp" || prop.Name != "player");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerConnected value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.ConnectedTimestamp != null)
  {
    jo.Add("connected_timestamp", JToken.FromObject(value.ConnectedTimestamp, serializer));
  }
  if (value.Player != null)
  {
    jo.Add("player", JToken.FromObject(value.Player, serializer));
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