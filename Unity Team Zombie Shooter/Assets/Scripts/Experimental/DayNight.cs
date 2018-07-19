using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    [Range(0.0f, 23.9f)]
    public float test = 0;
    float x;
    float y;

    public bool cycle = false; //goes from night to day if set to true

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnValidate () {
		if (cycle == true)
        {
            //day and night cycle
        }
        x =  15 * test;
        y =  3 * test;
        transform.rotation = Quaternion.Euler(x, y, 0);

    }
}
