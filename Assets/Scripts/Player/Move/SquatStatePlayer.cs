using UnityEngine;

public class SquatStatePlayer : State
{
    private bool _squat;
    private float _verticalMove;
    private float _horizontalMove;


    public SquatStatePlayer(StateMachine currentStateMachine, Player character) : base(currentStateMachine, character)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _horizontalMove = _verticalMove = 0.0f;
        Character.DefaultRigidbodyState();
        //Params for squat
        //Start anim Squat
        //Start sound Squat
    }

    public override void Exit()
    {
        base.Enter();
        //End anim Squat
        //End sound Squat
    }

    public override void InputHandler()
    {
        base.InputHandler();
        _verticalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");
        _squat = Input.GetButton("Squat");
    }

    public override void LogicsHandler()
    {
        base.LogicsHandler();

        if (_squat == false)
            CurrentStateMachine.ChangeState(Character._moveState);


    }

    public override void PhysicsHandler()
    {
        base.PhysicsHandler();

        Character.DefaultRigidbodyState();
        if (_verticalMove != 0.0f || _horizontalMove != 0.0f)
            MoveSquat();
    }

    private void MoveSquat() 
    {
        Vector3 forceDirection = Character.transform.right * _horizontalMove
            + Character.transform.forward * _verticalMove;
        Character.ApplyImpulse(forceDirection * Character._speedSquat);
    }
}
