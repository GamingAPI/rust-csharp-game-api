namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerItemPickupConverter))]
  public class ServerPlayerItemPickup
  {
    private string pickupTimestamp;
    private string steamId;
    private int itemUid;
    private int itemId;
    private int amount;
    private Dictionary<string, object> additionalProperties;

    public string PickupTimestamp 
    {
      get { return pickupTimestamp; }
      set { pickupTimestamp = value; }
    }

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public int ItemUid 
    {
      get { return itemUid; }
      set { itemUid = value; }
    }

    public int ItemId 
    {
      get { return itemId; }
      set { itemId = value; }
    }

    public int Amount 
    {
      get { return amount; }
      set { amount = value; }
    }

    public Dictionary<string, object> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerItemPickupConverter : JsonConverter<ServerPlayerItemPickup>
  {
    public override ServerPlayerItemPickup ReadJson(JsonReader reader, System.Type objectType, ServerPlayerItemPickup existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerItemPickup value = new ServerPlayerItemPickup();

    if(jo["pickup_timestamp"] != null) {
    value.PickupTimestamp = jo["pickup_timestamp"].ToObject<string>(serializer);
  }
  if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["item_uid"] != null) {
    value.ItemUid = jo["item_uid"].ToObject<int>(serializer);
  }
  if(jo["item_id"] != null) {
    value.ItemId = jo["item_id"].ToObject<int>(serializer);
  }
  if(jo["amount"] != null) {
    value.Amount = jo["amount"].ToObject<int>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "pickup_timestamp" || prop.Name != "steam_id" || prop.Name != "item_uid" || prop.Name != "item_id" || prop.Name != "amount");
    value.AdditionalProperties = new Dictionary<string, object>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerItemPickup value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.PickupTimestamp != null)
  {
    jo.Add("pickup_timestamp", JToken.FromObject(value.PickupTimestamp, serializer));
  }
  if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.ItemUid != null)
  {
    jo.Add("item_uid", JToken.FromObject(value.ItemUid, serializer));
  }
  if (value.ItemId != null)
  {
    jo.Add("item_id", JToken.FromObject(value.ItemId, serializer));
  }
  if (value.Amount != null)
  {
    jo.Add("amount", JToken.FromObject(value.Amount, serializer));
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