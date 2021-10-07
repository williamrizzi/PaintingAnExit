using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameController gameCtrl;
    public float moveSpeed;
    public Rigidbody2D rigid;
    
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (gameCtrl.gameStatus == GameController.GameManage.InGame)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);

            if (transform.position.x < player.transform.position.x - 7f)
            {
                moveSpeed = 10;
            }
            else if (transform.position.x > player.transform.position.x - 7f)
            {
                moveSpeed = 2;
            }
        }
        else if (gameCtrl.gameStatus != GameController.GameManage.InGame)
        {
            rigid.bodyType = RigidbodyType2D.Static;
        }
        

    }
}
