using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;

    [SerializeField] bool semiAuto;

    [Header("Bullet properties")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] float bulletPerShot;

    public float damage = 20;

    AimStateManager aimStateManager;
    [SerializeField] AudioClip fireSound;
    AudioSource audioSource;

    WeaponRecoil weaponRecoil;

    Light muzzleFlash;
    ParticleSystem muzzleParticles;
    float lightIntensity;
    [SerializeField] float lightDecaySpeed = 20;

    WeaponBloom weaponBloom;

    public float enemyKickback = 100f;
    // Start is called before the first frame update
    void Start()
    {
        weaponBloom = GetComponent<WeaponBloom>();
        muzzleFlash = GetComponentInChildren<Light>();
        muzzleParticles = GetComponentInChildren<ParticleSystem>();
        weaponRecoil = GetComponent<WeaponRecoil>();
        audioSource = GetComponent<AudioSource>();
        aimStateManager = GetComponentInParent<AimStateManager>();
        fireRateTimer = fireRate;
        lightIntensity = muzzleFlash.intensity;
        muzzleFlash.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldFire()){
            Fire();
        }
        muzzleFlash.intensity = Mathf.Lerp(muzzleFlash.intensity, 0, lightDecaySpeed * Time.deltaTime);
    }
    
    bool ShouldFire(){
        fireRateTimer += Time.deltaTime;

        if(fireRateTimer <fireRate){
            return false;
        }
        if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)){
            return true;
        }
        if(!semiAuto && Input.GetKey(KeyCode.Mouse0)){
            return true;
        }
        return false;
    }

    void Fire(){
        fireRateTimer = 0;
        barrelPos.LookAt(aimStateManager.aimPos);
        audioSource.PlayOneShot(fireSound);
        weaponRecoil.TriggerRecoil();
        barrelPos.localEulerAngles = weaponBloom.BloomAngle(barrelPos);

        TriggleMuzzleFlash();
        for (int i = 0; i < bulletPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bulletPrefab, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.direction = barrelPos.transform.forward;
            bulletScript.weaponManager = this;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
    }

    void TriggleMuzzleFlash(){
        muzzleParticles.Play();
        muzzleFlash.intensity = lightIntensity;
    }
}
