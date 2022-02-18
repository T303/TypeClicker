using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppedLetter : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
