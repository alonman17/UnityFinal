using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerHealth : MonoBehaviour
{

    [HideInInspector] static public float currentHealth;
    [SerializeField] public float maxHealth = 100;
    [HideInInspector] public bool isDead = false;
    [SerializeField] private AudioSource hitSound;

    public GameObject deathCam;
    private Animator anim;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {   
        // currentHealth = maxHealth;
        uiManager  = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        anim = GetComponent<Animator>();
        uiManager.UpdateHealthText(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth <= 0)
        {
            return;
        }
        hitSound.Play();
        anim.SetTrigger("Hit");
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage");
        uiManager.UpdateHealthText(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        anim.enabled = false;
        deathCam.SetActive(true);
        GetComponentInChildren<WeaponManager>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<MovementStateManager>().enabled = false;
        GetComponent<RagdollManager>().TriggerRagdoll();
        GetComponent<AimStateManager>().enabled = false;    
        Rigidbody rb = GetComponentInChildren<Rigidbody>();

    }
}
