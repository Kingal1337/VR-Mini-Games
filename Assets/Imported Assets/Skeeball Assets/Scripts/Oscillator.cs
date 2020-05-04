using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Tooltip ("Transform based on values")] [SerializeField] Vector3 movementVector=new Vector3(10f,10f,10f);
    [Tooltip ("Speed based on value")] [SerializeField] float period = 2f;
    //movement ranging from 1 and -1
    private float movementFactor;
    

    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //prevents crash if period is 0
        if(period<=Mathf.Epsilon)
        {
            return;
        }
        //cycles are how many times we get 2PI per time
        float cycles = Time.time / period;
        //tau is 2PI 
        const float tau = Mathf.PI * 2f;
        //Creates oscillation movement
        float rawsinWave = Mathf.Sin(cycles * tau);
        //adds .5 so our Sin value is in between 1 and -1 (Previously .5 and -.5)
        movementFactor = rawsinWave / 2f + 0.5f;
        //calculate offset
        Vector3 offset = movementFactor * movementVector;
        //apply transformation of intial position to offset
        transform.position = startingPos + offset;
    }
}
