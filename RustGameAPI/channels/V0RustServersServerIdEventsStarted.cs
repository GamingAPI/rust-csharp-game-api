using NATS.Client;
using System;
using System.Text;
using Newtonsoft.Json;
using Asyncapi.Nats.Client.Models;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdEventsStarted
  {
    internal static byte[] JsonSerializerSupport(LoggingInterface logger, ServerStarted obj)
{
  var json = JsonConvert.SerializeObject(obj);
  logger.Debug("Serialized message " + json);
  return Encoding.UTF8.GetBytes(json);
}
public static void Publish(
  LoggingInterface logger,
IConnection connection,
ServerStarted requestMessage,
String server_id
){
  logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.events.started");
  var serializedObject = JsonSerializerSupport(logger, requestMessage); 
  connection.Publish("v0.rust.servers.{server_id}.events.started", serializedObject);
}
public static void JetStreamPublish(
  LoggingInterface logger,
IJetStream connection,
ServerStarted requestMessage,
String server_id
){
  logger.Debug("Publishing to jetstream channel: " + $"v0.rust.servers.{server_id}.events.started");
  var serializedObject = JsonSerializerSupport(logger, requestMessage); 
  connection.Publish("v0.rust.servers.{server_id}.events.started", serializedObject);
}
  }
}