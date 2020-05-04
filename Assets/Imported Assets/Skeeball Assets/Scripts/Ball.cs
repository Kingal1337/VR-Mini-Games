using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range (11000f,14500f)] [SerializeField] float Speed;
    Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //sets random speed of skii ball
        if(GameManager.gm.randomSkiiballSpeeds)
        Speed = Random.Range(11000f, 14500f);
    }
    void Update()
    {
        //allows for movement in the z axis only
         Vector3 movement = new Vector3(0, 0, 1*Speed*Time.deltaTime);
        //*****Temporary Keyboard Read*****
        if(Input.GetKeyDown(KeyCode.Space))
        {

            //rigidbody.MovePosition(transform.position + movement); (obsolete method)
            GameManager.gm.ballRolling.Play();
            rigidbody.AddForce(0,0,10*Speed*Time.deltaTime);
            
        }
    }
}
