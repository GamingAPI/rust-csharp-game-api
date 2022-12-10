namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using NewtonsoftAlias.Json;
  using Newtonsoft.Json.Linq;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerReportedConverter))]
  public class ServerPlayerReported
  {
    private string reporterSteamId;
    private string reportedTargetSteamId;
    private string subject;
    private string message;
    private string reportedType;
    private string timestamp;
    private Dictionary<string, object> additionalProperties;

    public string ReporterSteamId 
    {
      get { return reporterSteamId; }
      set { reporterSteamId = value; }
    }

    public string ReportedTargetSteamId 
    {
      get { return reportedTargetSteamId; }
      set { reportedTargetSteamId = value; }
    }

    public string Subject 
    {
      get { return subject; }
      set { subject = value; }
    }

    public string Message 
    {
      get { return message; }
      set { message = value; }
    }

    public string ReportedType 
    {
      get { return reportedType; }
      set { reportedType = value; }
    }

    public string Timestamp 
    {
      get { return timestamp; }
      set { timestamp = value; }
    }

    public Dictionary<string, object> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  public class ServerPlayerReportedConverter : JsonConverter<ServerPlayerReported>
  {
    public override ServerPlayerReported ReadJson(JsonReader reader, System.Type objectType, ServerPlayerReported existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    JObject jo = JObject.Load(reader);
    ServerPlayerReported value = new ServerPlayerReported();

    if(jo["reporter_steam_id"] != null) {
    value.ReporterSteamId = jo["reporter_steam_id"].ToObject<string>(serializer);
  }
  if(jo["reported_target_steam_id"] != null) {
    value.ReportedTargetSteamId = jo["reported_target_steam_id"].ToObject<string>(serializer);
  }
  if(jo["subject"] != null) {
    value.Subject = jo["subject"].ToObject<string>(serializer);
  }
  if(jo["message"] != null) {
    value.Message = jo["message"].ToObject<string>(serializer);
  }
  if(jo["reportedType"] != null) {
    value.ReportedType = jo["reportedType"].ToObject<string>(serializer);
  }
  if(jo["timestamp"] != null) {
    value.Timestamp = jo["timestamp"].ToObject<string>(serializer);
  }

    var additionalProperties = jo.Properties().Where((prop) => prop.Name != "reporter_steam_id" || prop.Name != "reported_target_steam_id" || prop.Name != "subject" || prop.Name != "message" || prop.Name != "reportedType" || prop.Name != "timestamp");
    value.AdditionalProperties = new Dictionary<string, object>();

    foreach (var additionalProperty in additionalProperties)
    {
      value.AdditionalProperties[additionalProperty.Name] = additionalProperty.Value.ToObject<object>(serializer);
    }
    return value;
  }
    public override void WriteJson(JsonWriter writer, ServerPlayerReported value, JsonSerializer serializer)
  {
    JObject jo = new JObject();

    if (value.ReporterSteamId != null)
  {
    jo.Add("reporter_steam_id", JToken.FromObject(value.ReporterSteamId, serializer));
  }
  if (value.ReportedTargetSteamId != null)
  {
    jo.Add("reported_target_steam_id", JToken.FromObject(value.ReportedTargetSteamId, serializer));
  }
  if (value.Subject != null)
  {
    jo.Add("subject", JToken.FromObject(value.Subject, serializer));
  }
  if (value.Message != null)
  {
    jo.Add("message", JToken.FromObject(value.Message, serializer));
  }
  if (value.ReportedType != null)
  {
    jo.Add("reportedType", JToken.FromObject(value.ReportedType, serializer));
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