using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup {

    public override void Handle(Player player)
    {
        base.Handle(player);

        player.RecoverHealth();
    }
}
