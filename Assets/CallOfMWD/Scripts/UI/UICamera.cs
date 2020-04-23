using UnityEngine;

namespace lab.mwd
{
    public class UICamera : MonoBehaviour
    {
        private static UICamera instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }    
            
        }
    }
}