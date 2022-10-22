using NATS.Client;
using System;
using System.Text;
using Asyncapi.Nats.Client.Models;
using NATS.Client.JetStream;
using static Asyncapi.Nats.Client.Mirror.NatsClient;
using Newtonsoft.Json;

namespace Asyncapi.Nats.Client.Mirror.Channels
{
    class V0RustServersServerIdEventsStarted
    {

        internal static ServerStarted JsonDeserializerSupport(LoggingInterface logger, byte[] buffer)
        {
            var srt = Encoding.UTF8.GetString(buffer);
            logger.Debug("Deserializing message " + srt);
            return JsonConvert.DeserializeObject<ServerStarted>(srt);
        }
        public static IAsyncSubscription Subscribe(
          LoggingInterface logger,
      IConnection connection,
      SubscribeToV0RustServersServerIdEventsStartedDelegate onMessage,
      String server_id
        )
        {
            EventHandler<MsgHandlerEventArgs> handler = (sender, args) =>
            {
                logger.Debug("Got message for channel subscription: " + $"v0.rust.servers.{server_id}.events.started");
                var deserializedMessage = JsonDeserializerSupport(logger, (byte[])args.Message.Data);

                var unmodifiedChannel = "v0.rust.servers.{server_id}.events.started";
                var channel = args.Message.Subject;
                var serverIdSplit = unmodifiedChannel.Split(new string[] { "{server_id}" }, StringSplitOptions.None);
                String[] splits = {
    serverIdSplit[0],
serverIdSplit[1]
  };
                channel = channel.Substring(splits[0].Length);
                var serverIdEnd = channel.IndexOf(splits[1]);
                var serverIdParam = $"{channel.Substring(0, serverIdEnd)}";

                onMessage(deserializedMessage,
          serverIdParam);
            };
            logger.Debug("Subscribing to: " + $"v0.rust.servers.{server_id}.events.started");
            return connection.SubscribeAsync($"v0.rust.servers.{server_id}.events.started", handler);
        }

        public static IAsyncSubscription PushSubscribeJetStream(
          LoggingInterface logger,
      IJetStream connection,
      SubscribeToV0RustServersServerIdEventsStartedDelegate onMessage,
      String server_id,
      bool autoAck, 
      PushSubscribeOptions options
        )
        {
            EventHandler<MsgHandlerEventArgs> handler = (sender, args) =>
            {
                logger.Debug("Got message for channel subscription: " + $"v0.rust.servers.{server_id}.events.started");
                var deserializedMessage = JsonDeserializerSupport(logger, (byte[])args.Message.Data);

                var unmodifiedChannel = "v0.rust.servers.{server_id}.events.started";
                var channel = args.Message.Subject;
                var serverIdSplit = unmodifiedChannel.Split(new string[] { "{server_id}" }, StringSplitOptions.None);
                String[] splits = {
    serverIdSplit[0],
serverIdSplit[1]
  };
                channel = channel.Substring(splits[0].Length);
                var serverIdEnd = channel.IndexOf(splits[1]);
                var serverIdParam = $"{channel.Substring(0, serverIdEnd)}";

                onMessage(deserializedMessage,
          serverIdParam);
            };
            logger.Debug("Subscribing to: " + $"v0.rust.servers.{server_id}.events.started");
            return connection.PushSubscribeAsync($"v0.rust.servers.{server_id}.events.started", handler.Invoke, autoAck, options);
        }
    }
}