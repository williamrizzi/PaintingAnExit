using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleColor : MonoBehaviour
{

    public string color;

    public Text text;

    public Color white;
    public Color blue;
    public Color green;
    public Color orange;
    public Color purple;

    public float timer;
    public float timerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        color = "white";
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += timerSpeed;

        if(timer > 3)
        {
            if(color == "white")
            {
                text.color = blue;                
                color = "blue";
                timer = 0;
            }
            else if (color == "blue")
            {
                text.color = green;
                color = "green";
                timer = 0;
            }
            else if (color == "green")
            {
                text.color = orange;
                color = "orange";
                timer = 0;
            }
            else if (color == "orange")
            {
                text.color = purple;
                color = "purple";
                timer = 0;
            }
            else if (color == "purple")
            {
                text.color = white;
                color = "white";
                timer = 0;
            }
        }
        
    }
}
