using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class GlobalBootstrap : MonoBehaviour
    {        
        private static GlobalBootstrap instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            var gameSettings = Resources.Load<GameSettings>("GameSettings");
            
            ServiceLocator.Create();

            ServiceLocator.Current.Register<ISettingsProvider>(new Settings(gameSettings));
            ServiceLocator.Current.Register<IAsyncProvider>(new Async());
            ServiceLocator.Current.Register<IPlayerInputService>(new PlayerInputService());
            
            ServiceLocator.Current.Initialize();
        }

        private void Update()
        {
            ServiceLocator.Current.Tick();
        }

        private void OnDestroy()
        {
            ServiceLocator.Current.Dispose();
        }
    }
}