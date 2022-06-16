using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField]
    public Image currentColorUI;

    private void Start()
    {
        
    }
    public void showCurrentColorUI(Color showCurrentColor )
    {
        showCurrentColor.a = 1;
        currentColorUI.color = showCurrentColor;
        
        Debug.Log(showCurrentColor);

    }
}
