
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovmentBaseState

{
    public override void EnterState(MovementStateManager stateManager)
    {
        stateManager.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager stateManager)
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            this.ExitState(stateManager, stateManager.walkState);
        } 
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(stateManager.dir.magnitude < 0.1)
            {
               this.ExitState(stateManager, stateManager.idleState);
            }
            else
            {
                stateManager.SwitchState(stateManager.walkState);
            }
        }
        
        if (stateManager.vInput<0){
            stateManager.currentMoveSpeed = stateManager.crouchBackSpeed;
        }
        else{
            stateManager.currentMoveSpeed = stateManager.crouchSpeed;
        }
    }
    void ExitState(MovementStateManager stateManager, MovmentBaseState newState)
    {
        stateManager.anim.SetBool("Crouching", false);
        stateManager.SwitchState(newState);
    }
}
