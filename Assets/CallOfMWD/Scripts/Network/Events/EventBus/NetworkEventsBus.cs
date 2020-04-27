using JetBrains.Annotations;
using lab.core;

namespace lab.mwd
{
    [MeansImplicitUse]
    public class NetworkEventsBus : EventsBus<INetworkEvent>, IGameService, IDisposable
    {
        public void Dispose()
        {
            RemoveAll<INetworkEvent>();
        }
    }
}