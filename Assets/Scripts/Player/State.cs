public abstract class State
{
    public StateMachine CurrentStateMachine;
    public Player Character;

    public State(StateMachine currentStateMachine, Player character)
    {
        CurrentStateMachine = currentStateMachine;
        Character = character;
    }

    public virtual void Enter() 
    {

    }

    public virtual void Exit() 
    {

    }

    public virtual void InputHandler() 
    {

    }

    public virtual void LogicsHandler() 
    {

    }

    public virtual void PhysicsHandler() 
    {

    }
}
