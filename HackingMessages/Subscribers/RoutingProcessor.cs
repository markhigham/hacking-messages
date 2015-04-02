using System;
using System.Collections.Generic;
using System.Linq;
using Hacking.Framework;
using Hacking.Messages;

namespace Hacking.Subscribers
{
    public class RoutingProcessor : IDocManSubscriber<IRoutingHeaders>
    {
        public void OnMessageReceived(IRoutingHeaders message)
        {
            Console.WriteLine("This message has {0} steps", message.Steps.Count());
            message.Steps = new List<string> { "Hello", "world" };
        }
    }
}

