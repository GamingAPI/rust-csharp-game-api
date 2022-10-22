using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asyncapi.Nats.Client.Channels;
using Asyncapi.Nats.Client.Models;
using NATS.Client;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client
{



    public class NatsClient
    {

        private class DefaultLogger : LoggingInterface
        {
            public void Debug(string m)
            {
            }

            public void Error(string m)
            {
            }

            public void Info(string m)
            {
            }
        }
        private IConnection connection;
        private IJetStream jetstream;
        private LoggingInterface logger;
        public LoggingInterface Logger
        {
            get
            {
                return logger;
            }

            set
            {
                logger = value;
            }
        }

        public void Connect()
        {
            connection = new ConnectionFactory().CreateConnection();
        }


        public void createJetStreamContext(JetStreamOptions options)
        {

            //JetStreamOptions jso = JetStreamOptions.Builder().WithOptOut290ConsumerCreate(true).Build();
            jetstream = connection.CreateJetStreamContext(options);
        }


        public void Connect(string url)
        {
            connection = new ConnectionFactory().CreateConnection(url);
        }

        public void Connect(Options opts)
        {
            connection = new ConnectionFactory().CreateConnection(opts);
        }
        public Boolean IsConnected()
        {
            return connection != null && !connection.IsClosed();
        }

        public void Close()
        {
            if (connection != null && !connection.IsClosed())
            {
                connection.Close();
            }
        }



        public NatsClient()
        {
            this.Logger = new DefaultLogger();
        }
        public NatsClient(LoggingInterface logger)
        {
            this.Logger = logger;
        }
        public void PublishToV0RustServersServerIdEventsStarted(
            ServerStarted requestMessage,
            String server_id
        )
        {
            if (IsConnected())
            {
                V0RustServersServerIdEventsStarted.Publish(logger,
            connection,
            requestMessage,
            server_id);
            }
            else
            {
                throw new ClientNotConnected();
            }
        }
        public void PublishToV0RustServersServerIdEventsStartedJetStream(
          ServerStarted requestMessage,
          String server_id
        )
        {
            if (IsConnected())
            {
                V0RustServersServerIdEventsStarted.PublishJetStream(logger,
            jetstream,
            requestMessage,
            server_id);
            }
            else
            {
                throw new ClientNotConnected();
            }
        }
//        public void PublishToV0RustServersServerIdEventsPlayerSteamIdChatted(
//          ChatMessage requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsPlayerSteamIdChatted.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdEventsPlayerSteamIdChattedJetStream(
//  ChatMessage requestMessage,
//String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsPlayerSteamIdChatted.PublishJetStream(logger,
//            jetstream,
//            requestMessage,

//server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdEventsWiped(
//  String server_id
//)
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsWiped.Publish(logger,
//            connection,
//            server_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdEventsWipedJetStream(
//  String server_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsWiped.PublishJetStream(logger,
//            jetstream,
//            server_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsConnected(
//          ServerPlayerConnected requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsConnected.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsConnectedJetStream(
//  ServerPlayerConnected requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsConnected.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsDisconnected(
//          ServerPlayerDisconnected requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsDisconnected.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsDisconnectedJetStream(
//  ServerPlayerDisconnected requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsDisconnected.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsGatheredResources(
//          ServerPlayerResourceGathered requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsGatheredResources.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsGatheredResourcesJetStream(
//          ServerPlayerResourceGathered requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsGatheredResources.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsRespawned(
//          ServerPlayerRespawned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsRespawned.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsRespawnedJetStream(
//          ServerPlayerRespawned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsRespawned.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsCombatHit(
//          ServerPlayerCombatPlayerhit requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsCombatHit.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsCombatHitJetStream(
//          ServerPlayerCombatPlayerhit requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsCombatHit.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup(
//          ServerPlayerItemPickup requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickupJetStream(
//          ServerPlayerItemPickup requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot(
//          ServerPlayerItemLoot requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdLootJetStream(
//          ServerPlayerItemLoot requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted(
//          ServerPlayerItemCrafted requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdCraftedJetStream(
//          ServerPlayerItemCrafted requestMessage,
//        String server_id, String steam_id, String item_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id, item_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdEventsCommand(
//          ServerCommand requestMessage,
//        String server_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsCommand.Publish(logger,
//            connection,
//            requestMessage,
//            server_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdEventsCommandJetStream(
//          ServerCommand requestMessage,
//        String server_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdEventsCommand.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsReported(
//          ServerPlayerReported requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsReported.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsReportedJetStream(
//          ServerPlayerReported requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsReported.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsUnbanned(
//          ServerPlayerUnbanned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsUnbanned.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsUnbannedJetStream(
//          ServerPlayerUnbanned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsUnbanned.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsBanned(
//          ServerPlayerBanned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsBanned.Publish(logger,
//            connection,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
//        public void PublishToV0RustServersServerIdPlayersSteamIdEventsBannedJetStream(
//          ServerPlayerBanned requestMessage,
//        String server_id, String steam_id
//        )
//        {
//            if (IsConnected())
//            {
//                V0RustServersServerIdPlayersSteamIdEventsBanned.PublishJetStream(logger,
//            jetstream,
//            requestMessage,
//            server_id, steam_id);
//            }
//            else
//            {
//                throw new ClientNotConnected();
//            }
//        }
    }
}