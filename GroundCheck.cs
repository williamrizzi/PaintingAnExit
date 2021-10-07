using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Player Moviment Script
    private PlayerMoviment moveScript;

    public bool groundCheckUp;
    public bool groundCheckDown;

    public GameObject groundCheckObj;
    IEnumerator WaitGrounded()
    {
        yield return new WaitForSeconds(0.1f);
        groundCheckObj.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoviment>();
        groundCheckObj = GameObject.Find("GroundCheckDown");
        if (Input.GetButtonDown("Jump1"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("WaitGrounded");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(groundCheckUp == true)
        {
            if(collision.transform.tag == "Ground")
            {
                groundCheckObj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(groundCheckDown == true)
        {
            if (collision.transform.tag == "Ground")
            {
                moveScript.grounded = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(groundCheckDown == true)
        {
            if (collision.transform.tag == "Ground")
            {
                moveScript.grounded = false;
            }
        }
        if(groundCheckUp == true){
            if (collision.transform.tag == "Ground")
            {
                StartCoroutine("WaitGrounded");
            }
        }
        
    }
}
