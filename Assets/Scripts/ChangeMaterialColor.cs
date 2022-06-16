using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeMaterialColor : MonoBehaviour
{
   
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;

  
    public void onBlockDraw(Color blockColor)
    
    {
        // do I make these each time?
        _propertyBlock = new MaterialPropertyBlock();
        _renderer = GetComponentInChildren<Renderer>();


        _renderer.GetPropertyBlock(_propertyBlock);

        _propertyBlock.SetColor("_Color", blockColor);

        _renderer.SetPropertyBlock(_propertyBlock);
        
    }
    

   
}
