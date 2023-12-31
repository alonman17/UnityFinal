using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            if(PlayerInventory.batteryCount == 3){
                PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                PlayerState.currentHealth =  playerHealth.currentHealth;
                SceneManager.LoadScene(3);
            }
            
        }
    }
}
