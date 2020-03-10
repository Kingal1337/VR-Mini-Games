using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectButtonPress : MonoBehaviour
{

    [Tooltip("The controller")]
    public XRController controller;

    [Tooltip("The selected button you want to get triggered")]
    public InputHelpers.Button button;

    [Tooltip("Called when the user presses down on the selected button")]
    public UnityEvent pressed;

    [Tooltip("Called when the user releases on the selected button")]
    public UnityEvent lifted;

    private bool isBeingPressed;

    // Update is called once per frame
    void Update() {
        
        if (controller != null && controller.enableInputActions) {
            bool pressedCheck;
            InputDevice device = controller.inputDevice;
            device.IsPressed(button, out pressedCheck);

            if (pressedCheck) {
                if (!isBeingPressed) {
                    isBeingPressed = true;
                    pressed.Invoke();
                }
            }
            else {
                if (isBeingPressed) {
                    isBeingPressed = false;
                    lifted.Invoke();
                }
            }
        }
    }
}
