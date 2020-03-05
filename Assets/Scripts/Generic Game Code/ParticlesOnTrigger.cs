using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnTrigger : MonoBehaviour
{
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider) {
        if (particles != null) {
            particles.Play();
        }
    }

    void OnTriggerExit(Collider collider) {

    }
}
