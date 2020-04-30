using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisHit : MonoBehaviour
{

    public TennisGameManager gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Tennis Ball") {
            AudioSource source = GetComponent<AudioSource>();
            gm.PlaySound(source, TennisGameManager.Sound.Ball_Hit);
        }
    }
}
