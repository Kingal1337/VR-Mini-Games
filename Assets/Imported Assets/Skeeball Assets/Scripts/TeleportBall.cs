using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.gm.thump.Play();
        GameManager.gm.ballRespawning.Play();
        //get rid of skii balls
        Destroy(GameManager.gm.clone, .5f);
        //delay for sound sync
        Invoke("Teleport", 1f);
    }
    void Teleport()
    {
        //spawn in skii balls
        GameManager.gm.clone = Instantiate(GameManager.gm.skiiBall, GameManager.gm.teleportTransformLocation.position, GameManager.gm.teleportTransformLocation.rotation);
    }
}
