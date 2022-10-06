using UnityEngine;

public class MoveStatePlayer : GroundChecker
{
    private float _verticalMove;
    private float _horizontalMove;

    public MoveStatePlayer(StateMachine currentStateMachine, Player character) : base(currentStateMachine, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        if (Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f)
            CurrentStateMachine.ChangeState(Character._idleState);
        //Start anim move
        //Start sound move
    }

    public override void Exit()
    {
        base.Exit();
        //End anim move
        //End sound move
    }

    public override void InputHandler()
    {
        base.InputHandler();
        _horizontalMove = _verticalMove = 0.0f;

        _verticalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");
    }

    public override void LogicsHandler()
    {
        base.LogicsHandler();

        if (_verticalMove == 0.0f && _horizontalMove == 0.0f)
            CurrentStateMachine.ChangeState(Character._idleState);

    }

    public override void PhysicsHandler()
    {
        base.PhysicsHandler();

        Character.DefaultRigidbodyState();
        if (_verticalMove != 0.0f || _horizontalMove != 0.0f)
            Move();
    }

    private void Move() 
    {
        Vector3 forceDirection = Character.transform.right * _horizontalMove 
            + Character.transform.forward * _verticalMove;

        Character.ApplyImpulse(forceDirection * Character._speedMove);
    }
}
