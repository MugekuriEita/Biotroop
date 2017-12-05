using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {

    Transform tf;

    private float MoveValue = 1.0f;
    private float InputTime = 0f;
    private float MoveTime = 0.7f;
    private bool wasMoved = false;
    private float MoveInterval = 0.1f;

    private float SideMaxMove = 15.1f;
    private float UnderMaxmove = -31.1f;
    private float UpMaxMove = -0.1f;

    private bool isApproaching = true;
    public float ApproachSpeedX = 0f;

    public GameObject System;
    private SystemManeger systemManeger;

    // Use this for initialization
    void Start () {
        tf = this.transform;
        systemManeger = System.GetComponent<SystemManeger>();
    }
	
	// Update is called once per frame
	void Update () {
        if(systemManeger.canMove == true) {
            if (Input.GetKey(KeyCode.LeftArrow) && tf.position.x >= -SideMaxMove && isApproaching == true) {//キーを押したら一度動き、押し続けたらその方向に進み続ける(上限あり)
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    tf.position += new Vector3(-MoveValue, 0, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    tf.position += new Vector3(-MoveValue, 0, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.RightArrow) && tf.position.x <= SideMaxMove && isApproaching == true) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    tf.position += new Vector3(MoveValue, 0, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    tf.position += new Vector3(MoveValue, 0, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.UpArrow) && tf.position.y <= UpMaxMove) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    tf.position += new Vector3(0, MoveValue, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    tf.position += new Vector3(0, MoveValue, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.DownArrow) && tf.position.y >= UnderMaxmove) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    tf.position += new Vector3(0, -MoveValue, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    tf.position += new Vector3(0, -MoveValue, 0);
                    InputTime -= MoveInterval;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
            wasMoved = false;
            InputTime = 0;
        }
    }
}
