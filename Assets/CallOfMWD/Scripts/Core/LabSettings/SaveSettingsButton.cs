using UnityEngine;
using UnityEngine.UI;

namespace lab.settings
{
    [RequireComponent(typeof(Button))]
    public class SaveSettingsButton : MonoBehaviour
    {
        [SerializeField]
        private SaveableScriptableObject[] saveableScriptableObjects;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();

            if (!button)
            {
                Debug.LogError("No save button");
                return;
            }
            
            button.onClick.AddListener(SaveSettings);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(SaveSettings);
        }

        public void SaveSettings()
        {
            foreach (var saveableScriptableObject in saveableScriptableObjects)
            {
                saveableScriptableObject.SaveSettings();
            }
        }
    }
}