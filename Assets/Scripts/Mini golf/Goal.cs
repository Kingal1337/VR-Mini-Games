/*
//Set on each course's golf ball.  
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio; 
using UnityEngine;

public class Goal : MonoBehaviour {
    public GameObject GolfBall;   //Set the golf ball for this course.  
    public GameObject CourseFlag; //Set the flag for this course.  

    public TextMesh courseScore;      //Set the scoreboard up for this course.//
    public TextMesh courseMaxHits;    //////////////////////////////////////////
    public TextMesh coursePlayerHits; //////////////////////////////////////////
    
    private Vector3 ballOriginalPosition; //Set the golf ball's original position.

    public int courseScoreAmount;      //Used to set and adjust individual course values in the editor.// 
    public int courseMaxHitsAmount;    ////////////////////////////////////////////////////////////////// 
    public float coursePlayerHitsAmount; //////////////////////////////////////////////////////////////////

    public float flagSpeed;               //The speed at which the flag moves.  
    public int maxFlagHeight;             //The maximum height the flag can move to on the Y axis.
    private bool moveFlag = false;        //Flag will NOT move by default.  
    private Vector3 flagOriginalPosition; //Save the flag's original position. 

    private bool canHit = true;    //Use to check if the ball has been hit by the club.//  
    private float hitTimer = 3;    //Counter to hold when the ball can be hit again.///// OTHER OPTIONS ARE .125, .25, 1, AND 3 

    void Start() {
        courseScore.text = courseScoreAmount.ToString();           //Set the text on the scoreboard.// 
        courseMaxHits.text = courseMaxHitsAmount.ToString();       ///////////////////////////////////
        coursePlayerHits.text = coursePlayerHitsAmount.ToString(); ///////////////////////////////////

        //Get flag location and save in global variable.  Flag will move back to this position after it reaches a certain height.  
        flagOriginalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); 

        //Get the location for the course's ball and save it here.  Ball will move back to this positon after a point is scored.  
        ballOriginalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); 
    }

    void Update() { 
        if (canHit == false) { //If the player hit the ball... 
            hitTimer -= Time.deltaTime; //... Run the timer.  

            if (hitTimer < 0) { //If the timer is below 0...
                hitTimer = 3;   //... Reset the timer... 
                canHit = true;  //... Then stop the timer, and allow the ball to be hit again.   
            }
        }

        flagMovement(); 
    } 

    //If this object collides with the golf hole then do the following... 
    void OnTriggerEnter(Collider collider) { 
        if (collider.gameObject.tag == "Goal") { //On collision with the goal... 

            moveFlag = true;  

            GolfBall.transform.position = ballOriginalPosition; //Move ball back to its original position.  
        }
    }

    //Check if the golf club hits the ball.  
    void OnCollisionEnter(Collision collider) { 
        if (collider.gameObject.tag == "Club" && canHit == true) { //On collision with golf ball...

            canHit = false; //Start the timer.  Stop accepting hits.  

            coursePlayerHitsAmount += 1;

            coursePlayerHits.text = coursePlayerHitsAmount.ToString(); //Once the math is done change the score.  

            keepScore(); 
        }
    }

    void flagMovement() {
        if (moveFlag == true) { 
            CourseFlag.transform.Translate(0, Time.deltaTime * flagSpeed, 0); //Move flag up.  

            if (CourseFlag.transform.position.y > 100) { //If the flag is higher than 25 units... 
                moveFlag = false; //Stop the flag from moving.
            }
        }
    }

    //Takes the player's hits and the course's max hits and derives a score.  
    void keepScore() {      
        if (coursePlayerHitsAmount > courseMaxHitsAmount) { //If player hits is greater than max hits.  
            courseScoreAmount -= 10; //Subtract 10 from the scoreboard.  

            courseScore.text = courseScoreAmount.ToString(); //Display new score value.  
        }
    }
}

/* 
https://answers.unity.com/questions/897505/preventing-multiple-collisions-on-same-target.html

https://forum.unity.com/threads/solved-detecting-a-constant-collision-over-x-amount-of-seconds.424701/ <- USING THIS ONE 
*/ 

//Collision timer in update 
//Start the collision timer when player enters 
//Check if the player is still at location, if they are increase 
//If the player is not colliding reset our timer 
