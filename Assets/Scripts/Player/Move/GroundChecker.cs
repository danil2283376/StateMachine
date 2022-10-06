using UnityEngine;

public class GroundChecker : State
{
    private bool _jump;
    private bool _squat;

    public GroundChecker(StateMachine currentStateMachine, Player character) : base(currentStateMachine, character)
    {

    }

    public override void InputHandler()
    {
        base.InputHandler();

        _jump = Input.GetButton("Jump");
        _squat = Input.GetButton("Squat");
    }

    public override void LogicsHandler()
    {
        base.LogicsHandler();
        if (_jump)
            CurrentStateMachine.ChangeState(Character._jumpState);
        if (_squat)
            CurrentStateMachine.ChangeState(Character._squatState);
    }

    public override void PhysicsHandler()
    {
        base.PhysicsHandler();
    }
}
