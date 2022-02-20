using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class FileReader : MonoBehaviour
{
    private static FileReader _instance;
    public static FileReader Instance { get { return _instance; } }

    string path = "Assets/Texts/The_Fourth_Dimension.txt";
    [SerializeField] TextAsset TheCommunistManifesto;
    [SerializeField] TextAsset TheFourthDimension;
    [SerializeField] TextAsset topWords;
    StreamReader reader;
    string[] words;

    public Text outputText;
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
        /*
        //reader = new StreamReader(TheCommunistManifesto.text);
        //words = reader.ReadToEnd().Split(' ');
        //words = TheCommunistManifesto.ToString().Split(' ');
        //words = TheFourthDimension.ToString().Split(' ');
        */
        words = topWords.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //getSentence();
        }
    }

    public string getSentence()
    {
        string typingText = "";
        int numWords = 10;
        for (int i = 0; i < numWords; i++)
        {
            typingText += this.getWord();
            if (i < numWords - 1)
            {
                typingText += " ";
            }
        }
        return typingText;
    }

    public string getWord()
    {

        return this.words[UnityEngine.Random.Range(0, this.words.Length)];
        /*
        while (true)
        {
            string word = this.words[Random.Range(0, this.words.Length)];
            if (word.Contains(" ") || word.Length < 1)
            {
                continue;
            }
            char[] letters = word.ToCharArray();
            bool isValid = true;
            foreach (char c in letters)
            {
                if (!char.IsLetter(c))
                {
                    isValid = false;
                }
            }
            if (isValid)
            {
                return word.ToLower();
            }
            continue;
        }
        if(words != null)
        {
            while (true)
            {
                //checking individual condition that are wrong
                string word = words[Random.Range(0, words.Length)];
                if (word.Contains(".") || word.Contains(",") || word.Contains("?") || word.Contains(" ") || word.Contains("\n") || word.Contains("\"") || word.Contains("(") || word.Contains(")") || word.Contains("/"))
                {
                    continue;
                }
                return word.ToLower();
                
                //checking each letter to see if its right
                try
                {
                    string word = this.words[Random.Range(0, this.words.Length)];
                    if (word.Contains(" "))
                    {
                        continue;
                    }
                    //string[] letters = word.Split();
                    char[] letters = word.ToCharArray();
                    bool isValid = true;
                    foreach (char c in letters)
                    {
                        if (char.IsLetter(c))
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        return word.ToLower();
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (System.NullReferenceException e)
                {
                    Debug.Log("Words has not been parced yet");
                    return "Error";
                }

            }
        } else
        {
            return "ERROR";
        }
        */
    }
}