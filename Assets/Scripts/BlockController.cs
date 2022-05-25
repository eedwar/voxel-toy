using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public    GameObject block;

    public void CreateABlock( Vector3 blockPosition ) 
    {
        Debug.Log( " creating a blockkkkkk " );
       // blockPosition.z = 0;
        Instantiate( block, blockPosition, Quaternion.identity );

    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
