using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public WeaponManager weaponManager;

    [HideInInspector] public Vector3 direction;
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponentInParent<EnemyHealth>() != null)
        {
            EnemyHealth enemyHealth= other.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(weaponManager.damage);

            if(enemyHealth.currentHealth <= 0 && enemyHealth.isDead == false)
            {
                Rigidbody rb = other.gameObject.GetComponentInChildren<Rigidbody>();
                rb.AddForce(direction * weaponManager.enemyKickback, ForceMode.Impulse);
                enemyHealth.isDead = true;
            }
        }
        Destroy(this.gameObject);
    }
}
