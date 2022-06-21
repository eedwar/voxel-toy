using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveZoomStrategy : IZoomStrategy

{

    Vector3 normalisedCameraPosition;           // zoom can multiple this by zoom level 
    float currentZoomLevel;                     // keep track of zoom 


    // will be created at run time 
    public PerspectiveZoomStrategy( Camera cam, Vector3 offset, float startingZoom)
    {
        normalisedCameraPosition = new Vector3(0f, Mathf.Abs( offset.y ), -Mathf.Abs(offset.x)).normalized;
        currentZoomLevel = startingZoom;
        PositionCamera(cam);

    }

    private void PositionCamera(Camera cam)
    {
        // what ever the zoom level is prosition the camera properly along this vector
        cam.transform.localPosition = normalisedCameraPosition * currentZoomLevel;
    }


    public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
    {
        if (  currentZoomLevel <= nearZoomLimit )
        {
            return;
        }
        currentZoomLevel = Mathf.Max(currentZoomLevel - delta, nearZoomLimit);
        PositionCamera(cam);
    }

    public void ZoomOut(Camera cam, float delta, float farZoomLimit)
    {

        if (currentZoomLevel >= farZoomLimit)
        {
            return;
        }
        currentZoomLevel = Mathf.Min(currentZoomLevel + delta, farZoomLimit);
        PositionCamera(cam); 
        

    }


}
