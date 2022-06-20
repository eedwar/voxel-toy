using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseController : MonoBehaviour
{
    // pass a reference to colorPickerUI
    // (assign in editor)

    [SerializeField]
    GameObject colorPickerUI;
    [SerializeField]
    GameObject otherUI;
    [SerializeField]
    Text closeText;

    private int clickCount = 1;

    // This is called on click, 
    public void CloseButton()
    {

        if ( clickCount % 2 == 1 )
        {
            Vector3 moveTo = new Vector3(0, 1, 0);
            colorPickerUI.LeanScaleX(0f, 0.2f).setEaseInOutQuart();
            otherUI.LeanMoveX(otherUI.transform.position.x - 30, 0.2f).setEaseInOutQuart();
            //colorPickerUI.LeanMove(moveTo, 2f);
           // colorPickerUI.SetActive(false);
            closeText.text = ">";
        }
        else
        {
            //  colorPickerUI.SetActive(true);
            colorPickerUI.LeanScaleX(1f, 0.2f);
            otherUI.LeanMoveX(otherUI.transform.position.x + 30, 0.2f).setEaseInOutQuart();
            closeText.text = "<";
        }
        clickCount++;
        /* // Scale doesn't change 
         Debug.Log(colorPickerUI.transform.localScale.y);
         float colorPickerScaleNew = 0.1f;
         Vector3 colorPickerUIScale = colorPickerUI.transform.localScale;
             colorPickerUIScale.y = colorPickerScaleNew;
         Debug.Log(colorPickerUI.transform.localScale.y);
         */
    }

}
