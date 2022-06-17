using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseController : MonoBehaviour
{
    // pass a reference to colorPickerUI
    // (assign in editor)

    [SerializeField]
    private GameObject colorPickerUI;


    // This is called on click, 
    public void CloseButton()
    {
        // Scale doesn't change 

        Debug.Log(colorPickerUI.transform.localScale.y);
        float colorPickerScaleNew = 0.1f;
        Vector3 colorPickerUIScale = colorPickerUI.transform.localScale;
            colorPickerUIScale.y = colorPickerScaleNew;
        Debug.Log(colorPickerUI.transform.localScale.y);
    }

}
