using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTirgger : MonoBehaviour
{
    //Controls glowing effect on skii ball animation scene
    [SerializeField] private Animator animationController;
    private void OnTriggerEnter(Collider other)
    {
        //plays an animation on trigger
        if (other.CompareTag("Player")) 
        {
            animationController.SetBool("StopLightFlahsing", true);
        }
        GameManager.gm.ballRespawning.Play();
        //defualt view after game is started
        GameManager.gm.scoreObject.SetActive(true);
        //GameManager.gm.playObject.SetActive(false);
        GameManager.gm.TimeObject.SetActive(true);
        GameManager.gm.isGameActive=true;
        //ensures sound sync
        Invoke("TeleportBall", 1f);
        
    }
    private void OnTriggerExit(Collider other)
    {
        //plays an animation on trigger
       if (other.CompareTag("Player"))
        {
            animationController.SetBool("StopLightFlahsing", false);
        }
        //default view after game has ended
        GameManager.gm.scoreObject.SetActive(false);
        GameManager.gm.TimeObject.SetActive(false);
        //GameManager.gm.playObject.SetActive(true);
        GameManager.gm.score.text = "0";
        GameManager.gm.isGameActive = false;
        Destroy(GameManager.gm.clone,.1f);
       
    }
    void TeleportBall()
    {
        GameManager.gm.clone = Instantiate(GameManager.gm.skiiBall, GameManager.gm.teleportTransformLocation.position, GameManager.gm.teleportTransformLocation.rotation);
    }
}
