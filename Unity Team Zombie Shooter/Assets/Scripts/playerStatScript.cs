using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatScript : MonoBehaviour {

    public int health, maxHealth;
    //Have diffrent types of ammo?
    public int ammo, maxAmmo;

	void Start () {
		
	}

	void Update () {
		if(ammo > maxAmmo) { //Keep it in the max
            ammo = maxAmmo;
        }
        if(health > maxHealth) {//Same for the health
            health = maxHealth;
        }
	}
}
