using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Interactable Object"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
