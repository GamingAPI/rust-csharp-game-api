namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerItemLootConverter))]
  public class ServerPlayerItemLoot
  {
    private string lootTimestamp;
    private string steamId;
    private int itemUid;
    private int itemId;
    private int containerUid;
    private string containerPrefab;
    private PlayerPosition? containerPosition;
    private int amount;
    private Dictionary<string, object>? additionalProperties;

    public string LootTimestamp 
    {
      get { return lootTimestamp; }
      set { lootTimestamp = value; }
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

    public int ContainerUid 
    {
      get { return containerUid; }
      set { containerUid = value; }
    }

    public string ContainerPrefab 
    {
      get { return containerPrefab; }
      set { containerPrefab = value; }
    }

    public PlayerPosition? ContainerPosition 
    {
      get { return containerPosition; }
      set { containerPosition = value; }
    }

    public int Amount 
    {
      get { return amount; }
      set { amount = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class ServerPlayerItemLootConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerItemLoot value = new ServerPlayerItemLoot();
    if(jo["loot_timestamp"] != null) {
    value.LootTimestamp = jo["loot_timestamp"].ToObject<string>(serializer);
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
  if(jo["container_uid"] != null) {
    value.ContainerUid = jo["container_uid"].ToObject<int>(serializer);
  }
  if(jo["container_prefab"] != null) {
    value.ContainerPrefab = jo["container_prefab"].ToObject<string>(serializer);
  }
  if(jo["container_position"] != null) {
    value.ContainerPosition = jo["container_position"].ToObject<PlayerPosition?>(serializer);
  }
  if(jo["amount"] != null) {
    value.Amount = jo["amount"].ToObject<int>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "loot_timestamp" || prop.Name != "steam_id" || prop.Name != "item_uid" || prop.Name != "item_id" || prop.Name != "container_uid" || prop.Name != "container_prefab" || prop.Name != "container_position" || prop.Name != "amount");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerPlayerItemLoot value = (ServerPlayerItemLoot)objValue;
    JObject jo = new JObject();
    if (value.LootTimestamp != null)
  {
    jo.Add("loot_timestamp", JToken.FromObject(value.LootTimestamp, serializer));
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
  if (value.ContainerUid != null)
  {
    jo.Add("container_uid", JToken.FromObject(value.ContainerUid, serializer));
  }
  if (value.ContainerPrefab != null)
  {
    jo.Add("container_prefab", JToken.FromObject(value.ContainerPrefab, serializer));
  }
  if (value.ContainerPosition != null)
  {
    jo.Add("container_position", JToken.FromObject(value.ContainerPosition, serializer));
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
  
    public override bool CanConvert(System.Type objectType)
    {
      return true;
    }
  }
}