using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAnimCtrl : MonoBehaviour
{
    public enum AnimationPose
    {
        Idle, Walk, Jump
    }
    
    public AnimationPose poseStatus;

    // GameController Script
    private GameController gameCtrl;

    // Skull Moviment Script
    private PlayerMoviment moveCtrl;

    // Skull Animators
    private Animator whiteAnimator;
    private Animator blueAnimator;
    private Animator greenAnimator;
    private Animator orangeAnimator;
    private Animator pinkAnimator;

    // Skull Sprites
    private GameObject whiteChar;
    private GameObject blueChar;
    private GameObject greenChar;
    private GameObject orangeChar;
    private GameObject pinkChar;

    // Start is called before the first frame update
    void Start()
    {
        // Find GameController Script
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        // Get Skull Moviment Script
        moveCtrl = gameObject.GetComponent<PlayerMoviment>();

        // Find Skull Animators
        whiteAnimator = GameObject.Find("WhiteSkull").GetComponent<Animator>();
        blueAnimator = GameObject.Find("BlueSkull").GetComponent<Animator>();
        greenAnimator = GameObject.Find("GreenSkull").GetComponent<Animator>();
        orangeAnimator = GameObject.Find("OrangeSkull").GetComponent<Animator>();
        pinkAnimator = GameObject.Find("PinkSkull").GetComponent<Animator>();

        // Find Skull Sprites
        whiteChar = GameObject.Find("WhiteSkull");
        blueChar = GameObject.Find("BlueSkull");
        greenChar = GameObject.Find("GreenSkull");
        orangeChar = GameObject.Find("OrangeSkull");
        pinkChar = GameObject.Find("PinkSkull");

        

        // Start Initial Pose 
        poseStatus = AnimationPose.Idle;

        // Start with White Skull
        whiteChar.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetColorAnim();        
        if(moveCtrl.grounded == true && poseStatus == AnimationPose.Idle)
        {
            IdleOn();
            WalkOff();
            JumpOff();
        }
        if(moveCtrl.grounded == true && poseStatus == AnimationPose.Walk)
        {
            IdleOff();
            WalkOn();
            JumpOff();
        }
        if(moveCtrl.grounded == false && poseStatus == AnimationPose.Jump)
        {
            IdleOff();
            WalkOff();
            JumpOn();
        }
    }

    public void IdleOn()
    {
        whiteAnimator.SetBool("Idle", true);
        blueAnimator.SetBool("Idle", true);
        greenAnimator.SetBool("Idle", true);
        orangeAnimator.SetBool("Idle", true);
        pinkAnimator.SetBool("Idle", true);
    }

    public void IdleOff()
    {
        whiteAnimator.SetBool("Idle", false);
        blueAnimator.SetBool("Idle", false);
        greenAnimator.SetBool("Idle", false);
        orangeAnimator.SetBool("Idle", false);
        pinkAnimator.SetBool("Idle", false);
    }

    public void WalkOn()
    {
        whiteAnimator.SetBool("Walk", true);
        blueAnimator.SetBool("Walk", true);
        greenAnimator.SetBool("Walk", true);
        orangeAnimator.SetBool("Walk", true);
        pinkAnimator.SetBool("Walk", true);
    }

    public void WalkOff()
    {
        whiteAnimator.SetBool("Walk", false);
        blueAnimator.SetBool("Walk", false);
        greenAnimator.SetBool("Walk", false);
        orangeAnimator.SetBool("Walk", false);
        pinkAnimator.SetBool("Walk", false);
    }

    public void JumpOn()
    {
        whiteAnimator.SetBool("Jump", true);
        blueAnimator.SetBool("Jump", true);
        greenAnimator.SetBool("Jump", true);
        orangeAnimator.SetBool("Jump", true);
        pinkAnimator.SetBool("Jump", true);
    }

    public void JumpOff()
    {
        whiteAnimator.SetBool("Jump", false);
        blueAnimator.SetBool("Jump", false);
        greenAnimator.SetBool("Jump", false);
        orangeAnimator.SetBool("Jump", false);
        pinkAnimator.SetBool("Jump", false);
    }

    public void SetColorAnim()
    {
        if(gameCtrl.colorStatus == GameController.PlayerColors.White)
        {
            whiteChar.GetComponent<SpriteRenderer>().enabled = true;
            blueChar.GetComponent<SpriteRenderer>().enabled = false;
            greenChar.GetComponent<SpriteRenderer>().enabled = false;
            orangeChar.GetComponent<SpriteRenderer>().enabled = false;
            pinkChar.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
        {
            whiteChar.GetComponent<SpriteRenderer>().enabled = false;
            blueChar.GetComponent<SpriteRenderer>().enabled = true;
            greenChar.GetComponent<SpriteRenderer>().enabled = false;
            orangeChar.GetComponent<SpriteRenderer>().enabled = false;
            pinkChar.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (gameCtrl.colorStatus == GameController.PlayerColors.Green)
        {
            whiteChar.GetComponent<SpriteRenderer>().enabled = false;
            blueChar.GetComponent<SpriteRenderer>().enabled = false;
            greenChar.GetComponent<SpriteRenderer>().enabled = true;
            orangeChar.GetComponent<SpriteRenderer>().enabled = false;
            pinkChar.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (gameCtrl.colorStatus == GameController.PlayerColors.Orange)
        {
            whiteChar.GetComponent<SpriteRenderer>().enabled = false;
            blueChar.GetComponent<SpriteRenderer>().enabled = false;
            greenChar.GetComponent<SpriteRenderer>().enabled = false;
            orangeChar.GetComponent<SpriteRenderer>().enabled = true;
            pinkChar.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (gameCtrl.colorStatus == GameController.PlayerColors.Pink)
        {
            whiteChar.GetComponent<SpriteRenderer>().enabled = false;
            blueChar.GetComponent<SpriteRenderer>().enabled = false;
            greenChar.GetComponent<SpriteRenderer>().enabled = false;
            orangeChar.GetComponent<SpriteRenderer>().enabled = false;
            pinkChar.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void SetDeath()
    {
        whiteAnimator.SetBool("Death", true);
        blueAnimator.SetBool("Death", true);
        greenAnimator.SetBool("Death", true);
        orangeAnimator.SetBool("Death", true);
        pinkAnimator.SetBool("Death", true);
    }

    public void SetDeathOff()
    {
        whiteAnimator.SetBool("Death", false);
        blueAnimator.SetBool("Death", false);
        greenAnimator.SetBool("Death", false);
        orangeAnimator.SetBool("Death", false);
        pinkAnimator.SetBool("Death", false);
    }

    public void PlayIdle()
    {
        whiteAnimator.Play("Skull_White_Idle");
        blueAnimator.Play("Skull_Blue_Idle");
        greenAnimator.Play("Skull_Green_Idle");
        orangeAnimator.Play("Skull_Orange_Idle");
        pinkAnimator.Play("Skull_Pink_Idle");
    }
}
