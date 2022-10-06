using UnityEngine;

public class JumpStatePlayer : State
{
    private bool _ground;

    public JumpStatePlayer(StateMachine currentStateMachine, Player character) : base(currentStateMachine, character)
    {

    }

    public override void Enter()
    {
        base.Enter();
        //Start anim jump
        //Start sound jump
        _ground = false;
        Jump();
    }

    public override void Exit()
    {
        base.Exit();
        //End anim jump
        //End sound jump
        //Character.DefaultRigidbodyState();
    }

    public override void LogicsHandler()
    {
        base.LogicsHandler();

        if (_ground)
        {
            CurrentStateMachine.ChangeState(Character._moveState);
        }
    }

    public override void PhysicsHandler()
    {
        base.PhysicsHandler();

        _ground = Character.CheckOverlapCollision(Character.transform.position);
    }


    private void Jump()
    {
        Character.ApplyImpulse(Vector3.up * Character._speedJump);
    }


}
