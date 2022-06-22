using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // pass a reference to MainController (assign in editor)
    [SerializeField]
    private MainController mainController;
    // Store a color for this button (assign in editor)
    [SerializeField]
    private Color buttonColor;


    // This is called on click of each of the colors in the color picker
    public void SelectedButton()
    {

        // so we can now set the currentColor on MainController
        // to this button's color :)
        mainController.SetCurrentColor(buttonColor);

    }

}
