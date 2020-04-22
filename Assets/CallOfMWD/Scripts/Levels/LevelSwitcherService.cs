using System;
using System.Collections;
using lab.core;
using UnityEngine.SceneManagement;

namespace lab.mwd
{
    public class LevelSwitcherService : ILevelSwitcherService, IInitializable
    {
        private readonly GameSettings gameSettings;
        private IUIFactoryService uiFactoryService;
        
        private int curIndex;
        private Scene scene;
        
        public event Action OnLevelSwitched;

        public LevelSwitcherService(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        public void Initialize()
        {
            uiFactoryService = ServiceLocator.Current.Get<IUIFactoryService>();
            uiFactoryService.OnUILoaded += OnUILoaded;

            scene = SceneManager.GetActiveScene();
            curIndex = scene.buildIndex;
        }

        private void OnUILoaded()
        {
            //var switchLevelButton = uiFactoryService.GameUI.SwitchLevelButton;
            //switchLevelButton.onClick.AddListener(() => gameSettings.AsyncProcessor.StartCoroutine(LoadNextLevel()));
        }
        
        private IEnumerator LoadNextLevel()
        {
            SceneManager.UnloadSceneAsync(curIndex);
            
            curIndex++;

            if (curIndex > gameSettings.levels.Count - 1)
            {
                curIndex = 0;
            }
            
            var operation = SceneManager.LoadSceneAsync(gameSettings.levels[curIndex].LevelPath, LoadSceneMode.Additive);

            while (operation.isDone == false)
            {
                yield return null;
            }

            scene = SceneManager.GetSceneByBuildIndex(curIndex);
            SceneManager.SetActiveScene(scene);
            
            OnLevelSwitched?.Invoke();
        }
        
    }
}