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

    private List<PlayObject> objectsOutOfBounds = new List<PlayObject>();

    [Tooltip("The time objects can stay outside of the Play Area before they are teleported back to the playarea. (In Seconds)")]
    public float outOfBoundsTime = 2f;//should be 10 seconds

    [Tooltip("Where the objects will teleport to if they are out of bounds")]
    public Transform teleportLocation;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in parentOfAllPlayObjects.transform) {
            GameObject gameObject = child.gameObject;
            PlayObject component = gameObject.GetComponent<PlayObject>();
            if (component != null) {
                if (!objects.Contains(component)) {
                    objects.Add(component);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (objects.Contains(playObject)) {
                playObject.outOfBounds = false;
                playObject.timeOutOfBounds = 0;
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (objects.Contains(playObject)) {
                playObject.outOfBounds = true;
            }
        }
    }

    public void teleportPlayObject(PlayObject playObject) {
        if (objects.Contains(playObject)) {
            playObject.transform.position = teleportLocation.position;
        }
    }
}
