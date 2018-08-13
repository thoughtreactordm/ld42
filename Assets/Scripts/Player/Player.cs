using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameManager gm;
    Rigidbody rb;
    public PlayerWeapon weapon;

    int health;
    public int maxHealth;

    HealthDisplayController healthDisplay;

    public GameObject explosion;
    public GameObject graphics;

    // Use this for initialization
    void Start () {
        health = maxHealth;

        rb = GetComponent<Rigidbody>();
        gm = GameManager.instance;

        healthDisplay = GameObject.FindGameObjectWithTag("HealthDisplay").GetComponent<HealthDisplayController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
            gm.GameOver();
            Explode();
        }
	}

    public void RecoverHealth()
    {
        health = maxHealth;
        healthDisplay.SetDisplay(health);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthDisplay.SetDisplay(health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWall")) {
            PlayerWall wall = collision.collider.GetComponent<PlayerWall>();
            //wall.StopGrowing();
            gm.GameOver();
            Explode();
        }
    }

    public void Explode()
    {
        graphics.SetActive(false);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
