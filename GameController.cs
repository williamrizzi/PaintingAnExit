using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameManage
    {
        InGame, Menu, Settings, Pause, Victory, Death, FreezeScreen
    }

    public enum PlayerColors
    {
        White, Blue, Green, Orange, Pink
    }

    public GameManage gameStatus;
    public PlayerColors colorStatus;

    private GameObject player;
    private SkullAnimCtrl skullAnim;
    private CameraFollow cameraCtrl;


    private GameObject bluePortal;
    private GameObject greenPortal;
    private GameObject orangePortal;
    private GameObject pinkPortal;

    private GameObject whiteGrid;
    private GameObject blueGrid;
    private GameObject greenGrid;
    private GameObject orangeGrid;
    private GameObject pinkGrid;

    private GameObject titleObj;

    private GameObject treeObj;
    public GameObject mountainObj;
    private GameObject starsObj;

    public GameObject nevoa;

    public bool parallax;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameManage.Menu;
        colorStatus = PlayerColors.White;

        player = GameObject.FindGameObjectWithTag("Player");
        skullAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<SkullAnimCtrl>();
        cameraCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        

        bluePortal = GameObject.FindGameObjectWithTag("BluePortal");
        greenPortal = GameObject.FindGameObjectWithTag("GreenPortal");
        orangePortal = GameObject.FindGameObjectWithTag("OrangePortal");
        pinkPortal = GameObject.FindGameObjectWithTag("PinkPortal");

        whiteGrid = GameObject.Find("ContentWhite");
        blueGrid = GameObject.Find("ContentBlue");
        greenGrid = GameObject.Find("ContentGreen");
        orangeGrid = GameObject.Find("ContentOrange");
        pinkGrid = GameObject.Find("ContentPink");

        titleObj = GameObject.Find("TitleText");

        treeObj = GameObject.Find("Trees");
        mountainObj = GameObject.Find("Mountains");
        starsObj = GameObject.Find("Stars");

        

        parallax = false;
    }

    // Update is called once per frame
    void Update()
    {      
        if(gameStatus == GameManage.Menu)
        {
            titleObj.SetActive(true);
        }
        else if(gameStatus != GameManage.Menu)
        {
            titleObj.SetActive(false);
        }
    }

    public void RestartMatch()
    {
        nevoa.transform.position = new Vector3(-6.5f, nevoa.transform.position.y, nevoa.transform.position.z);
        //restart player color and colorlevel
        player.GetComponent<PlayerMoviment>().colorLevel = 1;
        colorStatus = PlayerColors.White;
        //restart skull animations
        skullAnim.SetDeathOff();
        skullAnim.IdleOn();
        skullAnim.PlayIdle();
        //restart player position and Physics
        player.transform.position = new Vector3(-2, -1.5f, 0);
        player.GetComponent<PlayerMoviment>().controllerBlock = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //RestartPortals
        bluePortal.SetActive(true);
        greenPortal.SetActive(true);
        orangePortal.SetActive(true);
        pinkPortal.SetActive(true);
        //restart Grid Positions
        whiteGrid.transform.position = new Vector3(0, 0, 0);
        blueGrid.transform.position = new Vector3(0, -12, 0);
        greenGrid.transform.position = new Vector3(0, -12, 0);
        orangeGrid.transform.position = new Vector3(0, -12, 0);
        pinkGrid.transform.position = new Vector3(0, -12, 0);
        //Restart Parallax
        treeObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        mountainObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        starsObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        //RestartBlackScreen
        cameraCtrl.ResetBlackScreen();
    }

    public void PlayMatch()
    {
        nevoa.transform.position = new Vector3(-6.5f, nevoa.transform.position.y, nevoa.transform.position.z);
        //restart player color and colorlevel
        player.GetComponent<PlayerMoviment>().colorLevel = 1;
        colorStatus = PlayerColors.White;
        //restart skull animations
        skullAnim.SetDeathOff();
        skullAnim.IdleOn();
        skullAnim.PlayIdle();
        //restart player position and Physics
        player.transform.position = new Vector3(-2, -1.5f, 0);
        player.GetComponent<PlayerMoviment>().controllerBlock = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //RestartPortals
        bluePortal.SetActive(true);
        greenPortal.SetActive(true);
        orangePortal.SetActive(true);
        pinkPortal.SetActive(true);
        //restart Grid Positions
        whiteGrid.transform.position = new Vector3(0, 0, 0);
        blueGrid.transform.position = new Vector3(0, -12, 0);
        greenGrid.transform.position = new Vector3(0, -12, 0);
        orangeGrid.transform.position = new Vector3(0, -12, 0);
        pinkGrid.transform.position = new Vector3(0, -12, 0);
        //Restart Parallax
        treeObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        mountainObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        starsObj.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        //RestartBlackScreen
        cameraCtrl.ResetBlackScreen();
    }

}
