namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerBannedConverter))]
  public class ServerPlayerBanned
  {
    private string playerName;
    private string steamId;
    private string? reason;
    private string? duration;
    private string timestamp;
    private Dictionary<string, object>? additionalProperties;

    public string PlayerName 
    {
      get { return playerName; }
      set { playerName = value; }
    }

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string? Reason 
    {
      get { return reason; }
      set { reason = value; }
    }

    public string? Duration 
    {
      get { return duration; }
      set { duration = value; }
    }

    public string Timestamp 
    {
      get { return timestamp; }
      set { timestamp = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class ServerPlayerBannedConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerBanned value = new ServerPlayerBanned();
    if(jo["player_name"] != null) {
    value.PlayerName = jo["player_name"].ToObject<string>(serializer);
  }
  if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["reason"] != null) {
    value.Reason = jo["reason"].ToObject<string?>(serializer);
  }
  if(jo["duration"] != null) {
    value.Duration = jo["duration"].ToObject<string?>(serializer);
  }
  if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "player_name" || prop.Name != "steam_id" || prop.Name != "reason" || prop.Name != "duration" || prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerPlayerBanned value = (ServerPlayerBanned)objValue;
    JObject jo = new JObject();
    if (value.PlayerName != null)
  {
    jo.Add("player_name", JToken.FromObject(value.PlayerName, serializer));
  }
  if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.Reason != null)
  {
    jo.Add("reason", JToken.FromObject(value.Reason, serializer));
  }
  if (value.Duration != null)
  {
    jo.Add("duration", JToken.FromObject(value.Duration, serializer));
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
  
    public override bool CanConvert(Type objectType)
    {
      return true;
    }
  }
}