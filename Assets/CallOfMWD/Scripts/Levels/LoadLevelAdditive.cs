using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lab.mwd
{
    public class LoadLevelAdditive : MonoBehaviour
    {
        [SerializeField] private LevelReference levelReference;
        
        public event Action OnLevelLoaded;
        
        private IEnumerator Start()
        {
            var operation = SceneManager.LoadSceneAsync(levelReference.LevelPath, LoadSceneMode.Additive);

            while (operation.isDone == false)
            {
                yield return null;
            }
            
            OnLevelLoaded?.Invoke();
        }
    }
}