using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigMoveable : MonoBehaviour
{
    private Transform rotationOfCam;

    public float speed = 5f;

    public Camera camera;//needed for rotation
    public XRController controller;//which controller that is able to move the XRRig

    public static bool AlmostEquals(float float1, float float2, float precision) {
        return (Math.Abs(float1 - float2) <= precision);
    }

    void Start() {
        rotationOfCam = new GameObject().transform;//Creates an empty transform to keep track of transform.forward
    }

    void FixedUpdate() {        
        rotationOfCam.eulerAngles = new Vector3(rotationOfCam.eulerAngles.x, camera.transform.eulerAngles.y, rotationOfCam.eulerAngles.z) - transform.eulerAngles; 

        if (controller != null) {
            InputFeatureUsage<Vector2> feature = CommonUsages.primary2DAxis;
            if (controller.enableInputActions) {
                InputDevice device = controller.inputDevice;
                Vector2 currentState;
                if (device.TryGetFeatureValue(feature, out currentState)) {
                    float rawX = currentState.x;
                    float rawY = currentState.y;

                    float xSpeed = AlmostEquals(rawX, 0, .0001f) ? 0 : rawX;
                    float ySpeed = AlmostEquals(rawY, 0, .0001f) ? 0 : rawY;

                    Move(currentState.x, currentState.y);
                }
            }
        }
    }

    private void Move(float x, float z) {
        Vector3 moveVector = rotationOfCam.right * x + rotationOfCam.forward * z;
        moveVector = moveVector * speed * Time.deltaTime;
        transform.Translate(moveVector);
    }
}
