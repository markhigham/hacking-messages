using System;
using Hacking.Framework;
using Hacking.Messages;

namespace Hacking.Subscribers
{
    public class HeaderProcessor: IDocManSubscriber<ICommonHeaders>
    {
        public void OnMessageReceived(ICommonHeaders headers)
        {
            Console.WriteLine("Message id {0} is a {1}", headers.MessageId, headers.MessageType);

        }
    }
}