using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile; 

    // Start is called before the first frame update
    public string getAName(int i)
    {
        BlockNames namesInJson = JsonUtility.FromJson<BlockNames>(jsonFile.text);

        Name name = namesInJson.blockNames[i];
        // Debug.Log(name.name);
        return name.name;
        /*
        foreach( Name name in namesInJson.blockNames )
        {
            Debug.Log(" Found name : " + name.name );
        }
        */
    }

}
