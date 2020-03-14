using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTopspinForce : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == gameObject) {
            print("Hello");
            rb.AddTorque(Vector3.up * 10, ForceMode.Force);

            //rb.AddTorque(collision.gameObject.GetComponent<Rigidbody>().velocity, ForceMode.Force);
        }
    }
}
