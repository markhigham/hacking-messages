using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hacking.Framework;
using Hacking.Messages;
using Hacking.Subscribers;
using Hacking.Subscriptions;

namespace Hacking
{
    class Installer: IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IDocManSubscriber>().ImplementedBy<HeaderProcessor>());
            //container.Register(Component.For<IDocManSubscriber>().ImplementedBy<MessageProcessor>());
            container.Register(Component.For<IDocManSubscriber>().ImplementedBy<PayloadProcessor>());

        }

    }
}