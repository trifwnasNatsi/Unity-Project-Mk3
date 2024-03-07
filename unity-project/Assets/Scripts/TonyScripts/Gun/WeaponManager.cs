using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private float fireRate;
    private float fireRateTimer;
    [SerializeField] private bool semiAuto;
    [SerializeField] private int bulletsPerShots;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barelPosition;
    [SerializeField] private float bulletVelocity;
    private AimStateManager aim;
    [SerializeField] private AudioClip gunShot;
    AudioSource audioSource;

    public float damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        aim = GetComponentInParent<AimStateManager>();
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFire()) Fire();
    }

    bool shouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if(fireRateTimer < fireRate) return false;
        if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if(!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barelPosition.LookAt(aim.aimPosition);
        for (int i = 0; i < bulletsPerShots; i++)

        audioSource.PlayOneShot(gunShot);         

        {
            GameObject currentBullet = Instantiate(bullet, barelPosition.position, barelPosition.rotation);

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.weapon = this;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
