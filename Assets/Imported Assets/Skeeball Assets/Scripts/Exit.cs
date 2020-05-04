using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Close everything open in Scene
        GameManager.gm.arcadeSounds.Stop();
        GameManager.gm.music.Stop();
    }
}
