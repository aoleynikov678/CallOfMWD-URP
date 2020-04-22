using System;
using System.Collections.Generic;

namespace  lab.core
{
    public class InvokeOnceFilter : IFilter
    {
        private Dictionary<IObservable, ObservableHandler> events;
        
        public void Init(Dictionary<IObservable, ObservableHandler> events)
        {
            this.events = events;
        }

        public void InvokeFiltered()
        {
            List<Action> alreadyProcessed = new List<Action>();
            
            foreach (var ev in events)
            {
                if (ev.Value != null && ev.Value.Invoked && !alreadyProcessed.Contains(ev.Value.Handler))
                {
                    ev.Value.Handler?.Invoke();
                    alreadyProcessed.Add(ev.Value.Handler);
                    ev.Value.Invoked = false;
                }
            }
        }
    }
}