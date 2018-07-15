using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatScript : MonoBehaviour {

    public float health, maxHealth;
    //Have diffrent types of ammo?
    public int ammo, maxAmmo;

	void Start () {
    }

	void Update ()
    {
        CheckIfMaxed();
        if(health <= 0) {
            Die();
        }
    }

    void Die() { //Add end game here or respawn
        Debug.Log("You dead BOI!");
    }

    private void CheckIfMaxed()
    {
        if (ammo > maxAmmo)
        { //Keep it in the max
            ammo = maxAmmo;
        }
        if (health > maxHealth)
        {//Same for the health
            health = maxHealth;
        }
    }
}
