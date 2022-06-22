using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    // a delegate is a container for a function 
    // something about stacking functionailty 
    // can "double cast" these things 
    public delegate void MoveInputHandler(Vector3 moveVector);
    public delegate void RotateInputHandler(float rotateAmout);
    public delegate void ZoomInputHandler(float zoomAmount);

}
