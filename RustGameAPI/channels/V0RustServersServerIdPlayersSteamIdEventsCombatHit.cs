extern alias NewtonsoftAlias;
using NATS.Client;
using System;
using System.Text;
using NewtonsoftAlias::Newtonsoft.Json;
using Asyncapi.Nats.Client.Models;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdPlayersSteamIdEventsCombatHit
  {
    internal static byte[] JsonSerializerSupport(LoggingInterface logger, ServerPlayerCombatPlayerhit obj)
{
  var json = JsonConvert.SerializeObject(obj);
  logger.Debug("Serialized message " + json);
  return Encoding.UTF8.GetBytes(json);
}
public static void Publish(
  LoggingInterface logger,
IConnection connection,
ServerPlayerCombatPlayerhit requestMessage,
String server_id,String steam_id
){
  logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.players.{steam_id}.events.combat.hit");
  var serializedObject = JsonSerializerSupport(logger, requestMessage); 
  connection.Publish("v0.rust.servers.{server_id}.players.{steam_id}.events.combat.hit", serializedObject);
}
public static void JetStreamPublish(
  LoggingInterface logger,
IJetStream connection,
ServerPlayerCombatPlayerhit requestMessage,
String server_id,String steam_id
){
  logger.Debug("Publishing to jetstream channel: " + $"v0.rust.servers.{server_id}.players.{steam_id}.events.combat.hit");
  var serializedObject = JsonSerializerSupport(logger, requestMessage); 
  connection.Publish("v0.rust.servers.{server_id}.players.{steam_id}.events.combat.hit", serializedObject);
}
  }
}