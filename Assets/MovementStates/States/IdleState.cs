using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovmentBaseState
{
    public override void EnterState(MovementStateManager stateManager)
    {
        
    }

    public override void UpdateState(MovementStateManager stateManager)
    {
        if(stateManager.dir.magnitude > 0.1)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                stateManager.SwitchState(stateManager.runState);
            }
            else
            {
                stateManager.SwitchState(stateManager.walkState);
            }
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            stateManager.SwitchState(stateManager.crouchState);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.previousState = this;
            stateManager.SwitchState(stateManager.jumpState);
        }
    }
}
