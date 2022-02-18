using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMarker : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void setWidth(float w)
    {
        var markerTransform = transform as RectTransform;
        markerTransform.sizeDelta = new Vector2(w, markerTransform.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        image.color -= new Color(0, 0, 0, .01f);
        if(image.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
