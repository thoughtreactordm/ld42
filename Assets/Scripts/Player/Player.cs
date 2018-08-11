using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameManager gm;
    Rigidbody rb;
    public PlayerWeapon weapon;


    int health;
    public int maxHealth;

    bool phaseShield;

    // Use this for initialization
    void Start () {
        health = maxHealth;

        rb = GetComponent<Rigidbody>();
        gm = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
            gm.GameOver();
        }
	}

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWall") && !phaseShield) {
            gm.GameOver();
        }
    }
}
