using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ButtonCode : MonoBehaviour
{
    [Tooltip("This will be called when the button is pressed")]
    public UnityEvent buttonPressed;

    [Tooltip("This will be called when the button is released")]
    public UnityEvent buttonReleased;

    [Tooltip("This will be called only once, and will be called again when the boolean calledButtonPressed has been set to false.  Useful for changing scenes")]
    public UnityEvent oneButtonPress;

    [Tooltip("How far down the button needs to be pushed before being declared pressed")]
    public float detectionLength = .02f;

    private Vector3 originPosition;

    private bool pressed;

    [Tooltip("This is used with the oneButtonPress UnityEvent, and if this is true, that means the oneButtonPress UnityEvent has already been invoked and to be able to reinvoke it, set this value to false")]
    public bool calledButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < originPosition.y - detectionLength) {
            if (!pressed) {
                buttonPressed.Invoke();
                if (!calledButtonPressed) {
                    calledButtonPressed = true;
                    oneButtonPress.Invoke();
                }
                pressed = true;
            }
        }
        else {
            if (pressed) {
                buttonReleased.Invoke();
                pressed = false;
            }
        }
    }

    public void ChangeColorGreen() {
        Renderer render = GetComponent<Renderer>();
        render.material.SetColor("_BaseColor", Color.green);
    }

    public void ChangeColorRed() {
        Renderer render = GetComponent<Renderer>();
        render.material.SetColor("_BaseColor", Color.red);
    }
}
