using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IPickup {

    public int ammo;
    public int health;
    public float turnSpeed;

    public playerStatScript playerStats;
    public ItemSpawn itemSpawn;


    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatScript>();
        itemSpawn = GameObject.FindGameObjectWithTag("SpawnSystem").GetComponent<ItemSpawn>();

    }

    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("test");
            itemSpawn.totalItemsOnGround--;//removes item from ground
            PickUp();
        }
        if (other.gameObject.tag.Contains("Environment")) //if item spawns in an wall for example
        {
            itemSpawn.totalItemsOnGround--;//removes item from ground int
            itemSpawn.SpawnItem(); //spawns new one
            Debug.Log("spawned new and destroying");
            Object.Destroy(gameObject);
        }

    }
    public virtual void PickUp()
    {

    }
}
