using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangingText : MonoBehaviour
{
    public Text output;
    string message;
    int sentenceIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        message = "sample sentence";
        output.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            message = message.Insert(sentenceIndex + 1, "</color>");
            message = message.Insert(sentenceIndex, "<color=breen>");
            sentenceIndex += 22;
            //message = "<color=green>" + message + "</color>";
            output.text = message;
        }
    }
}
