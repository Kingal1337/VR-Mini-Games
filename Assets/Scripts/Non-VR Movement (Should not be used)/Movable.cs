using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
    
    public bool forward;           //true if the object is moving to the forward
    public bool backward;          //true if the object is moving to the backward
    public bool left;              //true if the object is moving to the left
    public bool right;             //true if the object is moving to the right
    public bool jumping;           //true if the object is jumping
    public bool sprinting;         //true if the object is sprinting

    public CharacterController controller;//the CharacterController component

    public float currentSpeed;

    public float speed = 5f;//the speed the object can walk
    public float sprintSpeed = 10f;//the sprint speed
    public float gravity = -9.81f;//the gravity of the object
    public float jumpHeight = 1.5f;//how high the object can jump

    public Transform groundCheck;//The groundcheck object
    public float groundDistance = 0.4f;//the distance from the object to the ground to check.
    public LayerMask groundMask;//the ground mask, should only contain objects in which the object can jump on

    private Vector3 velocity;//the velocity for jumping
    private bool isGrounded;//a boolean to check if the object is on the ground

    // Update is called once per frame
    void Update() {
        //Checks if object is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        //LEFT = -1, RIGHT = 1, NO_MOVEMENT = 0;
        float x = left && right ? 0 : right ? 1 : left ? -1 : 0;

        //FORWARD = 1, BACKWARD = -1, NO_MOVEMENT = 0;
        float z = forward && backward ? 0 : forward ? 1 : backward ? -1 : 0;

        currentSpeed = speed;
        if (sprinting) {
            currentSpeed = sprintSpeed;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);//apply move vector

        if (jumping && isGrounded) {//calculate jump force if object is standing on the ground and presses jump button
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;//gravity force
        controller.Move(velocity * Time.deltaTime);//apply jump force
    }
}
