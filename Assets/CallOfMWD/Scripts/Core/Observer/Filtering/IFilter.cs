using System.Collections.Generic;

namespace lab.core
{
    public interface IFilter
    {
        void Init(Dictionary<IObservable, ObservableHandler> events);
        void InvokeFiltered();
    }
}