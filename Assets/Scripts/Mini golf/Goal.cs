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

    public TextMesh courseScore;       //Set the scoreboard up for this course.//
    public TextMesh courseMaxHits;     //////////////////////////////////////////
    public TextMesh coursePlayerHits;  //////////////////////////////////////////
    
    private Vector3 ballOriginalPosition; //Set the golf ball's original position.

    public int courseScoreAmount;      //Used to set and adjust individual course values in the editor.// 
    public int courseMaxHitsAmount;    ////////////////////////////////////////////////////////////////// 
    public int coursePlayerHitsAmount; //////////////////////////////////////////////////////////////////

    public float flagSpeed;               //The speed at which the flag moves.  
    public int maxFlagHeight;             //The maximum height the flag can move to on the Y axis.
    private bool moveFlag = false;        //Flag will NOT move by default.  
    private Vector3 flagOriginalPosition; //Save the flag's original position. 

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
        if (collider.gameObject.tag == "Club") { //On collision with golf ball...
            print("REACHED GOLF BALL COLLISION");

            //Increase the player hits and reflect the change on the board.  
            coursePlayerHitsAmount += 1; 
            coursePlayerHits.text = coursePlayerHitsAmount.ToString();

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
Golf Ball Vector3 Positions: 
- Golf Ball 1 = -9.387, -1.906, 7.865
- Golf Ball 2 = -9.384852, -0.554, 6.418101
- Golf Ball 3 = 2.6508, -0.07967913, 4.179
*/
