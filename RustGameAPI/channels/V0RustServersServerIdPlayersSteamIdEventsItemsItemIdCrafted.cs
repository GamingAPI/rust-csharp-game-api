using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted
  {


internal static byte[] JsonSerializerSupport(LoggingInterface logger, ServerPlayerItemCrafted obj)
{
  var json = JsonSerializer.Serialize(obj);
  logger.Debug("Serialized message " + json);
  return Encoding.UTF8.GetBytes(json);
}

public static void Publish(
  LoggingInterface logger,
IEncodedConnection connection,
ServerPlayerItemCrafted requestMessage,
String server_id,String steam_id,String item_id
){
  logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.players.{steam_id}.events.items.{item_id}.crafted");
  var serializedObject = JsonSerializerSupport(logger, requestMessage); 
  connection.Publish("v0.rust.servers.{server_id}.players.{steam_id}.events.items.{item_id}.crafted", serializedObject);
}
  }
}