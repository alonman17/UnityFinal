using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMotion : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    Vector2 input;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", input.magnitude);
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Aiming",!animator.GetBool("Aiming"));
        }
        Debug.Log(input);
    }
}
