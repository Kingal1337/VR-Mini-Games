using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewButtonCode : MonoBehaviour
{
    public GameObject stand;//the stand which the button is on

    public float pushLength = .05f;//how far down the button will get pushed

    public float forceUpward = 10f;
    public float maxForce = 50f;
    private Vector3 originPosition;

    private Rigidbody rb;

    private bool pressed;
    private bool touching;


    void Start()
    {
        originPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ClampPosition();

        transform.localRotation = stand.transform.localRotation;

        if (pressed) {
            if (!touching) {
                rb.AddForce(new Vector3(0, forceUpward, 0), ForceMode.Impulse);
            }
            //if (rb.velocity.magnitude > maxForce) {
            //    rb.velocity = new Vector3(0, 1, 0) * maxForce;
            //}
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (stand == null || collision.gameObject != stand) {
            print("Being Touched");
            touching = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (stand == null || collision.gameObject != stand) {
            print("FALSE ");
            touching = false;
        }
    }

    void ResetVelocity() {
        rb.velocity = Vector3.zero;
    }

    void ClampPosition() {
        Vector3 tmpPos = transform.localPosition;
        tmpPos.x = originPosition.x;
        tmpPos.z = originPosition.z;
        tmpPos.y = Mathf.Clamp(tmpPos.y, originPosition.y - pushLength, originPosition.y);
        if (VRUtilities.AlmostEquals(tmpPos.y, originPosition.y - pushLength, .005f)) {
            pressed = true;
        }
        else {
            pressed = false;
        }

        transform.localPosition = tmpPos;
    }
}
