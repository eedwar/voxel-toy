using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{

    [SerializeField]
    RectTransform blockPlaceIns;
    [SerializeField]
    RectTransform changeColorIns;
    [SerializeField]
    RectTransform undoMinimiseIns;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InstructionsController");
        LeanTween.alphaText(blockPlaceIns, 255, 2.2f).setEaseInOutQuart().setOnComplete(showColorInstruction);
      
    }
    void showColorInstruction()
    {
        LeanTween.alphaText(blockPlaceIns, 0, 1.2f).setEaseInOutQuart();


        LeanTween.alphaText(changeColorIns, 255, 2.2f ).setEaseInOutQuart().setOnComplete(showUndoInstruction);

    }
    void showUndoInstruction()
    {
        LeanTween.alphaText(changeColorIns, 0, 1.2f).setEaseInOutQuart();


         LeanTween.alphaText(undoMinimiseIns, 255, 2.2f).setEaseInOutQuart().setOnComplete(endInstructions);

    }
   void endInstructions()
    {
        LeanTween.alphaText(undoMinimiseIns, 0, 1.2f).setEaseInOutQuart();
    }
}
