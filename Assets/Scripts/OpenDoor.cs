using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
           anim.SetBool("character_nearby", true);
        }
    }
}
