using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordBank : MonoBehaviour
{
    string path = "Assets/Texts/The_Fourth_Dimension.txt";

    StreamReader reader;
    string[] words;


    /*
    private List<string> originalWords = new List<string>()
    {
        
    };
    */

    private List<string> workingWords = new List<string>();

    private void Start()
    {
        reader = new StreamReader(path);
        words = reader.ReadToEnd().Split('.');

        string newWord = words[Random.Range(0, words.Length)];
        Debug.Log(newWord.Length);
        foreach (string word in words)
        {
            //Debug.Log(word);
        }

        reader.Close();

    }
    private void Awake()
    {
        //workingWords.AddRange(originalWords);
        //Shuffle(words);
        ConvertToLower(workingWords);
    }

    private void Shuffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int random = Random.Range(i, array.Length);
            string temporary = array[i];

            array[i] = array[random];
            array[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = words[Random.Range(0, words.Length)];
        //Debug.Log(newWord.Length);

        foreach (string word in words)
        {
            //Debug.Log(word);
        }
        Debug.Log(newWord);
        return newWord;
    }
}