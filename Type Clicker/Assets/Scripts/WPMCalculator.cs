using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WPMCalculator : MonoBehaviour
{

    private static WPMCalculator _instance;
    public static WPMCalculator Instance { get { return _instance; } }

    float time;
    float timeFromStartOfSentence;
    public TMPro.TextMeshProUGUI outputWPM;
    bool timerHasStarted = false;

    int lettersTyped = 0;
    float totalWPMSum = 0;

    public GameManager gm;
    //float wpm = 0;
    // Start is called before the first frame update

    public void startTimer()
    {
        if (!timerHasStarted)
        {
            timerHasStarted = true;
            gm.setBackgroundForTyping();
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        time = Time.time;
        timeFromStartOfSentence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time)
        {
            if (timerHasStarted)
            {
                timeFromStartOfSentence += (Time.time - time);
            }
            time = Time.time;
            
        }
    }

    public void updateWPM()
    {
        float cps = lettersTyped / timeFromStartOfSentence;
        float cpm = cps * 60;
        float wpm = cpm / 5;

        //Debug.Log("letters typed: " + lettersTyped + ", time taken: " + time +  ", cps: " + (lettersTyped / timeSinceLastCharacter) + ", cpm: " + ((lettersTyped / timeSinceLastCharacter) * 60) + ", wpm: " + (((lettersTyped / timeSinceLastCharacter) * 60) / 5));
        outputWPM.text = "wpm: " + ((int) wpm);
    }

    public void characterWasPressed()
    {
        lettersTyped++;
    }

    public void resetWPM()
    {
        lettersTyped = 0;
        timeFromStartOfSentence = 0;
        timerHasStarted = false;
        gm.setBackgroundForNonTyping();
    }
}
