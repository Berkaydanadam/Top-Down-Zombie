using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float turnSpeed = .01f; // Keep this number extremly low!
    int groundMask;
    float camRayLength = 100; //random number

	void Update () {
    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground"); // Have to have a layer mask for ground to use rotate
    }

    // Update is called once per frame
    void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical); // So sorry for this horrible function. Just had to add local movement somehow
                                    //and this was the only way I could think of at this state of mind. It works but 
                                    //you can make it a little more practical if you like
        Rotating();
    }

    private void Move(float horizontal, float vertical)
    {
        if (vertical > 0)// If statement Hell so sorry
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        if (vertical < 0)
        {
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;
        }
        if (horizontal > 0)
        {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
        }
        if (horizontal < 0)
        {
            transform.position -= transform.right * movementSpeed * Time.deltaTime;
        }
    }

    void Rotating() {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //casts a ray from the mouse to the ground and rotates
                                                                        //to look at that postition
        RaycastHit floorHit;

        if(Physics.Raycast (camRay, out floorHit, camRayLength, groundMask)) {

            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, turnSpeed);
        }
    }
}
