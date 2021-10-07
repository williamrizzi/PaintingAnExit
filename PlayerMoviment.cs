using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Enums
    public enum ControllerSwitch
    {
        Keyboard, Joystick
    }
    public enum ControllerPatterns
    {
        Layout1, Layout2
    }

    public enum MovimentDirection
    {
        Left, Right
    }
    // Enums Status
    public ControllerSwitch controllerStatus;
    public ControllerPatterns layoutStatus;
    public MovimentDirection directionStatus;

    // Game Manegement
    public bool controllerBlock;

    // General Game References
    private GameController gameCtrl;
    private ButtonController buttonCtrl;
    private CameraFollow camera;
    private AudioSource sourceAudio;

    public AudioClip clip1;
    public AudioClip clip2;

    //Physics and Moviment Modifiers
    public Rigidbody2D rigid;
    public float moveSpeed;
    public float jumpForce;
    public float jumperForce;
    public float fanForce;
    public bool grounded;

    // ColorManagement
    public int colorLevel;

    // Animations
    private SkullAnimCtrl animCtrl;

    // Start is called before the first frame update
    void Start()
    {
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animCtrl = gameObject.GetComponent<SkullAnimCtrl>();
        buttonCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonController>();
        colorLevel = 1;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCtrl.gameStatus == GameController.GameManage.InGame)
        {
            rigid.simulated = true;
            ControllerMoviment();
        }
        else if(gameCtrl.gameStatus != GameController.GameManage.InGame)
        {
            rigid.simulated = false;
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(colorLevel < 6)
            {
                colorLevel += 1;
            }
        }
    }
    
    public void ControllerMoviment()
    {
        if(controllerBlock == false)
        {
            if (controllerStatus == ControllerSwitch.Keyboard)
            {
                
            }
            if (controllerStatus == ControllerSwitch.Joystick)
            {
                float x = Input.GetAxis("Horizontal");
                rigid.velocity = new Vector2(x * moveSpeed, rigid.velocity.y);
                if (x > 0)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                    directionStatus = MovimentDirection.Right;
                }
                else if (x < 0)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                    directionStatus = MovimentDirection.Left;
                }
                if (rigid.velocity.x == 0 && animCtrl.poseStatus != SkullAnimCtrl.AnimationPose.Idle)
                {
                    animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Idle;
                }
                else if (rigid.velocity.x != 0)
                {
                    animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Walk;
                }
                if (layoutStatus == ControllerPatterns.Layout1)
                {
                    if (Input.GetButtonDown("Jump1"))
                    {
                        ColorSwitch();
                        if (grounded == true)
                        {
                            sourceAudio.clip = clip1;
                            sourceAudio.Play();
                            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                            animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Jump;
                        }
                        if(grounded == false)
                        {
                            sourceAudio.clip = clip2;
                            sourceAudio.Play();
                        }
                    }
                }
                if (grounded == false)
                {
                    animCtrl.poseStatus = SkullAnimCtrl.AnimationPose.Jump;
                }
            }
        }        
    }

    public void ColorSwitch()
    {
        if(colorLevel == 1)
        {
            if(gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.White;
            }
        }
        else if(colorLevel == 2)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Blue;

            }else if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.White;
            }
        }
        else if (colorLevel == 3)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Blue;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Green;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Green)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.White;
            }
        }
        else if (colorLevel == 4)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Blue;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Green;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Green)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Orange;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Orange)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.White;
            }
        }
        else if (colorLevel == 5)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Blue;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Green;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Green)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Orange;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Orange)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.Pink;
            }
            else if (gameCtrl.colorStatus == GameController.PlayerColors.Pink)
            {
                gameCtrl.colorStatus = GameController.PlayerColors.White;
            }
        }
    }

    public void ForceJumper()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumperForce);
    }

    public void ForceFan()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, fanForce);
    }

    public void ForcePortal()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumperForce / 2);
    }

    public void ForceDeath()
    {        
        transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        rigid.bodyType = RigidbodyType2D.Static;

    }

    public void SetAnimDeath()
    {
        animCtrl.SetDeath();
    }

    public void SetAudioJumper()
    {

    }
}
