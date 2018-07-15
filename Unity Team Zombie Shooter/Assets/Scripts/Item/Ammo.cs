using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Item, IPickup {
    public Ammo()
    {
        ammo = 30;
        turnSpeed = 20f;
    }
    public override void PickUp()
    {
        playerStats.ammo += ammo;//Adds the ammo to the player stats
        Destroy();
    }
}
