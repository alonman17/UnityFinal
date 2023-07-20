using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipWin : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            if(PlayerInventory.fuelCount == 4){
                PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                PlayerState.currentHealth =  playerHealth.currentHealth;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(4);
            }
            
        }
    }
}
