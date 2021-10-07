using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public enum CameraMoviment
    {
        Menu, InGame, WaitMenu
    }

    public CameraMoviment cameraStatus;

    private GameController gameCtrl;
    private Transform target;
    public bool freezeCamera;
    private bool follow;

    public bool blackScreenActive;
    public SpriteRenderer blackScreen;

    public float smoothSpeed;
    public Vector2 offset;

    public Vector3 cameraPosition = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraStatus = CameraMoviment.WaitMenu;

        freezeCamera = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<SpriteRenderer>();
        Color c = blackScreen.material.color;
        c.a = 0f;
        blackScreen.material.color = c;
        blackScreen.enabled = true;
    }

    IEnumerator FadeIn()
    {
        for(float f = 0.05f; f<= 1; f+= 0.05f)
        {
            Color c = blackScreen.material.color;
            c.a = f;
            blackScreen.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Update()
    {
        if(gameCtrl.gameStatus == GameController.GameManage.Pause)
        {
            freezeCamera = true;
        }
        if(blackScreenActive == true)
        {

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (freezeCamera == false)
        {            
            if (follow)
            {
                cameraPosition = new Vector3(Mathf.SmoothStep(transform.position.x , target.transform.position.x + offset.x, 0.3f), transform.position.y);
                transform.position = cameraPosition + Vector3.forward * -10;
            }
        }
        if(freezeCamera == true)
        {
            if(cameraStatus == CameraMoviment.InGame)
            {
                cameraPosition = new Vector3(transform.position.x, Mathf.SmoothStep(transform.position.y, 0.1f, 0.3f));
                transform.position = cameraPosition + Vector3.forward * -10;
            }
            if(cameraStatus == CameraMoviment.Menu)
            {
                cameraPosition = new Vector3(Mathf.SmoothStep(transform.position.x, 0f, 0.3f), Mathf.SmoothStep(transform.position.y, 6.5f, 0.3f));
                transform.position = cameraPosition + Vector3.forward * -10;
            }
        }
    }

    public void SetFollow(bool r_Follow)
    {
        follow = r_Follow;
    }

    public void SetFreeze(bool r_Freeze)
    {
        freezeCamera = r_Freeze;
    }

    public void StartFadeIn()
    {
        StartCoroutine("FadeIn");
    }

    public void ResetBlackScreen()
    {
        Color c = blackScreen.material.color;
        c.a = 0f;
        blackScreen.material.color = c;
    }


}
