using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private GameController gameCtrl;

    private BoxCollider2D col;

    public bool whiteFan;
    public bool blueFan;
    public bool greenFan;
    public bool orangeFan;
    public bool pinkFan;


    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (whiteFan)
        {
            if(gameCtrl.colorStatus == GameController.PlayerColors.White)
            {
                col.enabled = true;
            }
            else if (gameCtrl.colorStatus != GameController.PlayerColors.White) {
                col.enabled = false;
            }
        }
        if (blueFan)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.Blue)
            {
                col.enabled = true;
            }
            else if (gameCtrl.colorStatus != GameController.PlayerColors.Blue)
            {
                col.enabled = false;
            }
        }
        if (greenFan)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.Green)
            {
                col.enabled = true;
            }
            else if (gameCtrl.colorStatus != GameController.PlayerColors.Green)
            {
                col.enabled = false;
            }
        }
        if (orangeFan)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.Orange)
            {
                col.enabled = true;
            }
            else if (gameCtrl.colorStatus != GameController.PlayerColors.Orange)
            {
                col.enabled = false;
            }
        }
        if (pinkFan)
        {
            if (gameCtrl.colorStatus == GameController.PlayerColors.Pink)
            {
                col.enabled = true;
            }
            else if (gameCtrl.colorStatus != GameController.PlayerColors.Pink)
            {
                col.enabled = false;
            }
        }
    }
}
