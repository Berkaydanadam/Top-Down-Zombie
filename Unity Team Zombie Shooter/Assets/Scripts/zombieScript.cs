using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieScript : MonoBehaviour {

    //Some have Armor?
    public float health = 100; //Change to prefrence
    public float damage = 10;
    public float timeBetweenAttacks = 3;

    public bool attack;

    GameObject playerObj;
    NavMeshAgent agent;

    playerStatScript player;

    Renderer rend;

	void Start () {
        attack = true;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<playerStatScript>();
        agent = GetComponent<NavMeshAgent>();
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
    }

	void Update () {
        //Sets the goal of the agent to get to the players transform
        agent.destination = playerObj.transform.position;

        //Change color for debugging
        if (attack) {
            rend.material.color = Color.green;
        }
        else {
            rend.material.color = Color.red;
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject == playerObj && attack) {
            Attack();
            StartCoroutine(WaitToAttack(timeBetweenAttacks)); //Makes it wait some secs to change the bool
        }
    }

    void Attack() { //Takes the health of the player
        attack = false;
        Debug.Log("Lose: " + damage.ToString());
        player.health -= damage; //Maybe later make this a function in playerstat
    }

    IEnumerator WaitToAttack (float seconds) {
        yield return new WaitForSeconds(seconds);
        attack = true;
    }
}
