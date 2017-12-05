using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour {

    public GameObject BlockPrefab;
    private GameObject Block;

	// Use this for initialization
	void Start () {
        for (int i = 0; i <= 32; i++) { // iはｙ座標、jがx座標
            for(int j = -16; j  <= 16; j++) {
                if (j == 0 && i == 0 || j == 0 && i == 1 || j == 0 && i == 2 || j == 1 && i == 2) {
                    
                } else {
                    Block = Instantiate(BlockPrefab, new Vector3(j, -i, 0), Quaternion.identity) as GameObject;
                    Block.transform.parent = this.transform;
                }
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
