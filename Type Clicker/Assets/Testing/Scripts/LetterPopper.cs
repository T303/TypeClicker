using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterPopper : MonoBehaviour
{
    public Rigidbody2D letter;
    public Canvas canvas;
    int positionInSentence;

    private void Start()
    {
        resetPositionInSentence();
    }

    public void pop(TextMeshProUGUI outputText, string letterChar)
    {
        //Debug.Log(outputText.textInfo.characterInfo[index].character);
        Vector3 positionOfFirstLetter = outputText.textInfo.characterInfo[positionInSentence].topLeft;
        Vector3 worldPositionOfLetter = outputText.transform.TransformPoint(positionOfFirstLetter); //Now we have an accurate world position of the letter that was just typed
        worldPositionOfLetter = new Vector3(worldPositionOfLetter.x + .1f, worldPositionOfLetter.y + .1f, worldPositionOfLetter.z); //adjusting position to be near the center

        //Creating the popped letter in the canvas
        Rigidbody2D poppingText = Instantiate(letter as Rigidbody2D, worldPositionOfLetter, Quaternion.identity, canvas.transform);

        //setting the letter of the TMP to the letter that was typed
        TextMeshProUGUI letterObject = poppingText.gameObject.GetComponent<TextMeshProUGUI>();
        letterObject.text = letterChar;

        //Adding forces to the letter to make it fly
        //Vector2 direction = new Vector2(Random.Range(-2, 2), Random.Range(1, 3));
        Vector2 direction = new Vector2(-1, 2);
        poppingText.AddForce(direction * 100);
        poppingText.AddTorque(200);
        //letterObject.gameObject.transform.SetParent(canvas.transform);

        //adjusting the position for the next letter in characterInfo array
        positionInSentence++;
    }

    public void resetPositionInSentence()
    {
        positionInSentence = 0;
    }
}
