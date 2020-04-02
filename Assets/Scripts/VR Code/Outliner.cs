using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Outliner : MonoBehaviour {
    public XRBaseInteractor interactor;

    void Awake() {
        interactor.onHoverEnter.AddListener(Entered);
        interactor.onHoverExit.AddListener(Exited);
    }

    void OnDestroy() {
        interactor.onHoverEnter.RemoveListener(Entered);
        interactor.onHoverExit.RemoveListener(Exited);
    }

    private void Entered(XRBaseInteractable interactable) {
        GameObject go = interactable.gameObject;
        ObjectOutline outline = go.GetComponent<ObjectOutline>();
        if (outline != null) {
            outline.AddOutline(interactable);
        }
    }

    private void Exited(XRBaseInteractable interactable) {
        GameObject go = interactable.gameObject;
        ObjectOutline outline = go.GetComponent<ObjectOutline>();
        if (outline != null) {
            outline.RemoveOutline(interactable);
        }
    }
}
