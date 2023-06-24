using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : AimBaseState
{
    // Start is called before the first frame update
    public override void EnterState(AimStateManager stateManager){
        stateManager.anim.SetBool("Aiming", true);
        stateManager.currentFOV = stateManager.adsFOV;

     }
    public override void UpdateState(AimStateManager stateManager){
        if (Input.GetKeyUp(KeyCode.Mouse1)){
            stateManager.SwitchState(stateManager.hipFireState);
        }
    }
}
