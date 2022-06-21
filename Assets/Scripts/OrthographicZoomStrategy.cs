using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicZoomStrategy : IZoomStrategy

{
    // will be created at run time 
    public OrthographicZoomStrategy( Camera cam, float startingZoom)
    {
        Debug.Log(startingZoom);
        cam.orthographicSize = startingZoom;
    }

    public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
    {
        Debug.Log(delta);
        if ( cam.orthographicSize  == nearZoomLimit)
        {
            return;
        }
        cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, nearZoomLimit); // stay with in zoom bounds
    }

    public void ZoomOut(Camera cam, float delta, float farZoomLimit)
    {
        Debug.Log(delta);
        if (cam.orthographicSize == farZoomLimit)
        {
            return;
        }
        cam.orthographicSize = Mathf.Min(cam.orthographicSize + delta, farZoomLimit); // stay with in zoom bounds

    }


}
