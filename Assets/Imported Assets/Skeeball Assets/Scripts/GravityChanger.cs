using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public void NormalGravity() {
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    public void GravityScaledUp() {//Used for Skeeball
        Physics.gravity = new Vector3(0, -29.43f, 0);
    }
}
