using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevoaScript : MonoBehaviour
{
    public GameController gameCtrl;

    public float timer;
    public int random;
    public SpriteRenderer[] heads;

    public bool blockTimer;

    public AudioSource audioSource;
    public AudioClip audioLaugh;

    IEnumerator HeadAnim()
    {
        random = Random.Range(0, 1);
        heads[random].enabled = true;
        audioSource.clip = audioLaugh;
        audioSource.Play();
        yield return new WaitForSeconds(4f);
        heads[random].enabled = false;
        blockTimer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        blockTimer = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameCtrl.gameStatus == GameController.GameManage.InGame)
        {
            if (blockTimer == false)
            {
                timer += Time.deltaTime;
            }
            if (timer >= 8)
            {
                timer = 0;
                blockTimer = true;
                StartCoroutine("HeadAnim");
            }
        }   
        if(gameCtrl.gameStatus == GameController.GameManage.Menu)
        {
            timer = 0;
        }
        if(gameCtrl.gameStatus == GameController.GameManage.Death || gameCtrl.gameStatus == GameController.GameManage.Victory)
        {
            blockTimer = true;
        }
    }
}
