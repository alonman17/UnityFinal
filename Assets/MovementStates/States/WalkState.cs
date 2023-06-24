using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovmentBaseState
{
    // Start is called before the first frame update
   public override void EnterState(MovementStateManager stateManager)
    {
        stateManager.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager stateManager)
    {   
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.ExitState(stateManager, stateManager.runState);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            this.ExitState(stateManager, stateManager.crouchState);
        }
        else if (stateManager.dir.magnitude < 0.1)
        {
            this.ExitState(stateManager, stateManager.idleState);
        }

        if (stateManager.vInput<0){
            stateManager.currentMoveSpeed = stateManager.walkBackSpeed;
        }
        else{
            stateManager.currentMoveSpeed = stateManager.walkSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.previousState = this;
            ExitState(stateManager, stateManager.jumpState);
        }
       
    }

    void ExitState(MovementStateManager stateManager, MovmentBaseState newState)
    {
        stateManager.anim.SetBool("Walking", false);
        stateManager.SwitchState(newState);
    }
}
