using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AimStateManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AimBaseState currentState;
    public HipFireState hipFireState = new HipFireState();
    public AimState aimState = new AimState();


    float xAxis, yAxis;
    [SerializeField] float sensitivity;
    [SerializeField] Transform camFollowPos;

    [HideInInspector] public Animator anim;

    [HideInInspector] public CinemachineVirtualCamera cam;
    public float adsFOV = 40f;
    [HideInInspector] public float hipFOV;
    [HideInInspector] public float currentFOV;

    public Transform aimPos;
    [SerializeField] float aimSmoothSpeed = 10;
    [SerializeField] LayerMask aimMask;
    public float FOVSmoothSpeed = 10;

    float xFollowPos, yFollowPos;
    float ogYPos;
    [SerializeField] float crouchCameraHeight = 0.5f;
    [SerializeField] float sholderSwapSpeed = 10;
    MovementStateManager movementStateManager;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movementStateManager = GetComponent<MovementStateManager>();
        ogYPos = camFollowPos.localPosition.y;
        xFollowPos = camFollowPos.localPosition.x;
        yFollowPos = ogYPos;
        cam = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFOV = cam.m_Lens.FieldOfView;
        anim = GetComponent<Animator>();
        SwitchState(hipFireState);
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis += Input.GetAxis("Mouse X") * sensitivity;
        yAxis -= Input.GetAxis("Mouse Y") * sensitivity;
        yAxis = Mathf.Clamp(yAxis, -80f, 80f);

        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, currentFOV, Time.deltaTime * FOVSmoothSpeed);

        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, Time.deltaTime * aimSmoothSpeed);
        }

        currentState.UpdateState(this);
        MoveCamera();
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, xAxis, transform.localEulerAngles.z);
    }

    public void SwitchState(AimBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    void MoveCamera(){
        if(Input.GetKeyDown(KeyCode.LeftAlt)){
            xFollowPos = -xFollowPos;
        }
        if(movementStateManager.currentState == movementStateManager.crouchState){
            yFollowPos = yFollowPos = crouchCameraHeight;
        }
        else
        {
            yFollowPos = ogYPos;
        }

        Vector3 newPos = new Vector3(xFollowPos, yFollowPos, camFollowPos.localPosition.z);
        camFollowPos.localPosition = Vector3.Lerp(camFollowPos.localPosition, newPos, Time.deltaTime * sholderSwapSpeed);
    }
}
