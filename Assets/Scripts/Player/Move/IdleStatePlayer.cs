using UnityEngine;

public class IdleStatePlayer : GroundChecker
{
    private float _verticalMove;
    private float _horizontalMove;

    public IdleStatePlayer(StateMachine currentStateMachine, Player character) : base(currentStateMachine, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        _horizontalMove = _verticalMove = 0.0f;
        //Start anim idle
        //Start sound idle
    }

    public override void Exit()
    {
        base.Exit();
        //End anim idle
        //End sound idle
    }

    public override void InputHandler()
    {
        base.InputHandler();
        _verticalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");
    }

    public override void LogicsHandler()
    {
        base.LogicsHandler();

        if (_verticalMove != 0.0f || _horizontalMove != 0.0f)
            CurrentStateMachine.ChangeState(Character._moveState);
    }

    public override void PhysicsHandler()
    {
        base.PhysicsHandler();
    }
}
