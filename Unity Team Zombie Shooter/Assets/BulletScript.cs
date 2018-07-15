using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	void Start () {
    }
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == ("Zombie")) {
            collision.gameObject.GetComponent<zombieScript>().health -= 
                GameObject.FindGameObjectWithTag("Weapon").GetComponent<gunScript>().damage;
            Destroy(gameObject);
        }
    }
}
