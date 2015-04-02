using Hacking.Messages;

namespace Hacking.Subscriptions
{
    public interface IDocManMessage: ICommonHeaders, IRoutingHeaders, IProcessingMessage
    {
        
    }
}