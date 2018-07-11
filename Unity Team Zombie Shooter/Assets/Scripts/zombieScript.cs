using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieScript : MonoBehaviour {

    //Some have Armor?
    public float health = 100; //Change to prefrence

    GameObject player;
    NavMeshAgent agent;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

	void Update () {
        //Sets the goal of the agent to get to the players transform
        agent.destination = player.transform.position;

        /*
        If the zombies reach the player they start adding odd
        I think I could fix it by an if statement that restates
        the destination if it's reached
        */
    }
}
