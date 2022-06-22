using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputController : InputController
{

    Vector2Int screen;      // screen width & height
    float mousePositionOnRotateStart;

    // Events  >> these have the same names as the delegates 
    public static event MoveInputHandler onMoveInput;
    public static event RotateInputHandler onRotateInput;
    public static event ZoomInputHandler onZoomInput;
    

    private void Awake()
    {
        screen = new Vector2Int(Screen.width, Screen.height);

    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // check mouse position is valid 

        bool mouseValid =
            mousePos.y <= screen.y * 1.05f &&
            mousePos.y >= screen.y * -0.05f &&
            mousePos.x <= screen.x * 1.05f &&
            mousePos.x >= screen.x * -0.0f;

        if (!mouseValid)
        {
            return;
        }

        //movement 
        if (mousePos.y > screen.y * 0.85f)
        {
            onMoveInput?.Invoke(Vector3.forward);       // ?.Invoke means that only invoke the event if onMoveInput is not null 
        }
        else if (mousePos.y < screen.y * 0.15f)
        {
            onMoveInput?.Invoke(-Vector3.forward);
        }
        if (mousePos.x > screen.x * 0.85f)
        {
            onMoveInput?.Invoke(Vector3.right);
        }
        else if (mousePos.x < screen.x * 0.15f)
        {
            onMoveInput?.Invoke(-Vector3.right);
        }


        // rotation 
        if (Input.GetMouseButtonDown(1))
        {
            mousePositionOnRotateStart = mousePos.x;
        }
        else if (Input.GetMouseButton(1))
        {
            if (mousePos.x < mousePositionOnRotateStart)
            {
                onRotateInput?.Invoke(-1f);

            }
            else if (mousePos.x > mousePositionOnRotateStart)
            {
                onRotateInput.Invoke(1f);

            }
        }


        // zoom
        if (Input.mouseScrollDelta.y > 0)
        {
            onZoomInput?.Invoke(-30f);           // mouse wheels can be not very sensitivity


        } else if ( Input.mouseScrollDelta.y < 0 )
        {
            onZoomInput?.Invoke(30f);

        }

    }


}
