using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // pass a reference to MainController (assign in editor)
    [SerializeField]
    private MainController mainController;
    // pass a reference to MainController (assign in editor)
    [SerializeField]
    private BlockController blockController;
    // Store a color for this button (assign in editor)
    [SerializeField]
    private Color buttonColor;


    // This is called on click, 
    public void SelectedButton()
    {

        // so we can now set the currentColor on MainController
        // to this button's color :)
        mainController.SetCurrentColor(buttonColor);

    }

    public void UndoButton()
    {
        blockController.DestroyBlock();
    }

}
