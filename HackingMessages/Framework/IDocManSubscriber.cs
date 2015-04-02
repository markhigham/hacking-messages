using System.Diagnostics.CodeAnalysis;

namespace Hacking.Framework
{
    public interface IDocManSubscriber
    {
    }

    [SuppressMessage("ReSharper", "TypeParameterCanBeVariant")]
    public interface IDocManSubscriber<T> : IDocManSubscriber
    {
        void OnMessageReceived(T message);
    }
}