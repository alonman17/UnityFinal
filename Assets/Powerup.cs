using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponManager weaponManager = other.GetComponentInChildren<WeaponManager>();
            weaponManager.SetBulletDamage(weaponManager.damage + 10);
            Destroy(gameObject);
        }
    }

}
