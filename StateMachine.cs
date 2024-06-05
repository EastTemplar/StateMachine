using System;
using System.Collections.Generic;

namespace Utilities.StateMachine
{
    public class StateMachine
    {
        public State PreviousState { get; private set; }
        private State _currentState;
        private Dictionary<Type, State> _states = new Dictionary<Type, State>();

        public void Add(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Remove(State state)
        {
            _states.Remove(state.GetType());
        }

        public void SetState<T>() where T : State
        {
            var type = typeof(T);

            if (_currentState?.GetType() == type)
                return;

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();
                PreviousState = _currentState;
                _currentState = newState;
                _currentState.Enter();
            }
        }

        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }
    }
}
