using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovmentBaseState
{
    public override void EnterState(MovementStateManager stateManager)
    {
        if(stateManager.previousState == stateManager.idleState){
            stateManager.anim.SetTrigger("IdleJump");
        }
        else if(stateManager.previousState == stateManager.walkState || stateManager.previousState == stateManager.runState){
            stateManager.anim.SetTrigger("RunJump");
        }
    }

    public override void UpdateState(MovementStateManager stateManager)
    {
        if(stateManager.jumped && stateManager.IsGrounded()){
            stateManager.jumped = false;
            if( stateManager.hzInput == 0 && stateManager.vInput == 0){
                stateManager.SwitchState(stateManager.idleState);
            }
            else if(Input.GetKey(KeyCode.LeftShift)){
                stateManager.SwitchState(stateManager.runState);
            }else{
                stateManager.SwitchState(stateManager.walkState);
            }
        }
    }
}
