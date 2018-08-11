using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public Transform shooter;
    int missileCapacity = 3;
    public int missiles;

    public enum WeaponState { Normal, Penetrate, NoWalls };
    public WeaponState state;

    public GameObject[] bullets;
    public GameObject missile;

    public float fireRate;
    float fireTimer;
    public float bulletSpeed;

    // Use this for initialization
    void Start () {
        missiles = missileCapacity;
    }
	
	// Update is called once per frame
	void Update () {
        fireTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1")) {
            if (fireTimer > fireRate) {
                PrimaryFire();
            }
        } else if (Input.GetButtonDown("Fire2")) {
            if (fireTimer > fireRate && missiles > 0) {
                SecondaryFire();
            }
        }
    }

    void PrimaryFire()
    {
        GameObject bullet = Instantiate(bullets[(int)state], shooter.position, Quaternion.LookRotation(shooter.forward)) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shooter.transform.forward * bulletSpeed, ForceMode.Impulse);

        fireTimer = 0;
    }


    public void FillMissleAmmo()
    {
        missiles = missileCapacity;
    }

    void SecondaryFire()
    {
        GameObject bullet = Instantiate(missile, shooter.position, Quaternion.LookRotation(shooter.forward)) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shooter.transform.forward * bulletSpeed, ForceMode.Impulse);

        fireTimer = 0;
        missiles--;
    }
}
