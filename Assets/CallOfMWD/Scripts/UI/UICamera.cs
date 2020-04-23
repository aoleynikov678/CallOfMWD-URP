using UnityEngine;

namespace lab.mwd
{
    public class UICamera : MonoBehaviour
    {
        public static UICamera Instance;

        private void Awake()
        {
            if (UICamera.Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
    }
}