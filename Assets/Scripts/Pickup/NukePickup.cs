using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup {

    public override void Handle(Player player)
    {
        base.Handle(player);

        GameObject[] playerWalls = GameObject.FindGameObjectsWithTag("PlayerWall");

        if (playerWalls != null) {
            foreach (GameObject pw in playerWalls) {
                Destroy(pw);
            }
        }

        Destroy(this.gameObject);
    }
}
