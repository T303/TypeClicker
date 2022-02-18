using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    int positionInSentence = 0;
    public FileReader wordBank = null;
    public Text wordOutput = null;
    public Text TypedText = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string currentlyTypedSentence = string.Empty;



    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.getSentence();
        wordOutput.text = currentWord;
        remainingWord = currentWord;
        currentlyTypedSentence = string.Empty;
        TypedText.text = currentlyTypedSentence;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            addToTypedSentence(typedLetter);
            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private void addToTypedSentence(string typedLetter)
    {
        currentlyTypedSentence += typedLetter;
        TypedText.text = currentlyTypedSentence;
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        remainingWord = newString;
        string typedText = currentWord.Substring(0, positionInSentence);
        currentWord = "<color=green>" + typedText + "</color>" + currentWord.Substring(positionInSentence, currentWord.Length);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}