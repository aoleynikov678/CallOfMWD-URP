using lab.core;

namespace lab.mwd
{
    public interface ISettingsProvider : IGameService
    {
        GameSettings GameSettings { get; }
    }
}