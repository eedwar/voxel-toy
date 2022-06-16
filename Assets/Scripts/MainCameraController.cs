using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Vector3 startPos, startRot;

    float mouseSensitivty = 3.5f;

    float rotY;
    float rotX;

    [SerializeField]
    Transform gameFloorTarget;

    private float distanceFromTarget = 0.0f;

    private Vector3 currRot;
    private Vector3 smoothVelo = Vector3.zero;

    private float smoothTime = 3.0f;

    void ShowAndUnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void HideAndUnlockCursor()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        MouseInput();

    }

    private void MouseInput()
    {
        if (Input.GetMouseButton(1))
        {
            MouseRightClick();
        }
        else if (Input.GetMouseButton(2))
        {
              MiddleMouseClicked();
        }
        else if (Input.GetMouseButtonUp(1))
        {

            ShowAndUnlockCursor();
        }
        else if (Input.GetMouseButtonUp(2))
        {
            Debug.Log(startPos);
            startPos = transform.position;

            Debug.Log("updated start pos  " + startPos); 
            ShowAndUnlockCursor();
        }
    }

    // Rotate on Right Mouse Drag 
    private void MouseRightClick()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty;
        rotY += mouseX;
        rotX += mouseY;

        rotY = Mathf.Clamp(rotY, -70, -30);
        rotX = Mathf.Clamp(rotX, 15, 40);

        Vector3 nextRot = new Vector3(rotX, rotY);
        currRot = Vector3.SmoothDamp(currRot, nextRot, ref smoothVelo, smoothTime);
        transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        transform.position = startPos + gameFloorTarget.position - transform.forward * distanceFromTarget;

    }
    
    private void MiddleMouseClicked()
    {
        HideAndUnlockCursor();
        Vector3 newPos = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        Vector3 pos = transform.position;
        if (newPos.x > 0.0f)
        {
            pos += transform.right * .05f;

        }
        else if (newPos.x < 0.0f)
        {
            pos -= transform.right * .05f;

        }
        if ( newPos.z > 0.0f )
        {
            pos += transform.forward * .05f;

        } else if( newPos.z < 0.0f )
        {

            pos -= transform.forward * .05f;
        }

        pos.y = transform.position.y;
        transform.position = pos;

    }
    
}
