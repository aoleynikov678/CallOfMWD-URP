using System.Collections.Generic;

namespace lab.core
{
    public interface IState
    {
        void Tick();
        void OnEnter();
        void OnExit();
    }
}