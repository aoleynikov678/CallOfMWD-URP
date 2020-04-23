using UnityEngine;

namespace lab.mwd
{
    public class UICamera : MonoBehaviour
    {
        private static UICamera Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
    }
}