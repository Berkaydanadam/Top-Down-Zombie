using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitScript : MonoBehaviour
{

    public int health = 20; //Random number

    GameObject playerObj;
    playerStatScript player;

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<playerStatScript>();
    }

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerObj) {
            player.health += health;//Adds the health to the player stats
            Destroy();
        }
    }

    //Made this a function so we can add a animation and all that good stuff
    private void Destroy() {
        Object.Destroy(gameObject);
    }

}
