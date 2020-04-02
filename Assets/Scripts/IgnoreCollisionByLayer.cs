using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionByLayer : MonoBehaviour
{
    //private Rigidbody rb;

    public string layer1Name;
    public string layer2Name;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer(layer1Name), LayerMask.NameToLayer(layer2Name));
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
