using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client.Channels
{
    class V0RustServersServerIdEventsPlayerSteamIdChatted
    {


        internal static byte[] JsonSerializerSupport(LoggingInterface logger, ChatMessage obj)
        {
            var json = JsonSerializer.Serialize(obj);
            logger.Debug("Serialized message " + json);
            return Encoding.UTF8.GetBytes(json);
        }

        public static void Publish(
          LoggingInterface logger,
        IConnection connection,
        ChatMessage requestMessage,
        String server_id, String steam_id
        ) {
            logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.events.player.{steam_id}.chatted");
            var serializedObject = JsonSerializerSupport(logger, requestMessage);
            connection.Publish($"v0.rust.servers.{server_id}.events.player.{steam_id}.chatted", serializedObject);
        }
        public static void PublishJetStream(
          LoggingInterface logger,
        IJetStream connection,
    ChatMessage requestMessage,
    String server_id, String steam_id
        ) {
            logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.events.player.{steam_id}.chatted");
            var serializedObject = JsonSerializerSupport(logger, requestMessage);
            connection.Publish($"v0.rust.servers.{server_id}.events.player.{steam_id}.chatted", serializedObject);
        }
    }
}