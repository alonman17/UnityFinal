using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBloom : MonoBehaviour
{
    [SerializeField] float defualtBloomAngle = 3;
    [SerializeField] float walkBloomMultiplier = 1.5f;
    [SerializeField] float runBloomMultiplier = 2;
    [SerializeField] float crouchBloomMultiplier = 0.5f;
    [SerializeField] float adsBloomMultiplier = 0;

    MovementStateManager movementStateManager;
    AimStateManager aimStateManager;

    float currentBloom;

    void Start()
    {
        movementStateManager = GetComponentInParent<MovementStateManager>();
        aimStateManager = GetComponentInParent<AimStateManager>();
    }

    // Update is called once per frame
    public Vector3 BloomAngle(Transform barrelPos){
        if(movementStateManager.currentState == movementStateManager.walkState)
        {
            currentBloom = defualtBloomAngle * walkBloomMultiplier;
        }
        else if(movementStateManager.currentState == movementStateManager.runState)
        {
            currentBloom = defualtBloomAngle * runBloomMultiplier;
        }
        else if(movementStateManager.currentState == movementStateManager.crouchState)
        {
            if(movementStateManager.dir.magnitude == 0){
                currentBloom = defualtBloomAngle * crouchBloomMultiplier;
            }
            else{
                currentBloom = defualtBloomAngle * walkBloomMultiplier * crouchBloomMultiplier;
            }
        }
        else if(movementStateManager.currentState == movementStateManager.idleState)
        {
            currentBloom = defualtBloomAngle;
        }

        if(aimStateManager.currentState == aimStateManager.aimState)
        {
            currentBloom *= adsBloomMultiplier;
        }

        float randomX = Random.Range(-currentBloom, currentBloom);
        float randomY = Random.Range(-currentBloom, currentBloom);
        float randomZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randomX, randomY, randomZ);

        return barrelPos.localEulerAngles + randomRotation;
    }
}
