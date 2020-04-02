using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    public enum Type {
        Local, World
    }

    public enum Axis {
        X, Y, Z
    }

    public Type type;//local or world position
    public Axis axis;//which axis to clamp

    public float minClamp;//Relative
    public float maxClamp;//Relative

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpPos = transform.localPosition;
        if (type == Type.Local) {
            tmpPos = transform.localPosition;
        }
        if (type == Type.World) {
            tmpPos = transform.position;
        }

        if (axis == Axis.X) {
            //tmpPos.x = Mathf.Clamp(tmpPos.x, tmpPos.x , tmpPos.x + maxClamp);
            tmpPos.x = Mathf.Clamp(tmpPos.x, minClamp, maxClamp);
        }
        if (axis == Axis.Y) {
            tmpPos.y = Mathf.Clamp(tmpPos.y, minClamp, maxClamp);
            //tmpPos.y = Mathf.Clamp(tmpPos.y, tmpPos.y, tmpPos.y + maxClamp);
        }
        if (axis == Axis.Z) {
            //tmpPos.z = Mathf.Clamp(tmpPos.z, tmpPos.z , tmpPos.z + maxClamp);
            tmpPos.z = Mathf.Clamp(tmpPos.z, minClamp, maxClamp);
        }

        transform.position = tmpPos;
        if (type == Type.Local) {
            transform.localPosition = tmpPos;
        }
        if (type == Type.World) {
            transform.position = tmpPos;
        }
    }
}
