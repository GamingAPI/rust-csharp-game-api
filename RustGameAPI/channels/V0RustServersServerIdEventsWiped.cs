extern alias NewtonsoftAlias;
using NATS.Client;
using System;
using System.Text;
using NewtonsoftAlias::Newtonsoft.Json;
using Asyncapi.Nats.Client.Models;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdEventsWiped
  {
    
public static void Publish(
  LoggingInterface logger,
IConnection connection,
String server_id
){
  logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.events.wiped");
  connection.Publish($"v0.rust.servers.{server_id}.events.wiped", Encoding.UTF8.GetBytes("null"));
}
public static void JetStreamPublish(
  LoggingInterface logger,
IJetStream connection,
String server_id
){
  logger.Debug("Publishing to jetstream channel: " + $"v0.rust.servers.{server_id}.events.wiped");
  connection.Publish($"v0.rust.servers.{server_id}.events.wiped", Encoding.UTF8.GetBytes("null"));
}
  }
}