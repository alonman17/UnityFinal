using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static int batteryCount = 0;
    public static int fuelCount = 0;
    public AudioSource batteryPickupSound;
 

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Player collided with " + other.gameObject.name);
        if(other.tag == "Battery")
        {
            batteryPickupSound.Play();
            
            UIManager.instance.DisplayBattery(batteryCount++);
            Destroy(other.gameObject);
        }
        if(other.tag =="Fuel"){
            UIManager.instance.DisplayFuel(fuelCount++);
            batteryPickupSound.Play();
            Destroy(other.gameObject);
        }
    }
}
