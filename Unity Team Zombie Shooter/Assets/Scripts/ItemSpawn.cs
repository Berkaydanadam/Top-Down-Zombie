using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public GameObject Player;
    public List<GameObject> items = new List<GameObject>();

    public float nextSpawn = 0; //Time in seconds for the next spawn of item
    public int itemNumber; //number from list, starts at 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnDecider());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnItem()
    {
        itemNumber = Random.Range(0, items.Count); //decide what type of item to spawn - gets a random item from the item list.

        //random location from player
        Instantiate(items[itemNumber], new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        //Debug.Log("Spawning: " + items[itemNumber].name);
        StartCoroutine(SpawnDecider());
    }
    IEnumerator SpawnDecider()
    {
        nextSpawn = Random.Range(0, 5); //set a random time for the next spawn
        yield return new WaitForSeconds(nextSpawn);
        SpawnItem();
    }

}
