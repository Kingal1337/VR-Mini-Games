using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectOutline : MonoBehaviour
{
    private Shader shader;

    public Color outlineColor;

    [Range(0,1)]
    public float outlineWidth;

    public void Start() {
        shader = Shader.Find("Outlined/Custom");
        ApplyShader();
    }

    public void ApplyShader() {
        if (shader != null) {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].shader = shader;
                mats[i].SetColor("_OutlineColor", outlineColor);
                mats[i].SetFloat("_Outline", 0f);
            }
        }
    }

    public void AddOutline(XRBaseInteractable xr) {
        Renderer renderer = xr.gameObject.GetComponent<Renderer>();
        if (renderer != null) {
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_Outline", outlineWidth);
            }
        }
    }

    public void RemoveOutline(XRBaseInteractable xr) {
        Renderer renderer = xr.gameObject.GetComponent<Renderer>();
        if (renderer != null) {
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_Outline", 0f);
            }
        }
    }
}
