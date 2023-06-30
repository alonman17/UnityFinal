using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public int batteryCount = 0;
    public AudioSource batteryPickupSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Player collided with " + other.gameObject.name);
        if(other.tag == "Battery")
        {
            batteryPickupSound.Play();
            batteryCount++;
            UIManager.instance.DisplayBattery(batteryCount);
            Destroy(other.gameObject);
        }
    }
}
