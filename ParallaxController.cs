using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public GameController gameCtrl;
    public SkullAnimCtrl animCtrl;
    public PlayerMoviment moveCtrl;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animCtrl = GameObject.Find("Player").GetComponent<SkullAnimCtrl>();
        moveCtrl = GameObject.Find("Player").GetComponent<PlayerMoviment>();
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCtrl.parallax == true)
        {
            if (moveCtrl.directionStatus == PlayerMoviment.MovimentDirection.Right)
            {
                if(animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Walk || animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Jump)
                {
                    transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                }                
            }
            if (moveCtrl.directionStatus == PlayerMoviment.MovimentDirection.Left)
            {
                if(animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Walk || animCtrl.poseStatus == SkullAnimCtrl.AnimationPose.Jump)
                {
                    transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }
        }        
    }
}
