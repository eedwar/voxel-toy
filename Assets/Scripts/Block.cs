using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// seems very empty 
public class Block : MonoBehaviour
{
    [SerializeField]
    public Block top;

    [SerializeField]
    public Block bottom;

    [SerializeField]
    public Block left;

    [SerializeField]
    public Block right;

    [SerializeField]
    public Block front;

    [SerializeField]
    public Block back;

    public Vector3 pos;

    public Material blockMat;

    public Renderer blockRenderer; 
 
}

