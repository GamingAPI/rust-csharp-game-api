namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(PlayerPositionConverter))]
  public class PlayerPosition
  {
    private double x;
    private double y;
    private double z;
    private Dictionary<string, object>? additionalProperties;

    public double X 
    {
      get { return x; }
      set { x = value; }
    }

    public double Y 
    {
      get { return y; }
      set { y = value; }
    }

    public double Z 
    {
      get { return z; }
      set { z = value; }
    }

    public Dictionary<string, object>? AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }
  public class PlayerPositionConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    PlayerPosition value = new PlayerPosition();
    if(jo["x"] != null) {
    value.X = jo["x"].ToObject<double>(serializer);
  }
  if(jo["y"] != null) {
    value.Y = jo["y"].ToObject<double>(serializer);
  }
  if(jo["z"] != null) {
    value.Z = jo["z"].ToObject<double>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "x" || prop.Name != "y" || prop.Name != "z");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    PlayerPosition value = (PlayerPosition)objValue;
    JObject jo = new JObject();
    if (value.X != null)
  {
    jo.Add("x", JToken.FromObject(value.X, serializer));
  }
  if (value.Y != null)
  {
    jo.Add("y", JToken.FromObject(value.Y, serializer));
  }
  if (value.Z != null)
  {
    jo.Add("z", JToken.FromObject(value.Z, serializer));
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