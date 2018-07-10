using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    //Everything is set to public for testing purposes
    //totalZombies per wave will be (5 * wave), 5 more zombies will be added each wave. - change this later if needed

    public GameObject zombiePrefab; //Single prefab for the zombies, rewrite the code if we would use different zombie prefabs
    public GameObject Player;

    public int wave = 0; //wave number
    public int totalZombies; //total zombies in the current wave
    public int aliveZombies; //alive zombiesi in the current wave
    public float minimumDistance = 5.0f; //min distance for zombie spawn from player
    public float maximumDistance = 10.0f; //max ^^

    public bool spawnEnable = true; //set true if game is ready to spawn, turn off while spawning.
    public bool nextWave = false;

	// Use this for initialization
	void Start ()
    {
        //Spawn first wave of zombies
        wave = 1;
        Spawn();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check for alive zombies
        aliveZombies = GameObject.FindGameObjectsWithTag("Zombie").Length;

        if ((aliveZombies == 0 || aliveZombies < 0) && nextWave == false)
        {
            nextWave = true;
            StartCoroutine(NextWave());
        }
    }

    IEnumerator Spawn()
    {
        if (spawnEnable == true && aliveZombies == 0)
        {
            float randomX = 0;
            float randomZ = 0;

            spawnEnable = false; //Set spawn to false during spawning so it wont be triggered multiple times
            totalZombies = wave * 5; //Add the right amount of zombies each spawn round

            for (int i = 0; i < totalZombies; i++)
            {
                /*This can definitely be done in a better way*/
                //This will give the zombies different locations for all of them
                do
                {

                    //eliminates every position 5 feet from the player ----- minimum distance in this

                    randomX = Random.Range(maximumDistance * -1, maximumDistance); //change this for maximum distance  
                    if(randomX + Player.gameObject.transform.position.x > 5.0f || randomX < -5.0f)
                    {
                        //if X is in the right values it will loop and check for Z 
                        do
                        {
                            randomZ = Random.Range(maximumDistance * -1, maximumDistance);
                            if (randomZ + Player.gameObject.transform.position.y > minimumDistance || randomZ < minimumDistance * -1)
                            {
                                //if Z is in the right value it will break loop
                                break;
                            }
                        } while (true);
                        break; //break when both Z and X is right values
                    }
                } while (true);

                randomX = randomX + Player.gameObject.transform.position.x; //set values for the spawn positions
                randomZ = randomZ + Player.gameObject.transform.position.y;
                Instantiate(zombiePrefab, new Vector3(randomX, 1, randomZ), Quaternion.identity);

                Debug.Log("Spawn at X: " + randomX + " and Y: " + randomZ);
            }
            Debug.Log("Spawning complete");
            spawnEnable = true;
        }
    }

    IEnumerator NextWave()
    {
        Debug.Log("Wait 5 sec for next wave");
        yield return new WaitForSeconds(5);
        Debug.Log("Wave: " + wave);
        wave++;
        nextWave = false;
        Spawn();
    }

}
