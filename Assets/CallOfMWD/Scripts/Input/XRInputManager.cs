using UnityEngine;

namespace lab.mwd
{
    public class XRInputManager : MonoBehaviour
    {
        private static XRInputManager instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
    }
}