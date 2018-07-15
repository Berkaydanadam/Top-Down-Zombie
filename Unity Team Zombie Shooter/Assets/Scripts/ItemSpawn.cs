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
        if(totalItemsOnGround < maxItemsOnGround)
        {
            Debug.Log("Spawns item");

            //spawn item
            Instantiate(items[itemNumber], new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            totalItemsOnGround++;
            Debug.Log("++");
            updateItemOnGroundList();


        }
        else if(totalItemsOnGround >= maxItemsOnGround) //if there is too many items on the ground
        {
            //remove one random 
            int itemsOnGroundListCount = itemsOnGroundList.Count - 1;
            if(itemsOnGroundListCount < 0)
            {
                itemsOnGroundListCount = 0;
                updateItemOnGroundList();
            }
            int removingRandomItem = Random.Range(0, itemsOnGroundListCount);
            Destroy(itemsOnGroundList[removingRandomItem]);
            itemsOnGroundList.RemoveAt(removingRandomItem);
            totalItemsOnGround--;
            Debug.Log("destroy + removeat + go to spawnitem()");
            SpawnItem();
        }
        else
        {
            updateItemOnGroundList();
            Debug.Log("else updateitemongroundlist()");
        }

        //Debug.Log("Spawning: " + items[itemNumber].name);
        StartCoroutine(SpawnDecider());
    }
    IEnumerator SpawnDecider()
    {
        Debug.Log("SpawnDecider() starter from IE");
        nextSpawnTime = Random.Range(0, 5); //set a random time for the next spawn
        yield return new WaitForSeconds(2);
        SpawnItem();
    }
    public void updateItemOnGroundList()
    {
        if (itemsOnGroundList.Count > maxItemsOnGround || itemsOnGroundList.Count < maxItemsOnGround)
        {
            itemsOnGroundList.Clear();
            itemsOnGroundList.AddRange(GameObject.FindObjectsOfType<GameObject>()); //gets all gameobjects in scene

            Debug.Log("clear and addrange");
        }

        //removes every gameobject that does not contain Item from list
        foreach (GameObject item in itemsOnGroundList.ToArray())
        {
            if(item != null)
            {
                if (item.tag.Contains("Item") == false)
                {
                    itemsOnGroundList.Remove(item);
                    Debug.Log("remove item from list");
                }
            }
            else if(item == null)
            {
                itemsOnGroundList.Clear();
                Debug.Log("clear list");
            }
        }
    }
}
