namespace Utilities.StateMachine
{
    public abstract class State
    {
        protected StateMachine StateMachine { get; }

        public State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void Update(float deltaTime) { }

        public virtual void Exit() { }
    }
}
