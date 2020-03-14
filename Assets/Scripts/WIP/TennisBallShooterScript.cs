using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallShooterScript : MonoBehaviour {
    private float currentTimeToShoot;//the time until the ball will shoot;

    private float timeToReload = 2f;//the time to wait before reloading
    private float currentTimeToReload;//the time until the ball will get reloaded after the ball is shot

    private GameObject tennisBall;//Tennis ball that is about to be fired

    public bool isOn;
    public float timeTillShoot = 5;//in seconds

    public float force = 1000f;

    public PlayableArea playArea;

    public Transform tennisBallOrigin;//where the tennis will shoot from
    public Transform directionVector;//the direction the tennis ball will travel



    // Start is called before the first frame update
    void Start() {
        ReloadTennisBall();
    }

    // Update is called once per frame
    void Update() {
        if (isOn) {
            if (tennisBall == null) {
                if (HasBalls()) {
                    currentTimeToReload += Time.deltaTime;
                }
                if (currentTimeToReload >= timeToReload) {
                    currentTimeToReload = 0;
                    ReloadTennisBall();
                }
            }
            else {
                currentTimeToShoot += Time.deltaTime;
                if (currentTimeToShoot >= timeTillShoot) {
                    currentTimeToShoot = 0;
                    ShootTennisBall();
                }
            }
        }
    }

    private bool HasBalls() {//Checks if the tennis shooter has any tennis balls left
        List<PlayObject> allTennisBalls = playArea.ObjectsInBounds;
        return allTennisBalls.Count != 0;
    }

    private void ShootTennisBall() {
        if (tennisBall != null) {
            Vector3 direction = directionVector.position - tennisBallOrigin.position;
            Rigidbody rb = tennisBall.GetComponent<Rigidbody>();
            rb.AddForce(direction.normalized * force);
            tennisBall = null;
        }
    }

    private void ReloadTennisBall() {
        if (tennisBall == null) {
            List<PlayObject> allTennisBalls = playArea.ObjectsInBounds;
            if (HasBalls()) {
                currentTimeToShoot = 0;
                tennisBall = allTennisBalls[0].gameObject;
                tennisBall.transform.position = tennisBallOrigin.position;
            }
        }
    }
}
