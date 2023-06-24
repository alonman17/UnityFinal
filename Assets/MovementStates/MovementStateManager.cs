using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float currentMoveSpeed;
    public float walkSpeed =3 , walkBackSpeed=2;
    public float runSpeed=7, runBackSpeed=5;
    public float crouchSpeed=2, crouchBackSpeed=1;
    public float airSpeed = 1.5f;

    [HideInInspector] public float hzInput , vInput;
    [HideInInspector] public Vector3 dir;
    CharacterController controller;

    [SerializeField] float groundYoffset;
    [SerializeField] LayerMask groundMask;
    Vector3 shperePos;

    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpForce = 10;
    [HideInInspector] public bool jumped;

    Vector3 velocity;

    public MovmentBaseState currentState;
    public MovmentBaseState previousState;
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public RunState runState = new RunState();
    public CrouchState crouchState = new CrouchState();
    public JumpState jumpState = new JumpState();
   
   [HideInInspector] public Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        Falling();
        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);
        currentState.UpdateState(this);
    }

    public void SwitchState(MovmentBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        Vector3 airDir = Vector3.zero;
        if(!IsGrounded()){
            airDir = transform.forward * vInput + transform.right * hzInput;
            
        }
        else{
            dir = transform.forward * vInput + transform.right * hzInput;
        }
        controller.Move((dir.normalized * currentMoveSpeed + airDir.normalized * airSpeed) * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        shperePos = new Vector3(transform.position.x, transform.position.y - groundYoffset, transform.position.z);
        if (Physics.CheckSphere(shperePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    void Gravity()
    {
        if (!IsGrounded()){
            velocity.y += gravity * Time.deltaTime;
            
        }else if( velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
        
    }

    void Falling(){
        anim.SetBool("Falling", !IsGrounded());
    }


    public void JumpForce(){
        velocity.y = jumpForce;
    }

    public void Jumped()
    {
        jumped = true;
    }
}
