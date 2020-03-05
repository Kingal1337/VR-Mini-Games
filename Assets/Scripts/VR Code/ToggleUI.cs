using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject canvas;

    public void Toggle() {
        canvas.SetActive(!canvas.activeSelf);
    }
}
