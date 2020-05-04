using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
   [Tooltip ("Number of points that will be earned")]
    [Range (1f,25f)]public int points;
    //ensures that changes made on score remain as intended
    static int scoreTracker=0;
    
    private void OnTriggerEnter(Collider other)
    {
        //adds points after scored
        if(other.gameObject.tag=="ball")
        {
            scoreTracker += points;
            GameManager.gm.score.text = scoreTracker.ToString();
        }
        
    }
    
}
