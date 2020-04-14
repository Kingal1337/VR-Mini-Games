using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject GolfBall;
    public GameObject CourseFlag; 
    public float flagSpeed = 0f; //Set in editor.  
    private bool moveFlag = false;
    //Add game manager.  
    
    // Start is called before the first frame update
     void Start() {} 

    // Update is called once per frame
    void Update() {
        if (moveFlag == true) {
            CourseFlag.transform.Translate(0, Time.deltaTime * flagSpeed, 0); 
        }
    } 

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject == GolfBall) {
            Debug.Log("It works.");
            moveFlag = true;  

            //Call GameManager and increase its score by 1 
        }
    }
}
