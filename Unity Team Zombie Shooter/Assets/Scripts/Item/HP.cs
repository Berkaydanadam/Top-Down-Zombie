using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : Item, IPickup {
    public HP()
    {
        health = 20;
        turnSpeed = 20f;
    }
    public override void PickUp()
    {
        playerStats.health += health;//Adds the health to the player stats
        Destroy();
    }
}
