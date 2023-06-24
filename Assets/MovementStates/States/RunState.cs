using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovmentBaseState
{
    // Start is called before the first frame update
public override void EnterState(MovementStateManager stateManager)
    {
        stateManager.anim.SetBool("Running", true);
    }

    public override void UpdateState(MovementStateManager stateManager)
    {
       if(Input.GetKeyUp(KeyCode.LeftShift)){
            this.ExitState(stateManager, stateManager.walkState);
       }else if(stateManager.dir.magnitude < 0.1){
           this.ExitState(stateManager, stateManager.idleState);
       }
      
        if (stateManager.vInput<0){
            stateManager.currentMoveSpeed = stateManager.runBackSpeed;
        }
        else{
            stateManager.currentMoveSpeed = stateManager.runSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.previousState = this;
            ExitState(stateManager, stateManager.jumpState);
        }
       
    }
    void ExitState(MovementStateManager stateManager, MovmentBaseState newState)
    {
        stateManager.anim.SetBool("Running", false);
        stateManager.SwitchState(newState);
    }

}
