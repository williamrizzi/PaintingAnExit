using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperScript : MonoBehaviour
{

    private Animator anim;

    IEnumerator WaitToBack()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Jump",false);
    }

    // Start is called before the first frame update
    void Start()
    {       
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Jump", false);
    }

    void Update()
    {
        if(anim.GetBool("Jump") == true)
        {
            StartCoroutine("WaitToBack");
        }
    }
}
