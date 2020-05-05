using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject objectToSpawn;
    //public GameObject spawner;
    //Vector3 spawnLocation;
    public float x, y, z;
    public float winX, winY, winZ;

    AudioSource audioSource;
    public AudioClip successSound; 

    public ParticleSystem winParticle;

    public GameObject prize;

    public int despawnTime = 5;

    bool isInPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        //spawnLocation = spawner.transform.position;
        audioSource = GetComponent<AudioSource>(); //Adding in AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isInPlay == false)
        {
            return;
        }

        switch (collision.gameObject.tag) {

            case "Despawn":
                Destroy(this.gameObject, 0);
                print("Collided");
                Invoke("SpawnNewBall", 0);
                break;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (isInPlay == false)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "FishBowlCollider":
                isInPlay = false;
                Destroy(this.gameObject, 2);
                audioSource.PlayOneShot(successSound);
                Invoke("SpawnNewBall", 3);
                SpawnPrize();
                winParticle.Play();
                break;

        }
    }

    private void SpawnPrize()
    {
        Instantiate(prize, new UnityEngine.Vector3(winX, winY, winZ), UnityEngine.Quaternion.identity);
        //-12.97f, 1.65f, 9.785f

    }

    private void SpawnNewBall()
    {
        Instantiate(objectToSpawn, new UnityEngine.Vector3(x,y,z), UnityEngine.Quaternion.identity);
        //-12.97f, 1.65f, 9.785f

    }

}
