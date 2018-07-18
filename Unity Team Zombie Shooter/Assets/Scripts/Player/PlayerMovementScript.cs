using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float turnSpeed = .01f; // Keep this number extremly low!
    int groundMask;
    float camRayLength = 100; //random number

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground"); // Have to have a layer mask for ground to use rotate
    }

    // Update is called once per frame
    void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);


        Rotating();
    }

    void Rotating() {
        //Ray cast from the mouse to the ground from the camera angle
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); 

        //The location on the ground under the mouse
        RaycastHit floorHit;

        if(Physics.Raycast (camRay, out floorHit, camRayLength, groundMask)) {

            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Changes the rotation to the look rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, turnSpeed);
        }
    }
}
