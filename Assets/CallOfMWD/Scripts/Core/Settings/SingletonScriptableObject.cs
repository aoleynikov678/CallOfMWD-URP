using UnityEngine;

namespace lab.core
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    T[] results = Resources.FindObjectsOfTypeAll<T>();

                    if (results.Length == 0)
                    {
                        Debug.LogError("No SO found for " + typeof(T).ToString());
                        return null;
                    }

                    if (results.Length > 1)
                    {
                        Debug.LogError("More than 1 SO found for " + typeof(T).ToString());
                        return null;
                    }

                    instance = results[0];
                }

                return instance;
            }   
        }
    }
}