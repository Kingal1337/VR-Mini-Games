using UnityEngine;

/**
 * There should only be one instance of the class, (Should be placed in a game manager)
 *      EXCEPT:
 *          -when their are multiple players on the same machine
 *          -for testing
 *  
 * For now just create new instances for testing
 */
public class Controls : MonoBehaviour {
    //Default controls 
    public static readonly KeyCode MOVE_FORWARD = KeyCode.W;
    public static readonly KeyCode MOVE_BACKWARD = KeyCode.S;
    public static readonly KeyCode MOVE_LEFT = KeyCode.A;
    public static readonly KeyCode MOVE_RIGHT = KeyCode.D;
    public static readonly KeyCode SPRINT = KeyCode.LeftShift;

    public static readonly KeyCode JUMP = KeyCode.Space;

    public static readonly KeyCode TOGGLE_INVENTORY = KeyCode.E;

    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode sprint;

    public KeyCode jump;

    public KeyCode inventory;

    public Controls() {//Default constructor to create default key binds
        this.forward = MOVE_FORWARD;
        this.backward = MOVE_BACKWARD;
        this.left = MOVE_LEFT;
        this.right = MOVE_RIGHT;
        this.sprint = SPRINT;

        this.jump = JUMP;

        this.inventory = TOGGLE_INVENTORY;
    }

    public Controls(KeyCode forward, KeyCode backward, KeyCode left, KeyCode right, KeyCode sprint, KeyCode jump, KeyCode inventory) {//Custom constructor to create custom key binds
        this.forward = forward;
        this.backward = backward;
        this.left = left;
        this.right = right;
        this.sprint = sprint;

        this.jump = jump;

        this.inventory = inventory;
    }
}
