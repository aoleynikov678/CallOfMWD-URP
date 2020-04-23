using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public class Async : IAsyncProvider
    {
        public AsyncProcessor AsyncProcessor { get; private set; }

        public Async()
        {
            GameObject asyncGO = new GameObject("Async");
            GameObject.DontDestroyOnLoad(asyncGO);
            AsyncProcessor = asyncGO.AddComponent<AsyncProcessor>();
        }
    }
}