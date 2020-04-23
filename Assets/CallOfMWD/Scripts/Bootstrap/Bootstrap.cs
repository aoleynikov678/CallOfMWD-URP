using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            GameSettings.Instance.SetAsyncProcessor(gameObject.AddComponent<AsyncProcessor>());
            
            ServiceLocator.Create();

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