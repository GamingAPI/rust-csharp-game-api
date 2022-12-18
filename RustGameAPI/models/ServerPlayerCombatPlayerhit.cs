namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerCombatPlayerhitConverter))]
  public class ServerPlayerCombatPlayerhit
  {
    private string hitTimestamp;
    private PlayerOnPlayerHit playerHit;
    private Dictionary<string, object>? additionalProperties;

    public string HitTimestamp 
    {
      get { return hitTimestamp; }
      set { hitTimestamp = value; }
    }

    public PlayerOnPlayerHit PlayerHit 
    {
      get { return playerHit; }
      set { playerHit = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class ServerPlayerCombatPlayerhitConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerCombatPlayerhit value = new ServerPlayerCombatPlayerhit();
    if(jo["hit_timestamp"] != null) {
    value.HitTimestamp = jo["hit_timestamp"].ToObject<string>(serializer);
  }
  if(jo["player_hit"] != null) {
    value.PlayerHit = jo["player_hit"].ToObject<PlayerOnPlayerHit>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "hit_timestamp" || prop.Name != "player_hit");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerPlayerCombatPlayerhit value = (ServerPlayerCombatPlayerhit)objValue;
    JObject jo = new JObject();
    if (value.HitTimestamp != null)
  {
    jo.Add("hit_timestamp", JToken.FromObject(value.HitTimestamp, serializer));
  }
  if (value.PlayerHit != null)
  {
    jo.Add("player_hit", JToken.FromObject(value.PlayerHit, serializer));
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