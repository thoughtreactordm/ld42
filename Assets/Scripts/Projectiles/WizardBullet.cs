using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : MonoBehaviour {

    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) {
            Destroy(this.gameObject);

            Player player = collision.collider.gameObject.GetComponent<Player>();

            player.TakeDamage(damage);
        } else {
            Destroy(this.gameObject);
        }
    }

}
