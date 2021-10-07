using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    private GameController gameCtrl;
    private CameraFollow cameraCtrl;
    private PlayerMoviment playerMove;
    private GameConfigurations configCtrl;
    private ButtonController buttonCtrl;
    private SkullAnimCtrl animCtrl;

    private Text inGameText;

    private bool firstJump;
    private bool firstPortal;
    private bool firstColor;

    public bool endGame;

    // Start is called before the first frame update
    void Start()
    {
        cameraCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoviment>();
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        configCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameConfigurations>();
        buttonCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonController>();
        animCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<SkullAnimCtrl>();

        inGameText = GameObject.Find("InGameText").GetComponent<Text>();

        firstJump = true;
        firstPortal = true;
        firstColor = true;

        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endGame == true)
        {
            if (playerMove.grounded == true)
            {
                playerMove.rigid.bodyType = RigidbodyType2D.Static;
                playerMove.rigid.simulated = true;
                animCtrl.WalkOff();
                animCtrl.JumpOff();
                animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Idle;
                animCtrl.IdleOn();
                animCtrl.PlayIdle();
                playerMove.grounded = true;
            }
        }

        if(endGame == false && gameCtrl.gameStatus != GameController.GameManage.Death)
        {
            playerMove.rigid.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    IEnumerator ActiveInGameText()
    {
        inGameText.enabled = true;
        yield return new WaitForSeconds(2f);
        inGameText.enabled = false;
    }

    IEnumerator ActiveDeathMenu()
    {
        yield return new WaitForSeconds(1f);
        DeathCast();
    }

    IEnumerator ActiveVictoryMenu()
    {
        yield return new WaitForSeconds(1f);
        VictoryCast();
    }

    public void OnTriggerEnter2D(Collider2D collision)    
    {
        if(collision.transform.name == "StartCameraFollow")
        {
            cameraCtrl.SetFreeze(false);
            cameraCtrl.SetFollow(true);
            gameCtrl.parallax = true;
        }
        if(collision.transform.name == "StopCameraFollow")
        {
            cameraCtrl.SetFollow(false);
        }
        if(collision.transform.tag == "FinalTarget")
        {
            playerMove.controllerBlock = true;
            cameraCtrl.SetFreeze(false);
            endGame = true;
            StartCoroutine("ActiveVictoryMenu");
        }

        if(collision.transform.tag == "Spike" || collision.transform.tag == "Death")
        {
            gameCtrl.gameStatus = GameController.GameManage.Death;
            playerMove.controllerBlock = true;
            playerMove.rigid.bodyType = RigidbodyType2D.Static;
            playerMove.ForceDeath();
            playerMove.SetAnimDeath();
            cameraCtrl.StartFadeIn();
            StartCoroutine("ActiveDeathMenu"); // -------------------------------------------------------------------------------------------------aqui ó, não seja gado!
        }
        if (collision.transform.tag == "Jumper")
        {

            playerMove.ForceJumper();
            collision.GetComponentInChildren<Animator>().SetBool("Jump", true);
        }
        if(collision.transform.tag == "BluePortal")
        {
            //audioCtrl.PlayAMusic(1);
            playerMove.ForcePortal();
            playerMove.colorLevel = 2;
            gameCtrl.colorStatus = GameController.PlayerColors.Blue;
            collision.gameObject.SetActive(false);
        }
        if (collision.transform.tag == "GreenPortal")
        {
            //audioCtrl.PlayAMusic(2);
            playerMove.ForcePortal();
            playerMove.colorLevel = 3;
            gameCtrl.colorStatus = GameController.PlayerColors.Green;
            collision.gameObject.SetActive(false);
        }
        if (collision.transform.tag == "OrangePortal")
        {
            //audioCtrl.PlayAMusic(3);
            playerMove.ForcePortal();
            playerMove.colorLevel = 4;
            gameCtrl.colorStatus = GameController.PlayerColors.Green;
        }
        if (collision.transform.tag == "PinkPortal")
        {
            //audioCtrl.PlayAMusic(4);
            playerMove.ForcePortal();
            playerMove.colorLevel = 5;
            gameCtrl.colorStatus = GameController.PlayerColors.Green;
        }
        if(collision.transform.name == "jumpTextCol")
        {
            if(firstJump == true)
            {
                configCtrl.JumpText();
                StartCoroutine("ActiveInGameText");
                firstJump = false;
            }            
        }
        if (collision.transform.name == "portalTextCol")
        {
            if(firstPortal == true)
            {
                configCtrl.PortalText();
                StartCoroutine("ActiveInGameText");
                firstPortal = false;
            }            
        }
        if (collision.transform.name == "colorTextCol")
        {
            if(firstColor == true)
            {
                configCtrl.ColorText();
                StartCoroutine("ActiveInGameText");
                firstColor = false;
            }           
        }

    }

    public void DeathCast()
    {
        gameCtrl.gameStatus = GameController.GameManage.Death;
        configCtrl.SetDeathText();
        configCtrl.SetVisibleText();
        buttonCtrl.DeathMenu();   
    }

    public void VictoryCast()
    {
        gameCtrl.gameStatus = GameController.GameManage.Victory;
        configCtrl.SetVictoryText();
        configCtrl.SetVisibleText();
        buttonCtrl.DeathMenu();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Fan")
        {
            playerMove.ForceFan();
        }
    }

    public void ResetFirstTexts()
    {
        firstJump = true;
        firstPortal = true;
        firstColor = true;
    }
}
