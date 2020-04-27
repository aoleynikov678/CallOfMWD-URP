namespace lab.mwd
{
    public class OnChangeLevel : INetworkEvent
    {
        public string LevelPath { get; }
        public bool Owner { get; }

        public OnChangeLevel(string levelPath, bool owner)
        {
            LevelPath = levelPath;
            Owner = owner;
        }
    }
}