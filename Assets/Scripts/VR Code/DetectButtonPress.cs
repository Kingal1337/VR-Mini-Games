using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectButtonPress : MonoBehaviour
{

    public enum Controller {
        Left, Right
    }

    private InputDevice selected;
    private InputDevice leftController;
    private InputDevice rightController;

    [Tooltip("The controller")]
    public Controller controller;

    [Tooltip("The selected button you want to get triggered")]
    public InputHelpers.Button button;

    [Tooltip("Called when the user presses down on the selected button")]
    public UnityEvent pressed;

    [Tooltip("Called when the user releases on the selected button")]
    public UnityEvent lifted;

    private bool isBeingPressed;

    void Awake() {
        InputDevices.deviceConnected += RegisterDevices;
        Init();
    }


    void OnEnable() {
        InputDevices.deviceConnected += RegisterDevices;
        Init();
    }

    void OnDisable() {
        InputDevices.deviceConnected -= RegisterDevices;
        Init();
    }

    void Start() {
        Init();
    }

    void Init() {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        for (int i = 0; i < devices.Count; i++) {
            RegisterDevices(devices[i]);
        }

        if (controller == Controller.Left) {
            selected = leftController;
        }
        if (controller == Controller.Right) {
            selected = rightController;
        }
    }

    void RegisterDevices(InputDevice device) {
        print("Registering; 1");
        if (device.isValid) {
            print("Registering; 2");
#if UNITY_2019_3_OR_NEWER
            if((device.characteristics & InputDeviceCharacteristics.Left) != 0)
#else
            if (device.role == InputDeviceRole.LeftHanded)
#endif
            {
                print("Registering; 3");
                leftController = device;
            }
#if UNITY_2019_3_OR_NEWER
            else if ((device.characteristics & InputDeviceCharacteristics.Right) != 0)
#else
            else if (device.role == InputDeviceRole.RightHanded)
#endif
            {
                print("Registering; 4");
                rightController = device;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
        if (selected.isValid) {
            bool pressedCheck;
            selected.IsPressed(button, out pressedCheck);

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
