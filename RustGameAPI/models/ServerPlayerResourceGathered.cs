namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerResourceGatheredConverter))]
  public class ServerPlayerResourceGathered
  {
    private string gatheredTimestamp;
    private string steamId;
    private int itemUid;
    private int itemId;
    private int amount;
    private ActiveItem gatheringItem;
    private PlayerPosition gatheringPosition;
    private Dictionary<string, dynamic> additionalProperties;

    public string GatheredTimestamp 
    {
      get { return gatheredTimestamp; }
      set { gatheredTimestamp = value; }
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

    public ActiveItem GatheringItem 
    {
      get { return gatheringItem; }
      set { gatheringItem = value; }
    }

    public PlayerPosition GatheringPosition 
    {
      get { return gatheringPosition; }
      set { gatheringPosition = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerResourceGatheredConverter : JsonConverter<ServerPlayerResourceGathered>
  {
    public override ServerPlayerResourceGathered ReadJson(JsonReader reader, System.Type objectType, ServerPlayerResourceGathered existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerResourceGathered value = new ServerPlayerResourceGathered();

    if(jo["gathered_timestamp"] != null) {
    value.GatheredTimestamp = jo["gathered_timestamp"].ToObject<string>(serializer);
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
  if(jo["gathering_item"] != null) {
    value.GatheringItem = jo["gathering_item"].ToObject<ActiveItem>(serializer);
  }
  if(jo["gathering_position"] != null) {
    value.GatheringPosition = jo["gathering_position"].ToObject<PlayerPosition>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "gathered_timestamp" || prop.Name != "steam_id" || prop.Name != "item_uid" || prop.Name != "item_id" || prop.Name != "amount" || prop.Name != "gathering_item" || prop.Name != "gathering_position");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerResourceGathered value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.GatheredTimestamp != null)
  {
    jo.Add("gathered_timestamp", JToken.FromObject(value.GatheredTimestamp, serializer));
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
  if (value.GatheringItem != null)
  {
    jo.Add("gathering_item", JToken.FromObject(value.GatheringItem, serializer));
  }
  if (value.GatheringPosition != null)
  {
    jo.Add("gathering_position", JToken.FromObject(value.GatheringPosition, serializer));
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