using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        
        private static Bootstrap instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            
            ServiceLocator.Create();

            ServiceLocator.Current.Register<ISettingsProvider>(new Settings(gameSettings));
            ServiceLocator.Current.Register<IAsyncProvider>(new Async());
            
            ServiceLocator.Current.Register<IPlayerService>(new PlayerService());
            ServiceLocator.Current.Register<IUIFactoryService>(new UIFactoryService());
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