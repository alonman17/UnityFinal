using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if(playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.currentHealth += 50;
                if(playerHealth.currentHealth > playerHealth.maxHealth)
                {
                    playerHealth.currentHealth = playerHealth.maxHealth;
                }
                UIManager.instance.UpdateHealthText(playerHealth.currentHealth, playerHealth.maxHealth);
                Destroy(gameObject);
            }
        }
    }
}
