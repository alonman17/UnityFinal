using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] Transform recoilFollowPos;
    [SerializeField] float kickBackAmout = -1;
    [SerializeField] float kickBackSpeed=10 , returnSpeed=20;

    float currentRecoilPositon, finalRecoilPosition;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        currentRecoilPositon = Mathf.Lerp(currentRecoilPositon, 0, returnSpeed * Time.deltaTime);
        finalRecoilPosition = Mathf.Lerp(finalRecoilPosition, currentRecoilPositon, kickBackSpeed * Time.deltaTime);
        recoilFollowPos.localPosition = new Vector3(0, 0, finalRecoilPosition);
    }

    public void TriggerRecoil(){
        currentRecoilPositon += kickBackAmout;
    }
}
