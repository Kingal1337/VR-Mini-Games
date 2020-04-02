using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionByCollider : MonoBehaviour
{
    public Collider collider1;
    public Collider collider2;
    // Start is called before the first frame update
    void Start() {
        Physics.IgnoreCollision(collider1, collider2);
    }
}
