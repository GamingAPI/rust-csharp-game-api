extern alias NewtonsoftAlias;
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias::Newtonsoft.Json;
  using NewtonsoftAlias::Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ChatMessageConverter))]
  public class ChatMessage
  {
    private string steamId;
    private string playerName;
    private string rawMessage;
    private string fullMessage;
    private bool isAdmin;
    private int rank;
    private string title;
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string PlayerName 
    {
      get { return playerName; }
      set { playerName = value; }
    }

    public string RawMessage 
    {
      get { return rawMessage; }
      set { rawMessage = value; }
    }

    public string FullMessage 
    {
      get { return fullMessage; }
      set { fullMessage = value; }
    }

    public bool IsAdmin 
    {
      get { return isAdmin; }
      set { isAdmin = value; }
    }

    public int Rank 
    {
      get { return rank; }
      set { rank = value; }
    }

    public string Title 
    {
      get { return title; }
      set { title = value; }
    }

    public string Timestamp 
    {
      get { return timestamp; }
      set { timestamp = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ChatMessageConverter : JsonConverter<ChatMessage>
  {
    public override ChatMessage ReadJson(JsonReader reader, System.Type objectType, ChatMessage existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ChatMessage value = new ChatMessage();

    if(jo["steam_id"] != null) {
    value.SteamId = jo["steam_id"].ToObject<string>(serializer);
  }
  if(jo["player_name"] != null) {
    value.PlayerName = jo["player_name"].ToObject<string>(serializer);
  }
  if(jo["raw_message"] != null) {
    value.RawMessage = jo["raw_message"].ToObject<string>(serializer);
  }
  if(jo["full_message"] != null) {
    value.FullMessage = jo["full_message"].ToObject<string>(serializer);
  }
  if(jo["is_admin"] != null) {
    value.IsAdmin = jo["is_admin"].ToObject<bool>(serializer);
  }
  if(jo["rank"] != null) {
    value.Rank = jo["rank"].ToObject<int>(serializer);
  }
  if(jo["title"] != null) {
    value.Title = jo["title"].ToObject<string>(serializer);
  }
  if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "steam_id" || prop.Name != "player_name" || prop.Name != "raw_message" || prop.Name != "full_message" || prop.Name != "is_admin" || prop.Name != "rank" || prop.Name != "title" || prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, dynamic>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<dynamic>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ChatMessage value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.SteamId != null)
  {
    jo.Add("steam_id", JToken.FromObject(value.SteamId, serializer));
  }
  if (value.PlayerName != null)
  {
    jo.Add("player_name", JToken.FromObject(value.PlayerName, serializer));
  }
  if (value.RawMessage != null)
  {
    jo.Add("raw_message", JToken.FromObject(value.RawMessage, serializer));
  }
  if (value.FullMessage != null)
  {
    jo.Add("full_message", JToken.FromObject(value.FullMessage, serializer));
  }
  if (value.IsAdmin != null)
  {
    jo.Add("is_admin", JToken.FromObject(value.IsAdmin, serializer));
  }
  if (value.Rank != null)
  {
    jo.Add("rank", JToken.FromObject(value.Rank, serializer));
  }
  if (value.Title != null)
  {
    jo.Add("title", JToken.FromObject(value.Title, serializer));
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

    public override bool CanRead => true;
    public override bool CanWrite => true;
  }
}