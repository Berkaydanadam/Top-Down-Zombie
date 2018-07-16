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
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            itemSpawn.totalItemsOnGround--;//removes item from ground
            PickUp();
        }
    }
    public virtual void PickUp()
    {

    }
}
