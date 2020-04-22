﻿using UnityEngine;

namespace lab.core
{
    public class InitSettings : ScriptableObject
    {
        public AsyncProcessor AsyncProcessor { get; private set; }

        public void SetAsyncProcessor(AsyncProcessor asyncProcessor)
        {
            AsyncProcessor = asyncProcessor;
        }
        
        public void CreateAsyncProcessor()
        {
            GameObject asyncGO = new GameObject("Async");
            GameObject.DontDestroyOnLoad(asyncGO);
            AsyncProcessor = asyncGO.AddComponent<AsyncProcessor>();
        }
    }
}