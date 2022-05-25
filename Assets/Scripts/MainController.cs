using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    BlockController blockController;
    Vector3 nextPosition;
    List<Vector3> positions = new List<Vector3>();    // list for storing the positions of placed blocks



    // Start is called before the first frame update
    void Start()
    {

        blockController = GetComponent<BlockController>();

    }

    // Update is called once per frame
    void Update()
    {

        // if a touch has happened 
        if (Input.touchCount > 0)
        {
            // get the first touch point 
            Touch touch = Input.GetTouch(0);

            // if it is the beginning of the touch
            if (touch.phase == TouchPhase.Began)
            {
                nextPosition = touch.position;

                Ray camRay = Camera.main.ScreenPointToRay(nextPosition);
                //Debug.DrawRay( camRay.origin, camRay.direction );
                //blockController.CreateABlock( camRay. );

                // make a variable for storing the position that the ray hits a collider ( for me the floor plane )
                RaycastHit rayOnPlanePosition;

                // draw a debug ray from origin in the direction at the lenghth of 10, colour it red and draw it for three seconds 
                Debug.DrawRay(camRay.origin, camRay.direction * 10f, Color.red, 3f);


                Debug.Log("position : " + nextPosition);

                // if  camRay is sent out and makes a collision this will return true, it will also set rayOnPlanePosition to the position at which the collision happens 
                if (Physics.Raycast(camRay, out rayOnPlanePosition))
                {
                    // set position to collision point 
                    nextPosition = rayOnPlanePosition.point;
                    // create a block at this position 
                    blockController.CreateABlock(nextPosition);

                }
            }

        }

        else

        {

            if (Input.GetMouseButtonDown(0))
            {

                nextPosition = Input.mousePosition;

                // need to make for touch input also 

                // set a camera ray to come from the input mouse position 
                Ray camRay = Camera.main.ScreenPointToRay(nextPosition);

                // make a variable for storing the position that the ray hits a collider ( for me the floor plane )
                RaycastHit rayFromScreen;

                // draw a debug ray from origin in the direction at the lenghth of 10, colour it red and draw it for three seconds 
                Debug.DrawRay(camRay.origin, camRay.direction * 10f, Color.red, 3f);


                // if  camRay is sent out and makes a collision this will return true, it will also set rayOnPlanePosition to the position at which the collision happens 
                if (Physics.Raycast(camRay, out rayFromScreen))
                {
                    // set position to collision point 
                    nextPosition = rayFromScreen.point;
                    string gameObjectCollidedWith = rayFromScreen.collider.gameObject.name;


                    // Debug.Log("position : " + nextPosition );

                    nextPosition.x = Mathf.Round(nextPosition.x);
                    nextPosition.y = Mathf.Round(nextPosition.y);
                    nextPosition.z = Mathf.Round(nextPosition.z);

                    Debug.Log("position : " + nextPosition);
                    if ( gameObjectCollidedWith == "Plane")
                    {
                        // which object has the ray collided with
                        Debug.Log(gameObjectCollidedWith);

                        // draw cube at the position
                        blockController.CreateABlock(nextPosition);

                        // add position to positions list
                        positions.Add(nextPosition);
                    } 
                    else
                    {
                        // which object has the ray collided with
                        Debug.Log(gameObjectCollidedWith);
                        
                        // get cube position
                        Vector3 cubePosition = rayFromScreen.collider.gameObject.transform.position; 
                       
                        // add to the Y value based upon the scale of the cube ( divide 2 )
                        cubePosition.y += blockController.transform.localScale.y  * .5f;
                        
                        // draw cube at the updated position
                        blockController.CreateABlock(cubePosition);

                        // add position to positions list
                        positions.Add(cubePosition);
                    }
                }


            }

        }

    }
}
  
