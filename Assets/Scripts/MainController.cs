using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    BlockController blockController;
    Vector3 position;



    // Start is called before the first frame update
    void Start()
    {

        blockController = GetComponent<BlockController>();

    }

    // Update is called once per frame
    void Update()
    {
     
        // if a touch has happened 
        if( Input.touchCount > 0 )
        {
            // get the first touch point 
            Touch touch = Input.GetTouch( 0 );

            // if it is the beginning of the touch
            if( touch.phase == TouchPhase.Began )
            {
                position = touch.position;

                Ray camRay = Camera.main.ScreenPointToRay( position );
                //Debug.DrawRay( camRay.origin, camRay.direction );
                //blockController.CreateABlock( camRay. );
             
            }
           
        }

        else

        {

            if( Input.GetMouseButtonDown( 0 ) )
            {

                position = Input.mousePosition;

                // need to make for touch input also 

                // set a camera ray to come from the input mouse position 
                Ray camRay = Camera.main.ScreenPointToRay( position );

                // make a variable for storing the position that the ray hits a collider ( for me the floor plane )
                RaycastHit rayOnPlanePosition;
                
                // draw a debug ray from origin in the direction at the lenghth of 10, colour it red and draw it for three seconds 
                Debug.DrawRay( camRay.origin, camRay.direction * 10f, Color.red, 3f );

                
                Debug.Log( "position : " + position );

                // if  camRay is sent out and makes a collision this will return true, it will also set rayOnPlanePosition to the position at which the collision happens 
                if( Physics.Raycast( camRay, out rayOnPlanePosition ) )
                {
                    // set position to collision point 
                    position = rayOnPlanePosition.point;
                    // create a block at this position 
                    blockController.CreateABlock( position );

                }

            }
            
        }
        
    }
}
