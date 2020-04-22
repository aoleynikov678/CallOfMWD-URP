using System;
using System.Collections.Generic;
using UnityEngine;

namespace lab.core
{
    public class StateMachine
    {
        private IState currentState;
        
        private List<StateTransition> stateTransitions = new List<StateTransition>();
        private List<StateTransition> anyStateTransitions = new List<StateTransition>();
        
        public void AddAnyTransition(IState to, Func<bool> condition)
        {
            var transition = new StateTransition(null, to, condition);
            anyStateTransitions.Add(transition);
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            var stateTransition = new StateTransition(from, to, condition);
            stateTransitions.Add(stateTransition);
        }
        
        public void SetState(IState state)
        {
            if (currentState == state)
                return;
            
            currentState?.OnExit();

            currentState = state;
            currentState.OnEnter();
        }
        
        public void Tick()
        {
            StateTransition transition = CheckForTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            
            currentState.Tick();
        }

        private StateTransition CheckForTransition()
        {
            foreach (var transition in anyStateTransitions)
            {
                if (transition.Condition())
                    return transition;
            }
            
            foreach (var transition in stateTransitions)
            {                
                if (transition.From == currentState && transition.Condition())
                    return transition;
            }

            return null;
        }
    }
}