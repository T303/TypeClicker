using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundUpdater : MonoBehaviour
{
    public Color startColor;
    public Color typingColor;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //image = GetComponent<Image>();
        image.color = startColor;
    }

    public void changeBackgroundColorForTyping()
    {
        image.color = typingColor;
        Debug.Log("Background for typing");
    }

    public void changeBackgroundColorForPretype()
    {
        image.color = startColor;
        Debug.Log("Background for pretype");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
