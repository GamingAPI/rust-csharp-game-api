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
	public void createJetStreamContext(JetStreamOptions options)
	{
		jetstream = connection.CreateJetStreamContext(options);
	}
	
	public void Close()
	{
		if(connection != null && !connection.IsClosed())
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
public void JetStreamPublishToV0RustServersServerIdEventsStarted(
  ServerStarted requestMessage,
String server_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdEventsStarted.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdEventsPlayerSteamIdChatted(
  ChatMessage requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdEventsPlayerSteamIdChatted.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdEventsPlayerSteamIdChatted(
  ChatMessage requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdEventsPlayerSteamIdChatted.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdEventsWiped(
  String server_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdEventsWiped.Publish(logger,
connection,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdEventsWiped(
  String server_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdEventsWiped.JetStreamPublish(logger,
jetstream,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsConnected(
  ServerPlayerConnected requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsConnected.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsConnected(
  ServerPlayerConnected requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsConnected.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsDisconnected(
  ServerPlayerDisconnected requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsDisconnected.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsDisconnected(
  ServerPlayerDisconnected requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsDisconnected.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsGatheredResources(
  ServerPlayerResourceGathered requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsGatheredResources.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsGatheredResources(
  ServerPlayerResourceGathered requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsGatheredResources.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsRespawned(
  ServerPlayerRespawned requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsRespawned.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsRespawned(
  ServerPlayerRespawned requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsRespawned.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsCombatHit(
  ServerPlayerCombatPlayerhit requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsCombatHit.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsCombatHit(
  ServerPlayerCombatPlayerhit requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsCombatHit.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup(
  ServerPlayerItemPickup requestMessage,
String server_id,String steam_id,String item_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup.Publish(logger,
connection,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup(
  ServerPlayerItemPickup requestMessage,
String server_id,String steam_id,String item_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot(
  ServerPlayerItemLoot requestMessage,
String server_id,String steam_id,String item_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot.Publish(logger,
connection,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot(
  ServerPlayerItemLoot requestMessage,
String server_id,String steam_id,String item_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted(
  ServerPlayerItemCrafted requestMessage,
String server_id,String steam_id,String item_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted.Publish(logger,
connection,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted(
  ServerPlayerItemCrafted requestMessage,
String server_id,String steam_id,String item_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdEventsCommand(
  ServerCommand requestMessage,
String server_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdEventsCommand.Publish(logger,
connection,
requestMessage,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdEventsCommand(
  ServerCommand requestMessage,
String server_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdEventsCommand.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsReported(
  ServerPlayerReported requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsReported.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsReported(
  ServerPlayerReported requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsReported.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsUnbanned(
  ServerPlayerUnbanned requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsUnbanned.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsUnbanned(
  ServerPlayerUnbanned requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsUnbanned.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void PublishToV0RustServersServerIdPlayersSteamIdEventsBanned(
  ServerPlayerBanned requestMessage,
String server_id,String steam_id
)
  {
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsBanned.Publish(logger,
connection,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public void JetStreamPublishToV0RustServersServerIdPlayersSteamIdEventsBanned(
  ServerPlayerBanned requestMessage,
String server_id,String steam_id
)
{
  if (IsConnected())
  {
    V0RustServersServerIdPlayersSteamIdEventsBanned.JetStreamPublish(logger,
jetstream,
requestMessage,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
  }
}