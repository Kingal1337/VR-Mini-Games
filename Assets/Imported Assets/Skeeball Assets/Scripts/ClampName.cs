using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{
    //define a state of our choice
   public enum textObject {Score, Play, Time, GameOver}
[Tooltip("Chose text to change position for")]
   public textObject textState;
 
  
    void Update()
    {
        //(***make sure camera is tagged main***) gets position of object relative to the camera's view
        //Vector3 namepos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Vector3 heading = GameManager.gm.teleportTransformLocation.position - Camera.main.transform.position;
       

        //test if the object taged is in FOV (fixed bug where text would appear even when behind the camera
        //if (Vector3.Dot(Camera.main.transform.forward, heading) > 0)
        //{
        //    //actual execution of code
        //    switch (textState)
        //    {
        //    case textObject.Play:
        //    {
        //            //GameManager.gm.playObject.transform.position = namepos;
        //            return;
        //    }
        //    case textObject.Score:
        //        {
        //            GameManager.gm.score.transform.position = namepos;
        //            return;
        //        }
        //    case textObject.Time:
        //        {
        //            GameManager.gm.time.transform.position = namepos;
        //            return;
        //        }
        //    case textObject.GameOver:
        //        {
        //            //GameManager.gm.gameOverObject.transform.position = namepos;
        //            return;
        //        }
        //    }
        //}
    }
        
}

