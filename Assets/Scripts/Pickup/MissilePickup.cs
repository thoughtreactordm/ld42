using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePickup : Pickup {

    public override void Handle(Player player)
    {
        base.Handle(player);

        player.weapon.FillMissleAmmo();
    }
}
