using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asyncapi.Nats.Client.Channels;
using Asyncapi.Nats.Client.Models;
using NATS.Client;
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
	private IEncodedConnection connection;
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

	internal byte[] JsonSerializer(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (byte[])obj;
	}



	internal object JsonDeserializer(byte[] buffer)
	{
		return buffer;
	}

	public void Connect()
	{
		connection = new ConnectionFactory().CreateEncodedConnection();
		setserializers();
	}

	private void setserializers()
	{
		connection.OnDeserialize = JsonDeserializer;
		connection.OnSerialize = JsonSerializer;
	}

	public void Connect(string url)
	{
		connection = new ConnectionFactory().CreateEncodedConnection(url);
		setserializers();
	}
	
	public void Connect(Options opts)
	{
		connection = new ConnectionFactory().CreateEncodedConnection(opts);
		setserializers();
	}
	public Boolean IsConnected()
	{
		return connection != null && !connection.IsClosed();
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
  }
}