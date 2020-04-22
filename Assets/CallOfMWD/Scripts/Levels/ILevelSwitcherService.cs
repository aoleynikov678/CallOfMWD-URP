using System;
using lab.core;

namespace lab.mwd
{
    public interface ILevelSwitcherService : IGameService
    {
        event Action OnLevelSwitched;
    }
}