using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchClicker : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] keyPressed;
    public AudioClip[] keyReleased;
    bool holdingDown;
    // Start is called before the first frame update
    void Start()
    {
        //audioSourcePressed = GetComponent<AudioSource>();
        holdingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        pressRandomKey();
    }

    public void pressRandomKey()
    {
        int keyClick = Random.Range(1, keyPressed.Length);
        if (Input.anyKeyDown)
        {
            //checks to see if mouse button is pressed to filter out mouse clicks for buttons pressed
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                return;
            }
            if (Input.GetKeyDown("space"))
            {
                holdingDown = true;
                audioSource.PlayOneShot(keyPressed[0], .5f);
                return;
            }
            //play the button pressed sound
            holdingDown = true;
            audioSource.PlayOneShot(keyPressed[keyClick]);
        }

        if (!Input.anyKey && holdingDown)
        {
            if (Input.GetKeyDown("space"))
            {
                holdingDown = false;
                audioSource.PlayOneShot(keyReleased[0], .5f);
                return;
            }
            holdingDown = false;
            audioSource.PlayOneShot(keyReleased[keyClick], .5f);
        }
    }

    
}
