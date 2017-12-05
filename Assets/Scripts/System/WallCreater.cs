using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreater : MonoBehaviour {

    public GameObject WallPrefab;
    private GameObject Wall;

	// Use this for initialization
	void Start () {
		for(int i = 0;  i<= 32; i++) {
            Wall = Instantiate(WallPrefab, new Vector3(-17,-i,0), Quaternion.identity) as GameObject;
            Wall.transform.parent = this.transform;
        }
        for (int j = 0; j <= 32; j++) {
            Wall = Instantiate(WallPrefab, new Vector3(17, -j, 0), Quaternion.identity) as GameObject;
            Wall.transform.parent = this.transform;
        }
        for(int k = -17; k <= 17; k++) {
            Wall = Instantiate(WallPrefab, new Vector3(k, -33, 0), Quaternion.identity) as GameObject;
            Wall.transform.parent = this.transform;
        }
        for (int l = -17; l <= 17; l++) {
            if (l != 0) {
                Wall = Instantiate(WallPrefab, new Vector3(l, 1, 0), Quaternion.identity) as GameObject;
            }
            Wall.transform.parent = this.transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
