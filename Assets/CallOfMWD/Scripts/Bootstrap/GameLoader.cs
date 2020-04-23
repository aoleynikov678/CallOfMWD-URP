using UnityEngine;

namespace lab.mwd
{
    public static class GameLoader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var globalBootstrap = new GameObject("GlobalBootstrap");
            globalBootstrap.AddComponent<GlobalBootstrap>();
        }
    }
}