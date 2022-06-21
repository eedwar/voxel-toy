using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController
{
    // Events
    public static event MoveInputHandler onMoveInput;
    public static event RotateInputHandler onRotateInput;
    public static event ZoomInputHandler onZoomInput;


    // Update is called once per frame
    void Update()
    {
        // move
        if (Input.GetKey(KeyCode.W))
        {
            onMoveInput?.Invoke(Vector3.forward);

        }

        if (Input.GetKey(KeyCode.S))
        {
            onMoveInput?.Invoke(-Vector3.forward);

        }
        if (Input.GetKey(KeyCode.A))
        {
            onMoveInput?.Invoke(-Vector3.right);

        }
        if (Input.GetKey(KeyCode.D))
        {
            onMoveInput?.Invoke(Vector3.right);

        }

        // rotate
        if (Input.GetKey(KeyCode.E))
        {
            onRotateInput?.Invoke( -1f);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            onRotateInput?.Invoke(1f);

        }

        // zoom
        if (Input.GetKey(KeyCode.Z))
        {
            onZoomInput?.Invoke(-1f);

        }
        if (Input.GetKey(KeyCode.X))
        {
            onZoomInput?.Invoke(1f);

        }
    }
}
