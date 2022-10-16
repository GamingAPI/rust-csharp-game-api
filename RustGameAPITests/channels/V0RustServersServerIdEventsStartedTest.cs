
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Asyncapi.Nats.Client.Models;
using AsyncVerifyForMoq;
using Moq;
using NATS.Client;
using NATS.Client.JetStream;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class V0RustServersServerIdEventsStartedTest
    {
        [Fact]
        async public void ShouldBeAbleToPublishToChannel()
        {
            var client = new NatsClient();
            var mirrorClient = new Mirror.NatsClient();
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.Url = "nats://localhost:4222";
            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // get a private key seed from your environment.
                string seed = "SUAHZGQCK3PKMY5JBY2PBJUK2SA2IAGNX7VXYQJ75MLIU2IWQE235OBLJM";

                // Generate a NkeyPair
                NkeyPair kp = Nkeys.FromSeed(seed);

                // Sign the nonce and return the result in the SignedNonce
                // args property.  This must be set.
                args.SignedNonce = kp.Sign(args.ServerNonce);
            };
            opts.SetNkey("UCI2NCSIEV3DXLYYR5KQXYCZ7CIW4KYXHLSGXJOZ7TSRRKHP2BM5IVMU", sigEh);
            client.Connect(opts);
            mirrorClient.Connect(opts);
            Assert.True(client.IsConnected());
            Assert.True(mirrorClient.IsConnected());
            var message = new ServerStarted();
            message.Timestamp = System.DateTime.UtcNow.ToString();
            var serverId = "123";
            var mock = new Mock<Mirror.NatsClient.SubscribeToV0RustServersServerIdEventsStartedDelegate>();

            mirrorClient.SubscribeToV0RustServersServerIdEventsStarted(mock.Object, serverId);
            client.PublishToV0RustServersServerIdEventsStarted(message, serverId);
            var timeSpan = TimeSpan.FromSeconds(40);
            var asyncVerification = new List<Task>()
            {
                mock.AsyncVerify(x => x(It.IsAny<ServerStarted>(), It.IsAny<string>()), Times.Once(), timeSpan)
            };

            await Task.WhenAll(asyncVerification);
        }


        [Fact]
        async public void ShouldBeAbleToPublishToJetStreamChannel()
        {
            var client = new NatsClient();
            var mirrorClient = new Mirror.NatsClient();
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.Url = "nats://localhost:4222";
            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // get a private key seed from your environment.
                string seed = "SUAHZGQCK3PKMY5JBY2PBJUK2SA2IAGNX7VXYQJ75MLIU2IWQE235OBLJM";

                // Generate a NkeyPair
                NkeyPair kp = Nkeys.FromSeed(seed);

                // Sign the nonce and return the result in the SignedNonce
                // args property.  This must be set.
                args.SignedNonce = kp.Sign(args.ServerNonce);
            };
            opts.SetNkey("UCI2NCSIEV3DXLYYR5KQXYCZ7CIW4KYXHLSGXJOZ7TSRRKHP2BM5IVMU", sigEh);
            client.Connect(opts);
            var jetstreamOptions = JetStreamOptions.Builder().Build();
            client.createJetStreamContext(jetstreamOptions);
            mirrorClient.Connect(opts);
            mirrorClient.createJetStreamContext(jetstreamOptions);
            Assert.True(client.IsConnected());
            Assert.True(mirrorClient.IsConnected());
            var message = new ServerStarted();
            message.Timestamp = DateTime.UtcNow.ToString();
            var serverId = "123";
            var mock = new Mock<Mirror.NatsClient.SubscribeToV0RustServersServerIdEventsStartedDelegate>();

            mirrorClient.PushSubscribeToV0RustServersServerIdEventsStarted(mock.Object, serverId, true, PushSubscribeOptions.Builder().Build());
            client.PublishToV0RustServersServerIdEventsStartedJetStream(message, serverId);
            var timeSpan = TimeSpan.FromSeconds(40);
            var asyncVerification = new List<Task>()
            {
                mock.AsyncVerify(x => x(It.IsAny<ServerStarted>(), serverId), Times.Once(), timeSpan)
            };

            await Task.WhenAll(asyncVerification);
        }
    }
}