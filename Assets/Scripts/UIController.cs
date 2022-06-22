using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField]
    public Image currentColorUI;

    public void showCurrentColorUI(Color showCurrentColor )
    {

        // sets alpha to full 
        showCurrentColor.a = 1;
        // sets color of UI image to the color pass from button controller (on each of the colors)
        currentColorUI.color = showCurrentColor;
        

    }
}
