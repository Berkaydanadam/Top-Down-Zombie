using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public int damage;

	void Start () {
    }
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == ("Zombie")) {
            collision.gameObject.GetComponent<zombieScript>().health -= damage;
        }
        Destroy(gameObject);
    }
}
