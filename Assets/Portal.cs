using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            //check if the player has 3 batteries
            //if so, load the next scene
            PlayerInventory playerInventory = collider.gameObject.GetComponent<PlayerInventory>();
            if(playerInventory.batteryCount == 3){
                SceneManager.LoadScene(2);
            }
            
        }
    }
}
