using System;
using UnityEditor;
using UnityEngine;

namespace lab.mwd
{
    [Serializable]
    public class LevelReference: ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset levelAsset = null;
#endif        
        [SerializeField] private string levelPath;

        public string LevelPath => levelPath;
        
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            levelPath = AssetDatabase.GetAssetPath(levelAsset);
#endif
        }

        public void OnAfterDeserialize()
        {
        }
    }

}