using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    // Start is called before the first frame update
     public override void EnterState(AimStateManager stateManager){
        stateManager.anim.SetBool("Aiming", false);
        stateManager.currentFOV = stateManager.hipFOV;

     }
    public override void UpdateState(AimStateManager stateManager){
        if (Input.GetKey(KeyCode.Mouse1)){
            stateManager.SwitchState(stateManager.aimState);
        }
    }
}
