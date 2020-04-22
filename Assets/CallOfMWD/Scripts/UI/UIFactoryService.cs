using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lab.mwd
{
    public class UIFactoryService : IUIFactoryService
    {
        private const string uiSceneName = "UI";

        public GameUI GameUI { get; private set; }
        public event Action OnUILoaded;
        
        public UIFactoryService(GameSettings gameSettings)
        {
            if (SceneManager.GetSceneByName(uiSceneName).isLoaded == false)
            {
                gameSettings.AsyncProcessor.StartCoroutine(LoadSceneUI());
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