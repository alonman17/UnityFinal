using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    // Start is called before the first frame update
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
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public RunState runState = new RunState();
    public CrouchState crouchState = new CrouchState();
    public JumpState jumpState = new JumpState();
   
   [HideInInspector] public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        // SwitchState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
      // change hzInput and vInput to the enemy's movement, not with keyboard input
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        

        dir = new Vector3(hzInput, 0, vInput);
        dir = transform.TransformDirection(dir);
        dir *= currentMoveSpeed;
        dir.y = velocity.y;
        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);
        // currentState.UpdateState(this);
    }

    public void SwitchState(MovmentBaseState newState)
    {
        currentState = newState;
        // currentState.EnterState(this);
    }

}
