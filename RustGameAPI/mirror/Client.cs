using System;
using Asyncapi.Nats.Client.Mirror.Channels;
using Asyncapi.Nats.Client.Models;
using NATS.Client;
using NATS.Client.JetStream;

namespace Asyncapi.Nats.Client.Mirror
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

	public delegate void SubscribeToV0RustServersServerIdEventsStartedDelegate(
		ServerStarted request,
		string server_id
	);
		public IAsyncSubscription SubscribeToV0RustServersServerIdEventsStarted(
	  SubscribeToV0RustServersServerIdEventsStartedDelegate onMessage,
	String server_id
	)
		{
			if (IsConnected())
			{
				return V0RustServersServerIdEventsStarted.Subscribe(logger,
			connection,
			onMessage,
			server_id);
			}
			else
			{
				throw new ClientNotConnected();
			}
		}
		public IAsyncSubscription PushSubscribeToV0RustServersServerIdEventsStarted(
			SubscribeToV0RustServersServerIdEventsStartedDelegate onMessage,
			String server_id,
			bool autoAck,
			PushSubscribeOptions options)
		{
			if (IsConnected())
			{
				return V0RustServersServerIdEventsStarted.PushSubscribeJetStream(logger,
			jetstream,
			onMessage,
			server_id, autoAck, options);
			}
			else
			{
				throw new ClientNotConnected();
			}
		}
	}
}