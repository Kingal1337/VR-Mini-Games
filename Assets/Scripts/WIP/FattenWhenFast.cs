using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Makes the collider bigger on one axis as the velocity increases
 * and when the velocity decreases the collider will go back to normal
 */
public class FattenWhenFast : MonoBehaviour
{
    public enum Axis {
        X_Axis, Y_Axis, Z_Axis
    }

    [Tooltip("Rigidbody of the object, to determine speed")]
    public Rigidbody rigidBody;

    [Tooltip("THe box collider to resize")]
    public BoxCollider boxCollider;

    [Tooltip("Which axis the collider will increase")]
    public Axis axis;

    [Tooltip("As the speed increases, the size will increase based on this curve")]
    public AnimationCurve sizeCurve;

    [Tooltip("The minimum speed the object needs to go before the object starts resizing")]
    public float minSpeed;

    [Tooltip("The maximum speed the object needs to be before it hits max size")]
    public float maxSpeed;
    
    private float minValueOnCurve;
    private float maxValueOnCurve;

    //normal size is the minimum value on the curve
    private bool isNormalSize;

    // Update is called once per frame
    void Update()
    {
        if (sizeCurve.length != 0 && sizeCurve.length != 1) {
            Keyframe firstFrame = sizeCurve.keys[0];
            Keyframe lastFrame = sizeCurve.keys[sizeCurve.length-1];

            if ((firstFrame.time != minValueOnCurve || lastFrame.time != maxValueOnCurve)) {
                minValueOnCurve = firstFrame.time;
                maxValueOnCurve = lastFrame.time;
            }
        }

        float speed = rigidBody.velocity.magnitude;
        if (speed >= minSpeed && speed <= maxSpeed) {
            isNormalSize = false;
            float time = map(minSpeed, maxSpeed, minValueOnCurve, maxValueOnCurve, speed);
            float sizeToResizeBy = sizeCurve.Evaluate(time);

            Vector3 colliderSize = boxCollider.size;
            boxCollider.size = new Vector3(
                    axis == Axis.X_Axis ? sizeToResizeBy : colliderSize.x,
                    axis == Axis.Y_Axis ? sizeToResizeBy : colliderSize.y,
                    axis == Axis.Z_Axis ? sizeToResizeBy : colliderSize.z
                );
        }
        if (speed < minSpeed && !isNormalSize) {
            isNormalSize = true;
            float sizeToResizeBy = sizeCurve.Evaluate(0);

            Vector3 colliderSize = boxCollider.size;
            boxCollider.size = new Vector3(
                    axis == Axis.X_Axis ? sizeToResizeBy : colliderSize.x,
                    axis == Axis.Y_Axis ? sizeToResizeBy : colliderSize.y,
                    axis == Axis.Z_Axis ? sizeToResizeBy : colliderSize.z
                );
        }
    }

    /**
     * Maps one range onto another range
     */
    public float map(float from1, float from2, float to1, float to2, float value) {

        float oldRange = (from2 - from1);
        float newRange = (to2 - to1);
        float newValue = (((value - from1) * newRange) / oldRange) + to1;

        return newValue;
    }
}

