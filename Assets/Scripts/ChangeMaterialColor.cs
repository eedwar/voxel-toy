using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
   // [SerializeField]
    public Color[] colorArr = { new Color(1,0,1), new Color(1, 1, 0), new Color(0, 1, 1) };// blockColor1, blockColor2;
    public float Speed = 1, Offset; 


    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;

     void Start()
    {


        _propertyBlock = new MaterialPropertyBlock();
        _renderer = GetComponentInChildren<Renderer>();
        _renderer.GetPropertyBlock(_propertyBlock);

        // _propertyBlock.SetColor("_Color", Color.Lerp(blockColor1, blockColor2, (Mathf.Sin(Time.time * Speed + Offset) + 1) / 2f));
        _propertyBlock.SetColor("_Color", colorArr[Random.Range(0, 3)]);
        // Debug.Log(_propertyBlock.GetColor("_Color"));
        _renderer.SetPropertyBlock(_propertyBlock);

    }

     public void onBlockDraw()
    {
        Debug.Log(" I LOVE COLOURSSSSSSSS ");
    }
}