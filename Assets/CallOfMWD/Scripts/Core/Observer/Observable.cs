using System;

namespace lab.core
{
    public class Observable<T> : IObservable
    {       
        public event Action ValueChanged;
        private T val;

        public Observable(T val)
        {
            Value = val;
        }
        
        public T Value
        {
            get => val;
            set
            {
                var prevVal = val;
                val = value;

                if (!value.Equals(prevVal))
                {
                    ValueChanged?.Invoke();
                }
            }
        }
    }
}