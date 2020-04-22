using System;

namespace lab.core
{
    public interface IObservable
    {
        event Action ValueChanged;
    }
}