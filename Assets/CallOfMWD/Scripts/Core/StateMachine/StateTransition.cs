using System;

namespace lab.core
{
    public class StateTransition
    {
        public readonly IState From;
        public readonly IState To;
        public readonly Func<bool> Condition;

        public StateTransition(IState from, IState to, Func<bool> condition)
        {
            this.From = from;
            this.To = to;
            this.Condition = condition;
        }
    }
}