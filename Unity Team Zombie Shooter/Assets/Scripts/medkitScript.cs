using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitScript : MonoBehaviour
{

    public int health = 20; //Random number
    public float turnSpeed = 20f;

    GameObject playerObj;
    playerStatScript player;
    ItemSpawn itemSpawn;


    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<playerStatScript>();
        itemSpawn = GameObject.FindGameObjectWithTag("SpawnSystem").GetComponent<ItemSpawn>();
    }

    void Update() {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerObj) {
            player.health += health;//Adds the health to the player stats
            itemSpawn.totalItemsOnGround--;//removes item from ground
            Destroy();
        }
    }

    //Made this a function so we can add a animation and all that good stuff
    private void Destroy() {
        Object.Destroy(gameObject);
    }

}
