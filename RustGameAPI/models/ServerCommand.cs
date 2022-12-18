namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerCommandConverter))]
  public class ServerCommand
  {
    private string? command;
    private string? arguments;
    private string? steamId;
    private string timestamp;
    private Dictionary<string, object>? additionalProperties;

    public string? Command 
    {
      get { return command; }
      set { command = value; }
    }

    public string? Arguments 
    {
      get { return arguments; }
      set { arguments = value; }
    }

    public string? SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
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
  public class ServerCommandConverter : JsonConverter
  {
    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerCommand value = new ServerCommand();
    if(jo["command"] != null) {
    value.Command = jo["command"].ToObject<string?>(serializer);
  }
  if(jo["arguments"] != null) {
    value.Arguments = jo["arguments"].ToObject<string?>(serializer);
  }
  if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string?>(serializer);
  }
  if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }
    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "command" || prop.Name != "arguments" || prop.Name != "steam_id" || prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, object>();
    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, object objValue, JsonSerializer serializer)
  {
    ServerCommand value = (ServerCommand)objValue;
    JObject jo = new JObject();
    if (value.Command != null)
  {
    jo.Add("command", JToken.FromObject(value.Command, serializer));
  }
  if (value.Arguments != null)
  {
    jo.Add("arguments", JToken.FromObject(value.Arguments, serializer));
  }
  if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
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
  
    public override bool CanConvert(System.Type objectType)
    {
      return true;
    }
  }
}