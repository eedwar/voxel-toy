using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header(" Camera Positioning ")]
    public Vector2 cameraOffset = new Vector2(10f, 14f);
    public float lookAtOffset = 2f;     // to not look at the ground 

    [Header(" Move Controls ")]
    public float inOutSpeed = 5f;
    public float lateralSpeed = 5f;
    public float rotateSpeed = 4.5f;

    [Header(" Move Bounds ")]
    public Vector2 minBounds, maxBounds;

    [Header(" Zoom Controls ")]
    public float zoomSpeed = 4f;
    public float nearZoomLimit = 2f;
    public float farZoomLimit = 16f;
    public float startingZoom = 5f;

    IZoomStrategy zoomStrategy;
    Vector3 frameMove;
    float frameRotate;
    float frameZoom;
    Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        
        // camera position set in inpector so not needed 
        // cam.transform.localPosition = new Vector3(0, Mathf.Abs(cameraOffset.y), -Mathf.Abs(cameraOffset.x));
        // cam.transform.LookAt(transform.position + Vector3.up * lookAtOffset);


        // check which kind of camera is being used. Select the appropriate zoom strategy for this camera [ need to cast the values to IZoom ] 
        zoomStrategy = cam.orthographic ? (IZoomStrategy) new OrthographicZoomStrategy(cam, startingZoom) : new PerspectiveZoomStrategy(cam, cameraOffset, startingZoom);


    }

    private void OnEnable()
    {
        // this is subscribing to these events

        // when the onMoveInput event ( which is in either of the input Controller classes ) is fired do the UpdateFrameMove function 
        KeyboardInputController.onMoveInput += UpdateFrameMove;
        KeyboardInputController.onRotateInput += UpdateFrameRotate;
        KeyboardInputController.onZoomInput += UpdateFrameZoom;
        MouseInputController.onMoveInput += UpdateFrameMove;
        MouseInputController.onRotateInput += UpdateFrameRotate;
        MouseInputController.onZoomInput += UpdateFrameZoom;
    }
    private void OnDisable()
    {
        // this is unsubscribing to the events ( i.e stop listening ) 
        KeyboardInputController.onMoveInput -= UpdateFrameMove;
        KeyboardInputController.onRotateInput -= UpdateFrameRotate;
        KeyboardInputController.onZoomInput -= UpdateFrameZoom;
        MouseInputController.onMoveInput -= UpdateFrameMove;
        MouseInputController.onRotateInput -= UpdateFrameRotate;
        MouseInputController.onZoomInput -= UpdateFrameZoom;
    }

    private void UpdateFrameMove(Vector3 moveVector)
    {
        frameMove += moveVector;
    }

    private void UpdateFrameRotate(float rotateAmount)
    {
        frameRotate += rotateAmount;
    }
    private void UpdateFrameZoom(float zoomAmount)
    {
        frameZoom += zoomAmount;
    }

    private void LateUpdate()
    {
        if( frameMove != Vector3.zero)
        {
            Vector3 speedModFrameMove = new Vector3(frameMove.x * lateralSpeed, frameMove.y, frameMove.z * inOutSpeed);

            transform.position += transform.TransformDirection(speedModFrameMove) * Time.deltaTime;

            LockPositionInBounds();
            
            frameMove = Vector3.zero;

        }

        if( frameRotate != 0f)
        {
            transform.Rotate(Vector3.up, frameRotate * Time.deltaTime * rotateSpeed);
            frameRotate = 0f;
        }

        if( frameZoom < 0f)
        {
            zoomStrategy.ZoomIn(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomSpeed, nearZoomLimit);
            frameZoom = 0f; 


        } else if ( frameZoom > 0f)
        {
            zoomStrategy.ZoomOut(cam, Time.deltaTime * frameZoom * zoomSpeed, farZoomLimit);
            frameZoom = 0f; 
        }
    }

    private void LockPositionInBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y)
            );
    }
}
