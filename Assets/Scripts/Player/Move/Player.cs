using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    public float _speedMove = 10f;
    public float _speedJump = 5f;
    public float _speedSquat = 3f;
    public Rigidbody _body { get; private set; }
    public StateMachine _stateMachine { get; private set; }
    public IdleStatePlayer _idleState { get; private set; }
    public MoveStatePlayer _moveState { get; private set; }
    public JumpStatePlayer _jumpState { get; private set; }
    public SquatStatePlayer _squatState { get; private set; }

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float _radiusPlayer = 1f;
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _stateMachine = new StateMachine();

        _idleState = new IdleStatePlayer(_stateMachine, this);
        _moveState = new MoveStatePlayer(_stateMachine, this);
        _jumpState = new JumpStatePlayer(_stateMachine, this);
        _squatState = new SquatStatePlayer(_stateMachine, this);
        _stateMachine.Initialize(_idleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.InputHandler();

        _stateMachine.CurrentState.LogicsHandler();
        Debug.Log(_stateMachine.CurrentState);
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsHandler();
    }

    public bool CheckOverlapCollision(Vector3 point)
    {
        return Physics.OverlapSphere(point, _radiusPlayer, whatIsGround).Length > 0;
    }

    public void ApplyImpulse(Vector3 force)
    {
        _body.AddForce(force, ForceMode.Impulse);
    }

    public void DefaultRigidbodyState()
    {
        _body.angularVelocity = Vector3.zero;
        _body.velocity = Vector3.zero;
        _body.velocity.Normalize();
    }
}
