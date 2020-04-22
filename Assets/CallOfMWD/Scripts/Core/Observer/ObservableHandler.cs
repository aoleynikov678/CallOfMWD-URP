using System;

namespace lab.core
{
    public class ObservableHandler
    {
        public Action Handler;
        public bool Invoked = false;
    }
}