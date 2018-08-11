using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBullet : MonoBehaviour {

    public GameObject wall;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Wall")) {
            ContactPoint contact = collision.contacts[0];
            SpawnWall(contact);
        } else if (collision.other.CompareTag("Enemy")) {
            // do enemy things here
        }
    }

    void SpawnWall(ContactPoint contact)
    {
        Vector3 wallDir = -transform.forward;
        rb.isKinematic = true;
        Vector3 wallSpawnPos = new Vector3(contact.point.x, 0, contact.point.z);

        Quaternion wallRot = Quaternion.LookRotation(wallDir);

        GameObject wallObj = Instantiate(wall, wallSpawnPos, wallRot) as GameObject;
    }
}
