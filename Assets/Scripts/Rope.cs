using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = Enemy.GetComponent<Animator>();
        animator.enabled = false;
        Enemy.GetComponent<RagdollManager>().TriggerRagdoll();

    }


}
