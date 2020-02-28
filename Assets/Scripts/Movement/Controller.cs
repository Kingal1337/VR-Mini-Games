using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Movable movable;
    public Controls controls;
    // Start is called before the first frame update
    void Start() {
        movable = GetComponent<Movable>();
        controls = GetComponent<Controls>();
    }

    // Update is called once per frame
    void Update() {
        if (controls != null) {
            if (Input.GetKeyDown(controls.forward)) {
                movable.forward = true;
            }
            if (Input.GetKeyDown(controls.left)) {
                movable.left = true;
            }
            if (Input.GetKeyDown(controls.backward)) {
                movable.backward = true;
            }
            if (Input.GetKeyDown(controls.right)) {
                movable.right = true;
            }
            if (Input.GetKeyDown(controls.jump)) {
                movable.jumping = true;
            }
            if (Input.GetKeyDown(controls.sprint)) {
                movable.sprinting = true;
            }

            if (Input.GetKeyUp(controls.forward)) {
                movable.forward = false;
            }
            if (Input.GetKeyUp(controls.left)) {
                movable.left = false;
            }
            if (Input.GetKeyUp(controls.backward)) {
                movable.backward = false;
            }
            if (Input.GetKeyUp(controls.right)) {
                movable.right = false;
            }
            if (Input.GetKeyUp(controls.jump)) {
                movable.jumping = false;
            }
            if (Input.GetKeyUp(controls.sprint)) {
                movable.sprinting = false;
            }
        }
    }
}
