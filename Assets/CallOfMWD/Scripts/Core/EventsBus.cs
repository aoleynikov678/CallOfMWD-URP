using System;
using System.Collections.Generic;

namespace lab.core
{
    public class EventsBus<EventScope> where EventScope : IEvent
    {
        private Dictionary<Type, object> events = new Dictionary<Type, object>();
        
        public void AddListener<T>(Action<T> action) where T : EventScope
        {
            var key = typeof(T);

            if (!events.ContainsKey(key))
            {
                events.Add(key, new EventContainer<T>(action));
            }
            else
            {
                ((EventContainer<T>)(events[typeof(T)])).AddListener(action);
            }
        }
        
        public void RemoveListener<T>(Action<T> action) where T : EventScope
        {
            var key = typeof(T);
            
            if (events.ContainsKey(key))
            {                
                ((EventContainer<T>)(events[typeof(T)])).RemoveListener(action);
            }
        }
        
        public void Fire<T>(T arg) where T : EventScope
        {
            if (events.ContainsKey(typeof(T)))
            {
                ((EventContainer<T>)(events[typeof(T)])).Invoke(arg);
            }
        }
        
        protected void RemoveAll<T>() where T : EventScope
        {
            foreach (var e in events)
            {
                e.Value.GetType().GetMethod("Dispose")?.Invoke(e.Value, null);
            }
        }
    }
}