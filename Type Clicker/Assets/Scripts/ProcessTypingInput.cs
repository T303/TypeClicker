using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessTypingInput : MonoBehaviour
{
    int positionInSentence = 0;
    int positionToPop = 0;
    public TMPro.TextMeshProUGUI outputText;
    public LetterPopper letterPopper;

    //[SerializeField] VFXManager vfx;

    bool inRace = false;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    public Color backgroundColor;
    void Start()
    {
        //outputText.text = fileReader.getSentence();
        SetCurrentWord();
    }



    private void SetCurrentWord()
    {
        currentWord = FileReader.Instance.getSentence();
        
        //gm.updateRaceState(false);
        WPMCalculator.Instance.resetWPM();
        positionInSentence = 0;
        outputText.text = currentWord;
        Debug.Log("outputText is set to " + currentWord);
        VFXManager.Instance.setInitialPositionOfInsertionPoint(outputText);
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
        WPMCalculator.Instance.startTimer();
        if (IsCorrectLetter(typedLetter))
        {
            GameManager.Instance.increasePoints(1);
            WPMCalculator.Instance.characterWasPressed();
            RemoveLetter();
            addTypedLetter();
            VFXManager.Instance.pop(outputText, typedLetter);
            if (IsWordComplete())
            {
                finishSentence();
                SetCurrentWord();
            }
        } else
        {
            VFXManager.Instance.markError(outputText);
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    public void addTypedLetter()
    {
        currentWord = currentWord.Insert(positionInSentence + 1, "</color>");
        string colorHex = ColorUtility.ToHtmlStringRGB(backgroundColor);
        currentWord = currentWord.Insert(positionInSentence, "<color=#" + colorHex + ">");
        positionInSentence += 24;
        outputText.text = currentWord;
    }

    public void finishSentence()
    {
        WPMCalculator.Instance.updateWPM();
        //letterPopper.resetPositionInSentence();
        VFXManager.Instance.resetPositionInSentence();
        //gm.setBackgroundForNonTyping();
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
