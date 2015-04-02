using System;
using Hacking.Framework;
using Hacking.Messages;

namespace Hacking.Subscribers
{
    public class PayloadProcessor: IDocManSubscriber<IProcessingMessage>
    {
        public void OnMessageReceived(IProcessingMessage message)
        {
            Console.WriteLine("I've received a message with payload\n{0}\n=====", message.Payload);
        }
    }
}