using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemManeger : MonoBehaviour {

    public bool LeftOver = false;
    public bool RightOver = false;
    public bool UpOver = false;
    public bool DownOver = false;

    private int CreatePower = 0;

    private int A1Home;
    private int A2Home;
    private int A3Home;

    private int B1Home;
    private int B2Home;
    private int B3Home;

    private int A1Number;
    private int A2Number;
    private int A3Number;

    private int B1Number;
    private int B2Number;
    private int B3Number;

    public bool canMove = true;

    public int NowMode = 0; //Shiftキー押しながら左右で変動。0で掘り状態、1で建築

    private int BuildNumber = 0;
    private int BuildCursorY = 0;
    public GameObject BuildCursor;
    private Transform BuildCursorTF;

    private int MenuNumber = 0;
    private int MenuCursorY = 0;
    public GameObject MenuCursor;
    private Transform MenuCursorTF;

    private int MineMode = 0;
    private int BuildMode = 1;
    private int MenuMode = 2;

    public GameObject MenuBer;
    public GameObject Center;
    public GameObject Right;
    public GameObject Left;
    private Text CenterText;
    private Text RightText;
    private Text LeftText;

    public GameObject BuildList;
    public GameObject MenuList;

    // Use this for initialization
    void Start () {
        CenterText = Center.GetComponent<Text>();
        RightText = Right.GetComponent<Text>();
        LeftText = Left.GetComponent<Text>();

        BuildCursorTF = BuildCursor.transform;
        MenuCursorTF = MenuCursor.transform;
	}
	
	// Update is called once per frame
	void Update () {
        switch (NowMode % (MenuMode + 1)) {
            default:
                break;
            case 0: //採掘モード
                CenterText.text = "採 掘";
                RightText.text = "建 築";
                LeftText.text = "メニュー";
                BuildList.SetActive(false);
                MenuList.SetActive(false);
                break;
            case 1: //建築モード
                CenterText.text = "建 築";
                RightText.text = "メニュー";
                LeftText.text = "採 掘";
                BuildList.SetActive(true);
                MenuList.SetActive(false);
                break;
            case 2: //メニューモード
                CenterText.text = "メニュー";
                RightText.text = "採 掘";
                LeftText.text = "建 築";
                BuildList.SetActive(false);
                MenuList.SetActive(true);
                break;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            canMove = false;
            MenuBer.SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                NowMode--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                NowMode++;
            }
            if(NowMode == BuildMode) {
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    BuildNumber--;
                    if(BuildCursorY > -4) {
                        BuildCursorY--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    BuildNumber++;
                    if (BuildCursorY < 4) {
                        BuildCursorY++;
                    }
                }
            }
            if(NowMode == MenuMode) {
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    MenuNumber--;
                    if (MenuCursorY > -4) {
                        MenuCursorY--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    MenuNumber++;
                    if (MenuCursorY < 4) {
                        MenuCursorY++;
                    }
                }
            }
        } else {
            canMove = true;
            MenuBer.SetActive(false);
            BuildList.SetActive(false);
            MenuList.SetActive(false);
        }

        if(NowMode < 0) {
            NowMode = MenuMode;
        }

        BuildCursorTF.localPosition = new Vector3(-120, 20 + BuildCursorY * -30, -1);
        MenuCursorTF.localPosition = new Vector3(-120, 20 + MenuCursorY * -30, -1);


    }
}
