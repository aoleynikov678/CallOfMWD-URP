using lab.core;

namespace lab.mwd
{
    public class Settings : ISettingsProvider
    {
        public GameSettings GameSettings { get; }
        
        public Settings(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}