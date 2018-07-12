﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBoxScript : MonoBehaviour {

    public int ammo = 30; //Random number
    public float turnSpeed = 20f;

    GameObject playerObj;
    playerStatScript player;

	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player  = playerObj.GetComponent<playerStatScript>();
    }
	
	void Update () {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == playerObj) {
            player.ammo += ammo;//Adds the ammo to the player stats
            Destroy();
        }
    }

    //Made this a function so we can add a animation and all that good stuff
    private void Destroy() { 
        Object.Destroy(gameObject);
    }

}