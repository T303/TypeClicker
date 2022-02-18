using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameObject errorPrefab;
    [SerializeField] GameObject letter;

    private static VFXManager _instance;
    public static VFXManager Instance { get { return _instance; } }

    //public Rigidbody2D letter;
    public Canvas canvas;
    [SerializeField] Transform lettersParent;
    static int positionInSentence;

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

    private void Start()
    {
        resetPositionInSentence();
    }

    public void markError(TextMeshProUGUI outputText)
    {
        Vector3 positionOfFirstLetter = outputText.textInfo.characterInfo[positionInSentence].bottomLeft;
        Vector3 worldPositionOfLetter = outputText.transform.TransformPoint(positionOfFirstLetter); //Now we have an accurate world position of the letter that was just typed
        if (outputText.textInfo.characterInfo[positionInSentence].character.Equals(' '))
        {
            //Space position was a little off for some reason so Im checking to see if the key that is supposed to be typed was a space and adjusting if so
            worldPositionOfLetter = new Vector3(worldPositionOfLetter.x - .04f, worldPositionOfLetter.y + .025f, worldPositionOfLetter.z); //adjusting position to be near the center
            GameObject errorMarkWithSpace = Instantiate(errorPrefab, worldPositionOfLetter, Quaternion.identity, canvas.transform);
            ErrorMarker errorMarkerWithSpace = errorMarkWithSpace.GetComponent<ErrorMarker>();
            errorMarkerWithSpace.setWidth(7);
            return;
        }

        
        //worldPositionOfLetter = new Vector3(worldPositionOfLetter.x + .1f, worldPositionOfLetter.y+.2f, worldPositionOfLetter.z); //adjusting position to be near the center
        worldPositionOfLetter = new Vector3(worldPositionOfLetter.x, worldPositionOfLetter.y, worldPositionOfLetter.z); //adjusting position to be near the center
        GameObject errorMark = Instantiate(errorPrefab, worldPositionOfLetter, Quaternion.identity, canvas.transform);
        ErrorMarker errorMarker = errorMark.GetComponent<ErrorMarker>();


        
        char c = outputText.textInfo.characterInfo[positionInSentence].character;
        float advance = outputText.textInfo.characterInfo[positionInSentence].xAdvance;
        float origin = outputText.textInfo.characterInfo[positionInSentence].origin;

        errorMarker.setWidth((advance - origin) + .75f);

        //Debug.Log(c + " has origin " + origin);
        //Debug.Log(c + " has advance " + advance);
        //Debug.Log("space between? " + (advance - origin));

    }

    public void pop(TextMeshProUGUI outputText, string letterChar)
    {
        //Debug.Log(outputText.textInfo.characterInfo[index].character);
        Vector3 positionOfFirstLetter = outputText.textInfo.characterInfo[positionInSentence].topLeft;
        Vector3 worldPositionOfLetter = outputText.transform.TransformPoint(positionOfFirstLetter); //Now we have an accurate world position of the letter that was just typed
        worldPositionOfLetter = new Vector3(worldPositionOfLetter.x + .1f, worldPositionOfLetter.y + .1f, worldPositionOfLetter.z); //adjusting position to be near the center

        //Creating the popped letter in the canvas
        GameObject poppingText = Instantiate(letter, worldPositionOfLetter, Quaternion.identity, canvas.transform);
        poppingText.transform.SetParent(lettersParent);
        //setting the letter of the TMP to the letter that was typed
        TextMeshProUGUI letterObject = poppingText.gameObject.GetComponent<TextMeshProUGUI>();
        letterObject.text = letterChar;

        //Adding forces to the letter to make it fly
        //Vector2 direction = new Vector2(Random.Range(-2, 2), Random.Range(1, 3));
        Rigidbody2D poppingTextRB = poppingText.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(-1, 2);
        poppingTextRB.AddForce(direction * 100);
        poppingTextRB.AddTorque(200);
        //letterObject.gameObject.transform.SetParent(canvas.transform);

        //adjusting the position for the next letter in characterInfo array
        positionInSentence++;
    }

    public void resetPositionInSentence()
    {
        positionInSentence = 0;
    }
}
