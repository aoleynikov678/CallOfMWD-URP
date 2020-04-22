using System;
using System.Collections.Generic;

namespace lab.core
{
    public class ObservableQueue
    {
        private readonly Dictionary<IObservable, ObservableHandler> events = new Dictionary<IObservable, ObservableHandler>();

        public void Subscribe<T>(IObservable observable, Action handler)
        {
            if (events.ContainsKey(observable))
            {
                events[observable].Handler += handler;
            }
            else
            {
                var actionData = new ObservableHandler {Handler = handler};
                observable.ValueChanged += () => { actionData.Invoked = true; };
                events.Add(observable, actionData);
            }
        }

        public void Unsubscribe<T>(IObservable observable, Action handler)
        {
            if (events.ContainsKey(observable))
            {
                events[observable].Handler -= handler;
            }
        }

        public void UnsubscribeAll<T>(IObservable observable)
        {
            if (events.ContainsKey(observable))
            {
                events[observable].Handler = null;
            }
        }
    
        public void Invoke()
        {
            foreach (var ev in events)
            {
                if (ev.Value.Invoked)
                {
                    ev.Value.Handler?.Invoke();
                    ev.Value.Invoked = false;
                }
            }
        }

        public void InvokeFiltered(IFilter filter)
        {
            filter.Init(events);
            filter.InvokeFiltered();
        }
    }
}