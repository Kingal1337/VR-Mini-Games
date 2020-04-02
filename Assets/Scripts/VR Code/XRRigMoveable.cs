using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigMoveable : MonoBehaviour
{
    private Transform rotationOfCam;

    public GameObject theCollider;

    public float speed = 5f;

    public Camera camera;//needed for rotation
    public XRController controller;//which controller that is able to move the XRRig

    void Start() {
        rotationOfCam = new GameObject().transform;//Creates an empty transform to keep track of transform.forward
    }

    void FixedUpdate() {
        rotationOfCam.eulerAngles = new Vector3(rotationOfCam.eulerAngles.x, camera.transform.eulerAngles.y, rotationOfCam.eulerAngles.z) - theCollider.transform.eulerAngles; 

        if (controller != null) {
            InputFeatureUsage<Vector2> feature = CommonUsages.primary2DAxis;
            if (controller.enableInputActions) {
                InputDevice device = controller.inputDevice;
                Vector2 currentState;
                if (device.TryGetFeatureValue(feature, out currentState)) {
                    float rawX = currentState.x;
                    float rawY = currentState.y;

                    float xSpeed = VRUtilities.AlmostEquals(rawX, 0, .0001f) ? 0 : rawX;
                    float ySpeed = VRUtilities.AlmostEquals(rawY, 0, .0001f) ? 0 : rawY;

                    Move(currentState.x, currentState.y);
                }
            }
        }
        if (theCollider != null) {
            Vector3 tempPos = theCollider.transform.position;
            tempPos.x = theCollider.transform.position.x;
            tempPos.y = theCollider.transform.position.y - theCollider.GetComponent<BoxCollider>().size.y/2;
            tempPos.z = theCollider.transform.position.z;
            transform.position = tempPos;
            //transform.position = theCollider.transform.position;
        }
    }

    private void Move(float x, float z) {
        Vector3 moveVector = rotationOfCam.right * x + rotationOfCam.forward * z;
        moveVector = moveVector * speed * Time.deltaTime;
        theCollider.transform.Translate(moveVector);
    }
}
