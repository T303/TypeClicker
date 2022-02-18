using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject settingsBox;
    [SerializeField] GameObject textCurtain;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsBox.active)
            {
                closeSettingsPanel();
            } else
            {
                openSettingsPanel();
            }
        }
    }

    public void openSettingsPanel()
    {
        Debug.Log("clicked settings buttons");
        Time.timeScale = 0;
        //GameObject settingsBox = GameObject.Find("SettingsBox");
        settingsBox.SetActive(true);
        textCurtain.SetActive(true);
    }

    public void closeSettingsPanel()
    {
        Time.timeScale = 1;
        //GameObject settingsBox = GameObject.Find("SettingsBox");
        settingsBox.SetActive(false);
        textCurtain.SetActive(false);
    }

    public void adjustAudio(float level)
    {
        audioSource.volume = level;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
