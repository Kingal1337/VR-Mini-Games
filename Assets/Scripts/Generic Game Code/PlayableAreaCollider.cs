using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAreaCollider : MonoBehaviour
{
    public PlayableArea playArea;

    private void OnTriggerEnter(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (playArea.IsMyObject(playObject) && !playObject.currentlyIn.Contains(this)) {
                playObject.currentlyIn.Add(this);
                playArea.CheckAllColliders();
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        PlayObject playObject = collider.gameObject.GetComponent<PlayObject>();
        if (playObject != null) {
            if (playArea.IsMyObject(playObject) && playObject.currentlyIn.Contains(this)) {
                playObject.currentlyIn.Remove(this);
                playArea.CheckAllColliders();
            }
        }
    }
}
