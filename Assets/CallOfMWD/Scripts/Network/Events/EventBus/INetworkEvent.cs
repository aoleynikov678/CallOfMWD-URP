using lab.core;

namespace lab.mwd
{
    public interface INetworkEvent : IEvent
    {
        bool Owner { get; }
    }
}