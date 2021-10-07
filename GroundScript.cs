using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // GameController
    private GameController gameCtrl;

    // Spots to Move
    public GameObject spotUp;
    public GameObject spotDown;
    public GameObject colliders;

    // Set the Plataform Color
    public bool whitePlat;
    public bool bluePlat;
    public bool greenPlat;
    public bool orangePlat;
    public bool pinkPlat;

    // Block Move Speed
    public float moveSpeed;
    
    void Start()
    {
        // Find GameController Script
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if(whitePlat == true)
        {
            colliders = GameObject.Find("White_Colliders");
        }
        else if (bluePlat == true)
        {
            colliders = GameObject.Find("Blue_Colliders");
        }
        else if (greenPlat == true)
        {
            colliders = GameObject.Find("Green_Colliders");
        }
        else if (orangePlat == true)
        {
            colliders = GameObject.Find("Orange_Colliders");
        }
        else if (pinkPlat == true)
        {
            colliders = GameObject.Find("Pink_Colliders");
        }
    }

    void Update()
    {
        CheckToMove();
    }

    public void CheckToMove()
    {
        // White Verify
        if (gameCtrl.colorStatus == GameController.PlayerColors.White && whitePlat == true)
        {
            MoveToUp();
        }
        else if (gameCtrl.colorStatus != GameController.PlayerColors.White && whitePlat == true)
        {
            MoveToDown();
        }
        
        // Blue Verify
        if (gameCtrl.colorStatus == GameController.PlayerColors.Blue && bluePlat == true)
        {
            MoveToUp();
        }
        else if (gameCtrl.colorStatus != GameController.PlayerColors.Blue && bluePlat == true)
        {
            MoveToDown();
        }

        // Green Verify
        if (gameCtrl.colorStatus == GameController.PlayerColors.Green && greenPlat == true)
        {
            MoveToUp();
        }
        else if (gameCtrl.colorStatus != GameController.PlayerColors.Green && greenPlat == true)
        {
            MoveToDown();
        }

        // Orange Verify
        if (gameCtrl.colorStatus == GameController.PlayerColors.Orange && orangePlat == true)
        {
            MoveToUp();
        }
        else if (gameCtrl.colorStatus != GameController.PlayerColors.Orange && orangePlat == true)
        {
            MoveToDown();
        }

        // Pink Verify
        if (gameCtrl.colorStatus == GameController.PlayerColors.Pink && pinkPlat == true)
        {
            MoveToUp();
        }
        else if (gameCtrl.colorStatus != GameController.PlayerColors.Pink && pinkPlat == true)
        {
            MoveToDown();
        }
    }

    public void MoveToUp()
    {
        if(transform.position.y < spotUp.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1 * moveSpeed, transform.position.z);
        }
        if(transform.position.y > -0.7f)
        {
            colliders.SetActive(true);
        }
    }

    public void MoveToDown()
    {        
        if (transform.position.y > spotDown.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1 * moveSpeed, transform.position.z);
        }
        if(transform.position.y < -0.7f)
        {
            colliders.SetActive(false);
        }
    }
}
