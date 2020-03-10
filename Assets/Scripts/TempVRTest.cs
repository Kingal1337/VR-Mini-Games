using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TempVRTest : MonoBehaviour
{
    public void addOutline(XRBaseInteractable xr) {
        if (xr.gameObject.GetComponent<Renderer>() != null) {
            Material[] mats = xr.gameObject.GetComponent<Renderer>().materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_Outline", .1f);
            }
        }
    }
    
    public void removeOutline(XRBaseInteractable xr) {
        if (xr.gameObject.GetComponent<Renderer>() != null) {
            Material[] mats = xr.gameObject.GetComponent<Renderer>().materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_Outline", 0f);
            }
        }
    }

    public void printObjectHover(XRBaseInteractable xr) {
        print(xr.gameObject.name);
    }
}
