using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]public float currentHealth;
    [SerializeField] public float maxHealth;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public HealthBar healthBar;
    

    RagdollManager ragdollManager;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PlayerState.getDifficultyHealth();
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
        ragdollManager = GetComponent<RagdollManager>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("Hit");
        if(currentHealth <= 0)
        {
            return;
        }

        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage");
        healthBar.updateHealthBar(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            EnemyDeath();
        }
    }
    void EnemyDeath()
    {
        anim.enabled = false;
        ragdollManager.TriggerRagdoll();
        GetComponent<AiController>().enabled = false;
        Debug.Log("Enemy is dead");
    }
}
