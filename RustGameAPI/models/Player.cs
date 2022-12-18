namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(PlayerConverter))]
  public class Player
  {
    private string id;
    private string name;
    private string address;
    private Dictionary<string, object>? additionalProperties;

    public string Id 
    {
      get { return id; }
      set { id = value; }
    }

    public string Name 
    {
      get { return name; }
      set { name = value; }
    }

    public string Address 
    {
      get { return address; }
      set { address = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class PlayerConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    Player value = new Player();
    if(jo["id"] != null) {
    value.Id = jo["id"].ToObject<string>(serializer);
  }
  if(jo["name"] != null) {
    value.Name = jo["name"].ToObject<string>(serializer);
  }
  if(jo["address"] != null) {
    value.Address = jo["address"].ToObject<string>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "id" || prop.Name != "name" || prop.Name != "address");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    Player value = (Player)objValue;
    JObject jo = new JObject();
    if (value.Id != null)
  {
    jo.Add("id", JToken.FromObject(value.Id, serializer));
  }
  if (value.Name != null)
  {
    jo.Add("name", JToken.FromObject(value.Name, serializer));
  }
  if (value.Address != null)
  {
    jo.Add("address", JToken.FromObject(value.Address, serializer));
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