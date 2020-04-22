using System;
using lab.core;

namespace lab.mwd
{
    public interface IUIFactoryService : IGameService
    {
        GameUI GameUI { get; }
        event Action OnUILoaded;
    }
}