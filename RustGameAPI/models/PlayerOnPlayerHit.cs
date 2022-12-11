namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias.Json;
  using NewtonsoftAlias.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(PlayerOnPlayerHitConverter))]
  public class PlayerOnPlayerHit
  {
    private int hitAreaId;
    private double hitDistance;
    private double hitDamage;
    private bool isKill;
    private PlayerHit victim;
    private PlayerHit attacker;
    private Dictionary<string, object> additionalProperties;

    public int HitAreaId 
    {
      get { return hitAreaId; }
      set { hitAreaId = value; }
    }

    public double HitDistance 
    {
      get { return hitDistance; }
      set { hitDistance = value; }
    }

    public double HitDamage 
    {
      get { return hitDamage; }
      set { hitDamage = value; }
    }

    public bool IsKill 
    {
      get { return isKill; }
      set { isKill = value; }
    }

    public PlayerHit Victim 
    {
      get { return victim; }
      set { victim = value; }
    }

    public PlayerHit Attacker 
    {
      get { return attacker; }
      set { attacker = value; }
    }

    public Dictionary<string, object> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class PlayerOnPlayerHitConverter : JsonConverter<PlayerOnPlayerHit>
  {
    public override PlayerOnPlayerHit ReadJson(JsonReader reader, System.Type objectType, PlayerOnPlayerHit existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    PlayerOnPlayerHit value = new PlayerOnPlayerHit();

    if(jo["hit_area_id"] != null) {
    value.HitAreaId = jo["hit_area_id"].ToObject<int>(serializer);
  }
  if(jo["hit_distance"] != null) {
    value.HitDistance = jo["hit_distance"].ToObject<double>(serializer);
  }
  if(jo["hit_damage"] != null) {
    value.HitDamage = jo["hit_damage"].ToObject<double>(serializer);
  }
  if(jo["isKill"] != null) {
    value.IsKill = jo["isKill"].ToObject<bool>(serializer);
  }
  if(jo["victim"] != null) {
    value.Victim = jo["victim"].ToObject<PlayerHit>(serializer);
  }
  if(jo["attacker"] != null) {
    value.Attacker = jo["attacker"].ToObject<PlayerHit>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "hit_area_id" || prop.Name != "hit_distance" || prop.Name != "hit_damage" || prop.Name != "isKill" || prop.Name != "victim" || prop.Name != "attacker");
    value.AdditionalProperties = new Dictionary<string, object>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, PlayerOnPlayerHit value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.HitAreaId != null)
  {
    jo.Add("hit_area_id", JToken.FromObject(value.HitAreaId, serializer));
  }
  if (value.HitDistance != null)
  {
    jo.Add("hit_distance", JToken.FromObject(value.HitDistance, serializer));
  }
  if (value.HitDamage != null)
  {
    jo.Add("hit_damage", JToken.FromObject(value.HitDamage, serializer));
  }
  if (value.IsKill != null)
  {
    jo.Add("isKill", JToken.FromObject(value.IsKill, serializer));
  }
  if (value.Victim != null)
  {
    jo.Add("victim", JToken.FromObject(value.Victim, serializer));
  }
  if (value.Attacker != null)
  {
    jo.Add("attacker", JToken.FromObject(value.Attacker, serializer));
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