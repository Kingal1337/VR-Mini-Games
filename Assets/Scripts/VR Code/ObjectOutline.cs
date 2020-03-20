using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectOutline : MonoBehaviour { 

    public void AddOutline(XRBaseInteractable xr) {
        Renderer renderer = xr.gameObject.GetComponent<Renderer>();
        if (renderer != null) {
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_On", 1f);
            }
        }
    }

    public void RemoveOutline(XRBaseInteractable xr) {
        Renderer renderer = xr.gameObject.GetComponent<Renderer>();
        if (renderer != null) {
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_On", 0f);
            }
        }
    }
}
