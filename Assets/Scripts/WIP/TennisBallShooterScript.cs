using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallShooterScript : MonoBehaviour
{
    public float timeTillShoot = 5;//in seconds

    public GameObject tennisBall;

    private float currentTime;

    public Transform directionVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tennisBall != null) {
            currentTime += Time.deltaTime;
            if (currentTime >= timeTillShoot) {
                currentTime = 0;
                print(currentTime + " " + timeTillShoot);
                shootTennisBall();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        tennisBall = other.gameObject;
    }

    public void shootTennisBall() {
        Vector3 direction = directionVector.position - transform.position;
        Rigidbody rb = tennisBall.GetComponent<Rigidbody>();
        rb.AddForce(direction * 500);
        tennisBall = null;
    }
}
