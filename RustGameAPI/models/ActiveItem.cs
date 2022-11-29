extern alias NewtonsoftAlias;
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias::Newtonsoft.Json;
  using NewtonsoftAlias::Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ActiveItemConverter))]
  public class ActiveItem
  {
    private int uid;
    private int itemId;
    private Dictionary<string, dynamic> additionalProperties;

    public int Uid 
    {
      get { return uid; }
      set { uid = value; }
    }

    public int ItemId 
    {
      get { return itemId; }
      set { itemId = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ActiveItemConverter : JsonConverter<ActiveItem>
  {
    public override ActiveItem ReadJson(JsonReader reader, System.Type objectType, ActiveItem existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ActiveItem value = new ActiveItem();

    if(jo["uid"] != null) {
    value.Uid = jo["uid"].ToObject<int>(serializer);
  }
  if(jo["item_id"] != null) {
    value.ItemId = jo["item_id"].ToObject<int>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "uid" || prop.Name != "item_id");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ActiveItem value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.Uid != null)
  {
    jo.Add("uid", JToken.FromObject(value.Uid, serializer));
  }
  if (value.ItemId != null)
  {
    jo.Add("item_id", JToken.FromObject(value.ItemId, serializer));
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