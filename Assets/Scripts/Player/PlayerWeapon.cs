using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public Transform shooter;
    int missileCapacity = 3;
    public int missiles;

    public GameObject bullet;
    public GameObject missile;

    public float fireRate;
    float fireTimer;
    public float bulletSpeed;

    AmmoDisplayController ammoDisplay;
    GameManager gm;

    // Use this for initialization
    void Start () {
        gm = GameManager.instance;
        missiles = missileCapacity;
        ammoDisplay = GameObject.FindGameObjectWithTag("AmmoDisplay").GetComponent<AmmoDisplayController>();
    }
	
	// Update is called once per frame
	void Update () {
        fireTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && gm.ready) {
            if (fireTimer > fireRate) {
                PrimaryFire();
            }
        } else if (Input.GetButtonDown("Fire2") && gm.ready) {
            if (fireTimer > fireRate && missiles > 0) {
                SecondaryFire();
            }
        }
    }

    void PrimaryFire()
    {
        GameObject bulletObj = Instantiate(bullet, shooter.position, Quaternion.LookRotation(shooter.forward)) as GameObject;
        Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();

        bulletRb.AddForce(shooter.transform.forward * bulletSpeed, ForceMode.Impulse);

        fireTimer = 0;
    }

    public void FillMissleAmmo()
    {
        missiles = missileCapacity;
        ammoDisplay.SetDisplay(missiles);
    }

    void SecondaryFire()
    {
        GameObject bullet = Instantiate(missile, shooter.position, Quaternion.LookRotation(shooter.forward)) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shooter.transform.forward * bulletSpeed, ForceMode.Impulse);

        fireTimer = 0;
        missiles--;
        ammoDisplay.SetDisplay(missiles);
    }
}
