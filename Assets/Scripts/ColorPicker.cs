using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ColorPicker : MonoBehaviour
{

    RectTransform Rect;

    public TextMeshProUGUI DebugText; 


    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

        string debug = " mousePos = " + Input.mousePosition;
        debug += "<br>delta = " + delta;

        float width = Rect.rect.width;
        float height = Rect.rect.height;

        Vector2 offsetDelta = delta + new Vector2(width * .5f, height * .5f);


        debug += "<br> offsetDelta = " + offsetDelta;

        DebugText.text = debug; 
    }
}
