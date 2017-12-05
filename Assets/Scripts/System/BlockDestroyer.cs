using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour {

    public GameObject RightChecker;
    public GameObject LeftChecker;
    public GameObject UpChecker;
    public GameObject UnderChecker;

    private AroundChecker CheckerR;
    private AroundChecker CheckerL;
    private AroundChecker CheckerUp;
    private AroundChecker CheckerUn;

    public GameObject BreakEffectCreater;

    public GameObject System;
    private SystemManeger systemManeger;
	// Use this for initialization
	void Start () {
        CheckerR  = RightChecker.GetComponent<AroundChecker>();
        CheckerL  = LeftChecker.GetComponent<AroundChecker>();
        CheckerUp = UpChecker.GetComponent<AroundChecker>();
        CheckerUn = UnderChecker.GetComponent<AroundChecker>();
        systemManeger = System.GetComponent<SystemManeger>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.C) && systemManeger.canMove == true && systemManeger.NowMode == 0) {
            if (CheckerR.Collisioning == false || CheckerL.Collisioning == false || CheckerUp.Collisioning == false || CheckerUn.Collisioning == false) {
                if (other.gameObject.CompareTag("Block") ) {
                    Destroy(other.gameObject);
                    Instantiate(BreakEffectCreater, this.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
