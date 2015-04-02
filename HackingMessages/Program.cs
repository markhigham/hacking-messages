using System;
using Castle.Windsor;
using Hacking.Framework;
using Hacking.Messages;
using Hacking.Subscribers;
using Hacking.Subscriptions;
using Newtonsoft.Json;

namespace Hacking
{
    class MainClass
    {
        private static IWindsorContainer _container;

        public static void Main(string[] args)
        {
            _container = new WindsorContainer();
            _container.Install(new Installer());

            var payloadProcessor = _container.Resolve<IDocManSubscriber>();
            var msg = CreateTestMessage();

            InvokeMessageReceived(payloadProcessor, msg);

            var headerProcessor = new Subscribers.HeaderProcessor();
            InvokeMessageReceived(headerProcessor, msg);

            var router = new RoutingProcessor();
            InvokeMessageReceived(router, msg);

        }

        private static void InvokeMessageReceived(IDocManSubscriber subscriber, DocManMessage messageToSend)
        {
            //What kind of a processor are you
            Console.WriteLine("Processor is {0}", subscriber.GetType());

            //What interfaces does the processor implement?
            var interfaces = subscriber.GetType().GetInterfaces();
            foreach (var i in interfaces)
            {
                //Console.WriteLine("Interface: {0}", i);
                //Console.WriteLine("Generic {0}", i.IsGenericType);
                if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDocManSubscriber<>))
                {
                    var messageType = i.GetGenericArguments()[0];
                    //Console.WriteLine(messageType);

                    Console.WriteLine("Using {0} which listens for messages of type '{1}'", subscriber.GetType(), messageType);

                    // How to call that generic method
                    var onMessageReceived = subscriber.GetType().GetMethod("OnMessageReceived");
                    //Console.WriteLine(onMessageReceived);

                    onMessageReceived.Invoke(subscriber, new object[] { messageToSend });
                }

                Console.Write("************************\n");
            }
        }


        static DocManMessage CreateTestMessage()
        {

            var payload = new TestClass { Id = "id", Name = "This is hte name", Date = DateTime.UtcNow };

            var json = JsonConvert.SerializeObject(payload, Formatting.Indented);

            return new DocManMessage()
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = "Funky Message Type",
                Payload = json


            };
        }

        class TestClass
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime? Date { get; set; }

        }



    }

}