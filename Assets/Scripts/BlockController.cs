using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject block;
    List<Block> blocks;
    List<Vector3> positions;
    Dictionary<string, Block> blocksDict;
    public JSONReader json;
    public ChangeMaterialColor changeMaterialColor;

    string lastPosition;

    public void CreateABlock(Vector3 blockPosition, Color blockColor)
    {
        
        string key = DictionaryKeyFromPosition(blockPosition);

        // if there is not a block already in this position, make one 
        if( !blocksDict.ContainsKey( key ))
        {

            // Make a GameObject block
            GameObject go = Instantiate(block, blockPosition, Quaternion.identity);

            // I don't know what this line is doing  >> get behaviours needed for this block 
            Block newBlock = go.GetComponent<Block>();

            changeMaterialColor = go.GetComponent<ChangeMaterialColor>();
            if (changeMaterialColor == null)
                Debug.Log("COMPUTER SAYS NO");

            // set position of this block
            newBlock.pos = blockPosition;

            // set color of the block from color change script (random at the moment) 
            changeMaterialColor.onBlockDraw(blockColor);

            // add block to Dictionary
            blocksDict.Add(key, newBlock);
            go.name = "block_" + key + json.getAName(blocksDict.Count - 1);

        }
        else
        {
            Debug.Log("already block here silly ");
        }


    }
    
    public void DestroyBlock(Vector3 lastPosition)
    {
        string key = DictionaryKeyFromPosition(lastPosition);
        Block lastBlock;
        bool isLastBlock = blocksDict.TryGetValue(key, out lastBlock);
        
        if (isLastBlock)
        {
            Debug.Log("destroying block : " + lastBlock);
            Destroy(lastBlock.gameObject);      // How to remove a GameObject via a component that is attached to it
            blocksDict.Remove(key);
            Debug.Log(" removing key :  " + key);
        }
    }
    
    string DictionaryKeyFromPosition( Vector3 blockPosition )
    {

        int xPos = Mathf.FloorToInt(blockPosition.x);
        int yPos = Mathf.FloorToInt(blockPosition.y);
        int zPos = Mathf.FloorToInt(blockPosition.z);

        return xPos + "_" + yPos + "_" + zPos;

    }

    Block GetBlockAtGridPosition( Vector3 blockPosition )
    {

        string key = DictionaryKeyFromPosition(blockPosition);

        Block dictBlock;
        bool blockExists = blocksDict.TryGetValue( key, out dictBlock );

        if( blockExists )
        {
            return dictBlock;
        }
        else
        {
            return null;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        blocks = new List<Block>();
        blocksDict = new Dictionary<string, Block>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void blockNeighbours(Block newBlock)
    {

        Block leftBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.left);
        newBlock.left = leftBlock;
        if( leftBlock) leftBlock.right = newBlock;

        Block rightBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.right);
        newBlock.right = rightBlock;
        if (rightBlock) rightBlock.left = newBlock;

        Block topBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.up);
        newBlock.top = topBlock;
        if (topBlock) topBlock.bottom = newBlock;

        Block bottomBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.down);
        newBlock.bottom = bottomBlock;
        if (bottomBlock) bottomBlock.top = newBlock;

        Block frontBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.forward);
        newBlock.front = frontBlock;
        if (frontBlock) frontBlock.back = newBlock;

        Block backBlock = GetBlockAtGridPosition(newBlock.pos + Vector3.back);
        newBlock.back = backBlock;
        if (backBlock) backBlock.front = newBlock;
            

    }
}
