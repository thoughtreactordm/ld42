using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private void Awake()
    {
        Destroy(this.gameObject, 20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Handle(other.gameObject.GetComponent<Player>());
            Destroy(this.gameObject);
        }
    }

    public virtual void Handle(Player player) {

    }
}
