using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public GameObject Player;
    public List<GameObject> items = new List<GameObject>();
    //public GameObject[] itemsOnGround;
    public List<GameObject> itemsOnGroundList = new List<GameObject>();
    public float nextSpawnTime = 0; //Time in seconds for the next spawn of item

    public int itemNumber; //number from list, starts at 0;
    public int maxItemsOnGround; //max items on ground allowed
    public int totalItemsOnGround; //total items on the ground at the moment
    public int maxTime = 0;
    public int minTime = 0;

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
        if (totalItemsOnGround < maxItemsOnGround)
        {
            //spawn item
            Instantiate(items[itemNumber], new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            totalItemsOnGround++;
            updateItemOnGroundList();
        }
        else
        {
            //remove item
            int removeRandom = Random.Range(0, itemsOnGroundList.Count);

            Destroy(itemsOnGroundList[removeRandom]); //destroys item
            itemsOnGroundList.RemoveAt(removeRandom); //remove the position from list
            totalItemsOnGround--; 
            StartCoroutine(SpawnDecider());
        }

    }
    IEnumerator SpawnDecider()
    {
        nextSpawnTime = Random.Range(minTime, maxTime); //set a random time for the next spawn
        yield return new WaitForSeconds(nextSpawnTime);
        SpawnItem();
    }
    public void updateItemOnGroundList()
    {
        itemsOnGroundList.Clear();
        itemsOnGroundList.AddRange(GameObject.FindObjectsOfType<GameObject>()); //gets all gameobjects in scene

        foreach (GameObject item in itemsOnGroundList.ToArray())
        {
            if (item != null) //check all spaces thats not null
            {
                if (item.tag.Contains("Item") == false) //if its not an Item it will be removed
                {
                    itemsOnGroundList.Remove(item);
                }
            }
            else if (item == null) //remove empty spaces
            {
                itemsOnGroundList.Remove(item);
            }
        }
        StartCoroutine(SpawnDecider());
    }

}
