using lab.core;

namespace lab.mwd
{
    public interface IAsyncProvider : IGameService
    {
        AsyncProcessor AsyncProcessor { get; }
    }
}