namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(PlayerHitConverter))]
  public class PlayerHit
  {
    private string steamId;
    private PlayerPosition position;
    private ActiveItem activeItem;
    private Dictionary<string, object> additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public PlayerPosition Position 
    {
      get { return position; }
      set { position = value; }
    }

    public ActiveItem ActiveItem 
    {
      get { return activeItem; }
      set { activeItem = value; }
    }

    public Dictionary<string, object> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class PlayerHitConverter : JsonConverter<PlayerHit>
  {
    public override PlayerHit ReadJson(JsonReader reader, System.Type objectType, PlayerHit existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    PlayerHit value = new PlayerHit();

    if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["position"] != null) {
    value.Position = jo["position"].ToObject<PlayerPosition>(serializer);
  }
  if(jo["active_item"] != null) {
    value.ActiveItem = jo["active_item"].ToObject<ActiveItem>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "steam_id" || prop.Name != "position" || prop.Name != "active_item");
    value.AdditionalProperties = new Dictionary<string, object>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, PlayerHit value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.Position != null)
  {
    jo.Add("position", JToken.FromObject(value.Position, serializer));
  }
  if (value.ActiveItem != null)
  {
    jo.Add("active_item", JToken.FromObject(value.ActiveItem, serializer));
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