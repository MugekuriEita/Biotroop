using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundChecker : MonoBehaviour {

    public bool Collisioning = false;
    private bool BlockOrWall = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Collisioning == true) {
            if (BlockOrWall == true) {
                Collisioning = true;
            } else {
                Collisioning = false;
            }
        }
	}

    /*private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Wall") == false) Debug.Log("");
        if (other.gameObject.CompareTag("Block")) {
            Collisioning = false;
        }
    }*/

    void OnTriggerStay(Collider other) {
        Collisioning = true;
        if (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Wall")) {
            BlockOrWall = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        Collisioning = false;
    }

}
