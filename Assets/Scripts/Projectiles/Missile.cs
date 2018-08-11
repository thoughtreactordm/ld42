using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWall")) {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

}
