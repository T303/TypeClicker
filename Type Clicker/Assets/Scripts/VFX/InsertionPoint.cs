using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionPoint : MonoBehaviour
{
    private static InsertionPoint _instance;
    public static InsertionPoint Instance { get { return _instance; } }

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

    public void moveToNextLetter(float distance)
    {
        float posX = transform.position.x;
        posX += distance;
        Vector3 newPosition = new Vector3(posX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    public void setPosition(float xPos)
    {
        Vector3 newPosition = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
