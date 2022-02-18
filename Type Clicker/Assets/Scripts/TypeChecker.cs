using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeChecker : MonoBehaviour
{
    int positionInSentence = 0;
    public FileReader fileReader;
    public TMPro.TextMeshProUGUI outputText;
    public GameManager gm;
    public WPMCalculator wpmCalc;
    public LetterPopper letterPopper;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        outputText.text = fileReader.getSentence();
        wpmCalc.resetWPM();
        SetCurrentWord();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return")){
            outputText.text = fileReader.getSentence();
        }
    }
    */

    private void SetCurrentWord()
    {
        currentWord = fileReader.getSentence();
        //gm.updateRaceState(false);
        wpmCalc.updateWPM();
        wpmCalc.resetWPM();
        positionInSentence = 0;
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord()
    {
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        outputText.text = currentWord;
    }

    private void Update()
    {
        CheckInput();
        if (Input.GetKeyDown("return"))
        {
            SetCurrentWord();
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1)
            {
                //Debug.Log(keysPressed);
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        //gm.updateRaceState(true);
        wpmCalc.startTimer();
        if (IsCorrectLetter(typedLetter))
        {
            gm.increasePoints(1);
            wpmCalc.characterWasPressed();
            RemoveLetter();
            addTypedLetter();
            //letterPopper.pop(outputText, positionInSentence);

            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    public void addTypedLetter()
    {
        //Debug.Log("current word is " + currentWord);
        //take the current that was typed and find its position in the string we can then concatenate the color tags before and after
        /*
        if (positionInSentence == 0)
        {
            string l = currentWord.Substring(positionInSentence, positionInSentence + 1);
            string aL = currentWord.Substring(positionInSentence + 1, currentWord.Length);
            currentWord = "<color=green>" + l + "</color>" + aL;
            outputText.text = currentWord;
            return;
        }
        
        
        string beforeLetter = currentWord.Substring(0, positionInSentence);
        string letter = currentWord.Substring(positionInSentence, positionInSentence + 1);
        //string afterLetter = currentWord.Substring(positionInSentence + 1, currentWord.Length);
        currentWord = beforeLetter + "<color=green>" + letter + "</color>" + afterLetter;
        outputText.text = currentWord;
        Debug.Log(currentWord.Length);
        
        string l = currentWord.Substring(0, 5);
        string aL = currentWord.Substring(5, 10);
        currentWord = "<color=green>" + l + "</color>" + aL;
        
        currentWord = "green!";
        currentWord.Insert(0, "|");
        currentWord.Insert(2, "/g");
        outputText.text = currentWord;
        positionInSentence++;
        */

        currentWord = currentWord.Insert(positionInSentence + 1, "</color>");
        currentWord = currentWord.Insert(positionInSentence, "<color=green>");
        positionInSentence += 22;
        //message = "<color=green>" + message + "</color>";
        outputText.text = currentWord;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
