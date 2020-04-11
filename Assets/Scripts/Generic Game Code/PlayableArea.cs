using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Should be placed on the Play Area Collider;
 */
public class PlayableArea : MonoBehaviour {

    [Tooltip("All the objects that are used to play the game.")]
    public List<PlayObject> objects = new List<PlayObject>();

    [Tooltip("Instead of dragging play objects 1 at a time, you can drag the parent of all the PlayObjects")]
    public GameObject parentOfAllPlayObjects;

    private List<PlayObject> objectsInBounds = new List<PlayObject>();
    public List<PlayObject> ObjectsInBounds { 
        get { 
            return objectsInBounds; 
        }
    }

    [Tooltip("If set to true, the PlayObject will return to the closest teleport location")]
    public bool returnToClosestTeleportLocation;

    [Tooltip("The time objects can stay outside of the Play Area before they are teleported back to the playarea. (In Seconds)")]
    public float outOfBoundsTime = 2f;

    [Tooltip("Where the objects will teleport to if they are out of bounds")]
    public List<Transform> teleportLocationList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in parentOfAllPlayObjects.transform) {
            GameObject gameObject = child.gameObject;
            PlayObject playObject = gameObject.GetComponent<PlayObject>();
            if (playObject != null && playObject.gameObject.activeSelf) {
                if (!objects.Contains(playObject)) {
                    objects.Add(playObject);
                    updateObjectInBounds(playObject);
                }
            }
        }
    }

    public void updateObjectInBounds(PlayObject playObject) {
        if (!playObject.OutOfBounds) {
            if (!objectsInBounds.Contains(playObject)) { 
                objectsInBounds.Add(playObject);
            }
        }
        else {
            objectsInBounds.Remove(playObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (objects.Contains(playObject)) {
                playObject.OutOfBounds = false;
                playObject.timeOutOfBounds = 0;
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (objects.Contains(playObject)) {
                playObject.OutOfBounds = true;
            }
        }
    }

    public void teleportPlayObject(PlayObject playObject) {
        if (objects.Contains(playObject)) {
            if (returnToClosestTeleportLocation) {
                Transform closest = teleportLocationList[0];
                float distance = Vector3.Distance(playObject.transform.position, closest.position);
                foreach (Transform location in teleportLocationList) {
                    float tempDistance;
                    if ((tempDistance  = Vector3.Distance(playObject.transform.position, location.position)) < distance) {
                        closest = location;
                        distance = tempDistance;
                    }
                }
                playObject.transform.position = closest.position;
            }
            else {
                playObject.transform.position = teleportLocationList[0].position;
            }
            
        }
    }
}
