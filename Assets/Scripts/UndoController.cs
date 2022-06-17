using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UndoController : MonoBehaviour
{
    // pass a reference to MainController (assign in editor)
    [SerializeField]
    private MainController mainController;
   


    // This is called on click, 
    public void UndoButton()
    {

        // so we can now set the currentColor on MainController
        // to this button's color :)
        mainController.Undo();

    }

}
