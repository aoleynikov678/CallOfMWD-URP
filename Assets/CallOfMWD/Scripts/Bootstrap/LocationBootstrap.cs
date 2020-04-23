using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class LocationBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            var uiFactory = new UIFactoryService();
            ServiceLocator.Current.Register<IUIFactoryService>(uiFactory);
            uiFactory.Initialize();
        }
    }
}