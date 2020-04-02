using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTopspinForce : MonoBehaviour
{
    private Rigidbody rigidBody;

    public GameObject racket;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == racket) {
            if (rigidBody != null) {
                rigidBody.AddTorque(Vector3.up * 10, ForceMode.Force);
            }
        }
    }
}
