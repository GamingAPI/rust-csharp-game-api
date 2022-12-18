namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerRespawnedConverter))]
  public class ServerPlayerRespawned
  {
    private string steamId;
    private string respawnTimestamp;
    private PlayerPosition respawnPosition;
    private Dictionary<string, object>? additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string RespawnTimestamp 
    {
      get { return respawnTimestamp; }
      set { respawnTimestamp = value; }
    }

    public PlayerPosition RespawnPosition 
    {
      get { return respawnPosition; }
      set { respawnPosition = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class ServerPlayerRespawnedConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerRespawned value = new ServerPlayerRespawned();
    if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["respawn_timestamp"] != null) {
    value.RespawnTimestamp = jo["respawn_timestamp"].ToObject<string>(serializer);
  }
  if(jo["respawn_position"] != null) {
    value.RespawnPosition = jo["respawn_position"].ToObject<PlayerPosition>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "steam_id" || prop.Name != "respawn_timestamp" || prop.Name != "respawn_position");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerPlayerRespawned value = (ServerPlayerRespawned)objValue;
    JObject jo = new JObject();
    if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.RespawnTimestamp != null)
  {
    jo.Add("respawn_timestamp", JToken.FromObject(value.RespawnTimestamp, serializer));
  }
  if (value.RespawnPosition != null)
  {
    jo.Add("respawn_position", JToken.FromObject(value.RespawnPosition, serializer));
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