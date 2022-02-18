using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    int points;
    public TMPro.TextMeshProUGUI outputText;
    bool raceHasStarted = false;
    public backgroundUpdater bg;

    public Image background;

    public Color nonRaceColor;
    public Color raceColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }

        points = 0;
        background.color = nonRaceColor;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(background.color);
    }

    public void setBackgroundForTyping()
    {
        background.color = raceColor;
        //bg.changeBackgroundColorForTyping();
        Debug.Log("typing mode on");
    }

    public void setBackgroundForNonTyping()
    {
        background.color = nonRaceColor;
        //bg.changeBackgroundColorForPretype();
        Debug.Log("typing mode off");
    }
    /*
    public void updateRaceState(bool b)
    {
        if(raceHasStarted != b && !raceHasStarted)
        {
            bg.changeBackgroundColorForPretype();
            Debug.Log("Not In Typing Race");
        }
        if(raceHasStarted != b && raceHasStarted)
        {
            bg.changeBackgroundColorForTyping();
            Debug.Log("In Typing Race");
        }
        raceHasStarted = b;
    }
    */

    public void increasePoints(int x)
    {
        points += x;
        outputText.text = "$" + points;
    }
}
