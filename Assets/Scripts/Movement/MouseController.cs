using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This MouseController gets the Euler Angles of the Mouse,
 * 
 * @author Alan Tsui
 */
public class MouseController : MonoBehaviour {
    public float sensX = 200f;//the sensitivity of the mouse 
    public float sensY = 200f;//the sensitivity of the mouse 

    public float range = 90;//the range at which the camera can move up and down

    private float xRotation = 0f;

    public Transform player;

    // Start is called before the first frame update
    void Start() {
        //The statement below should be moved in the future
        Cursor.lockState = CursorLockMode.Locked;//Locks the cursor to the middle of the screen.
    }

    // Update is called once per frame
    void Update() {
        float mouseX = sensX * Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseY = sensY * Input.GetAxis("Mouse Y") * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -range, range);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}
