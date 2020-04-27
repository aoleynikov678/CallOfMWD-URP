using System;
using UnityEngine;

namespace lab.core
{
    public class EventContainer<T> where T : IEvent
    {
        private event Action<T> handler;
        
        public EventContainer(Action<T> handler)
        {
            this.handler = handler;
        }

        public void AddListener(Action<T> handler)
        {
            this.handler += handler;
        }
        
        public void RemoveListener(Action<T> handler)
        {
            this.handler -= handler;
        }

        public void Invoke(T arg)
        {
            handler?.Invoke(arg);
        }

        public void Dispose()
        {
            handler = null;
        }
    }
}