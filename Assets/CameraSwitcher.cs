using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera1;
    [SerializeField] private CinemachineVirtualCamera _camera2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //switch bettween cameras when player press 'C'
         if(Input.GetKeyDown(KeyCode.C))
         {
              _camera1.Priority = _camera1.Priority == 0 ? 1 : 0;
              _camera2.Priority = _camera2.Priority == 0 ? 1 : 0;
         }
    }
}
