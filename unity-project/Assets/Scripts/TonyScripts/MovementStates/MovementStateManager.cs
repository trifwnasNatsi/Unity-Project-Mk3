using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    MovementBaseState currentState;
    public PlayerIdleState Idle = new PlayerIdleState();
    public WalkingState Walking = new WalkingState();
    public RunningState Running = new RunningState();

    [HideInInspector] public Animator anim;

    public float moveSpeed;
    public float walkingSpeed, walkingBackSpeed;
    public float runningSpeed, runningBackSpeed;

    [HideInInspector] public float hInput, vInput;
    [HideInInspector] public Vector3 direction;
    private CharacterController controller;

    [SerializeField] private float offGround;
    [SerializeField] private LayerMask groundMask;
    private Vector3 spherePosition;

    [SerializeField] private float gravity = -9.81f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("hInput", hInput);
        anim.SetFloat("vInput", vInput);

        currentState.UpdateState(this);
    }

        public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        direction = transform.forward * vInput + transform.right * hInput;

        controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePosition = new Vector3(transform.position.x, transform.position.y - offGround, transform.position.z);
        if (Physics.CheckSphere(spherePosition, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else return false;
    }

    void Gravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        } else if (velocity.y < 0)
        {
            velocity.y = 0;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
