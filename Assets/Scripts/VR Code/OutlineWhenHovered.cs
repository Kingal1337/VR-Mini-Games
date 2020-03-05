using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineWhenHovered : MonoBehaviour {

    void Start() {

    }

    public void addOutline(XRBaseInteractable xr) {
        Material[] mats = xr.gameObject.GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length; i++) {
            mats[i].SetFloat("_Outline", .1f);
        }
    }

    public void removeOutline(XRBaseInteractable xr) {
        Material[] mats = xr.gameObject.GetComponent<Renderer>().materials;
        for (int i = 0; i < mats.Length; i++) {
            mats[i].SetFloat("_Outline", 0f);
        }
    }
}
