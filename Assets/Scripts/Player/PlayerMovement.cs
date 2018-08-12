using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    Rigidbody rb;

    public bool canMove;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if (GameManager.instance.ready) {
            canMove = true;
        } else {
            canMove = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canMove) {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            rb.velocity = movement * speed;
        }
	}
}
