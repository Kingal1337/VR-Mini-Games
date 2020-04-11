using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObject : MonoBehaviour
{
    public PlayableArea playArea;
    
    [Tooltip("If set to true, the velocity of the object will be reset, before the object will teleport")]
    public bool resetVelocity = true;
    
    [Tooltip("If the object is out of bounds or not")]
    private bool outOfBounds;
    public bool OutOfBounds {
        get { return outOfBounds; }
        set { 
            outOfBounds = value;
            if (playArea != null) {
                playArea.updateObjectInBounds(this);
            }
        }
    }

    [Tooltip("How the the object has been out of bounds")]
    public float timeOutOfBounds = 0;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (outOfBounds) {
            timeOutOfBounds += Time.deltaTime;
            if (timeOutOfBounds >= playArea.outOfBoundsTime) {
                timeOutOfBounds = 0;
                playArea.teleportPlayObject(this);
                if (rigidbody != null) {
                    rigidbody.velocity = Vector3.zero;
                    rigidbody.angularVelocity = Vector3.zero;
                }
            }
        }
    }
}
