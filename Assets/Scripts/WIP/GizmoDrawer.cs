using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gizmos = Popcron.Gizmos;

public class GizmoDrawer : MonoBehaviour
{

    public BoxCollider box;

    // Start is called before the first frame update
    void Start()
    {
        Gizmos.Enabled = true;
    }

    private void OnRenderObject() {
        Vector3 newBox = new Vector3(box.size.x * transform.lossyScale.x, box.size.y * transform.lossyScale.y, box.size.z * transform.lossyScale.z);
        Gizmos.Cube(box.bounds.center, transform.rotation, newBox);
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
