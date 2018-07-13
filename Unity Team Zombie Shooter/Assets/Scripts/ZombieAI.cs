using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour {

    public float walkRadius = 4;

    bool playerDetected;

    GameObject playerObj;

    GameObject zombie;
    ZombieAI AIScript;

    NavMeshAgent agent;

    Renderer rend;

    void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        AIScript = zombie.GetComponent<ZombieAI>();
        agent = GetComponent<NavMeshAgent>();

        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
    }
	
	void Update () {
        agent.SetDestination(RandomNavmeshLocation(walkRadius));

        if (playerDetected) {
            rend.material.color = Color.green;
        }
        else {
            rend.material.color = Color.red;
        }

        //Sets the goal of the agent to get to the players transform
        if (playerDetected) {
            agent.destination = playerObj.transform.position;
        }
    }

    //Finds a random location inside the radius
    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == playerObj) {
            playerDetected = true;
        }
        if(other.gameObject == zombie) {
            GroupDetect();
        }
    }

    public void GroupDetect() {
        if (AIScript.playerDetected) {
            playerDetected = true;
        }
    }
}
