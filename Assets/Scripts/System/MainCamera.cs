using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    Transform TF;

    private float MoveValue = 1.0f;
    private float InputTime = 0f;
    private float MoveTime = 0.7f;
    private bool wasMoved = false;
    private float MoveInterval = 0.1f;

    private float SideMaxMove = 8.1f;
    private float UnderMaxmove = -27.1f;
    private float UpMaxMove = -0.1f;

    private bool isApproaching = true;
    private float ApproachSpeedZ = 0f;
    private float ApproachZ = -10f;
    private float DisApproachZ = -20f;
    public float ApproachSpeedX = 0f;

    private bool isMoving = false;

    public GameObject SelectFrame;
    private Transform frameTF;

    public bool LeftOver = false;
    public bool RightOver = false;
    public bool UpOver = false;
    public bool DownOver = false;

    public GameObject System;
    private SystemManeger systemManeger;

    // Use this for initialization
    void Start () {
        TF = this.transform;
        frameTF = SelectFrame.transform;
        systemManeger = System.GetComponent<SystemManeger>();
    }

    // Update is called once per frame
    void Update(){
        if (systemManeger.canMove == true) {
            if (Input.GetKey(KeyCode.LeftArrow) && TF.position.x >= -SideMaxMove && isApproaching == true && RightOver == false) {//キーを押したら一度動き、押し続けたらその方向に進み続ける(上限あり)
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    TF.position += new Vector3(-MoveValue, 0, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    TF.position += new Vector3(-MoveValue, 0, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.RightArrow) && TF.position.x <= SideMaxMove && isApproaching == true && LeftOver == false) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    TF.position += new Vector3(MoveValue, 0, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    TF.position += new Vector3(MoveValue, 0, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.UpArrow) && TF.position.y <= UpMaxMove && DownOver == false) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    TF.position += new Vector3(0, MoveValue, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    TF.position += new Vector3(0, MoveValue, 0);
                    InputTime -= MoveInterval;
                }
            } else if (Input.GetKey(KeyCode.DownArrow) && TF.position.y >= UnderMaxmove && UpOver == false) {
                InputTime += Time.deltaTime;
                if (wasMoved == false) {
                    TF.position += new Vector3(0, -MoveValue, 0);
                    wasMoved = true;
                }
                if ((InputTime - MoveTime) >= MoveInterval) {
                    TF.position += new Vector3(0, -MoveValue, 0);
                    InputTime -= MoveInterval;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
            wasMoved = false;
            InputTime = 0;
        }

        if(isApproaching == true && TF.position.z < ApproachZ) {
            TF.position += new Vector3(0, 0, ApproachSpeedZ);
            ApproachSpeedZ += 0.03f;
        }
        if(isApproaching == false && TF.position.z > DisApproachZ) {
            TF.position += new Vector3(0, 0, -ApproachSpeedZ);
            ApproachSpeedZ += 0.03f;
        }
        if(isMoving == true && TF.position.x > 0.9) {
            TF.position += new Vector3(-ApproachSpeedX,0,0);
            ApproachSpeedX += 0.03f;
        }
        if(isMoving == true && TF.position.x < -0.9) {
            TF.position += new Vector3(ApproachSpeedX, 0, 0);
            ApproachSpeedX += 0.03f;
        }

        if(TF.position.z < DisApproachZ) {
            ApproachSpeedZ = 0;
            TF.position = new Vector3(TF.position.x, TF.position.y, DisApproachZ);
        }
        if(TF.position.z > ApproachZ) {
            ApproachSpeedZ = 0;
            TF.position = new Vector3(TF.position.x, TF.position.y, ApproachZ);
        }
        
        if(isApproaching == true) {
            UnderMaxmove = -27.1f; 
        } else {
            UnderMaxmove = -22.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if(isApproaching == true) {
                isApproaching = false;
                isMoving = true;
            } else {
                isApproaching = true;
                isMoving = true;
            }
        }

        if (TF.position.x < 0.5f && TF.position.x > -0.5f) {
            isMoving = false;
            TF.position = new Vector3(0, TF.position.y, TF.position.z);
            ApproachSpeedX = 0;
        }

        if ((TF.position.x - frameTF.position.x) > 0) {
            LeftOver = true;
            RightOver = false;
        }else if((TF.position.x - frameTF.position.x) == 0) {
            LeftOver = false;
            RightOver = false;
        }else if((TF.position.x - frameTF.position.x) < 0) {
            LeftOver = false;
            RightOver = true;
        }
        if((TF.position.y - frameTF.position.y) > 0) {
            UpOver = true;
            DownOver = false;
        }else if((TF.position.y - frameTF.position.y) == 0) {
            UpOver = false;
            DownOver = false;
        }
        else if((TF.position.y - frameTF.position.y) < 0) {
            UpOver = false;
            DownOver = true;
        }
    }
}
