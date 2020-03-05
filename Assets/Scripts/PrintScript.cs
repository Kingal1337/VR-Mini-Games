using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintScript : MonoBehaviour
{

    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        print("--------------");
        print("XRRig : "+o1.transform.rotation);
        print("Offset : " + o2.transform.rotation);
        print("Cam : " + o3.transform.rotation);
    }
}
