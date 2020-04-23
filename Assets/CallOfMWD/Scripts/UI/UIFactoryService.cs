using System;
using System.Collections;
using lab.core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lab.mwd
{
    public class UIFactoryService : IUIFactoryService, IInitializable
    {
        private const string uiSceneName = "Screen UI";

        public GameUI GameUI { get; private set; }
        public event Action OnUILoaded;
        
        public void Initialize()
        {
            AsyncProcessor async = ServiceLocator.Current.Get<IAsyncProvider>().AsyncProcessor;
            
            if (SceneManager.GetSceneByName(uiSceneName).isLoaded == false)
            {
                async.StartCoroutine(LoadSceneUI());
            }
        }
        
        private IEnumerator LoadSceneUI()
        {
            var operation = SceneManager.LoadSceneAsync(uiSceneName, LoadSceneMode.Additive);

            while (operation.isDone == false)
            {
                yield return null;
            }

            GameUI = GameObject.FindObjectOfType<GameUI>();

            OnUILoaded?.Invoke();
        }
    }
}