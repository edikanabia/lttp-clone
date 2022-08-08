using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFairyController : MonoBehaviour
{
    public float antiFairySpeedX;
    public float antiFairySpeedY;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        transform.Translate(antiFairySpeedX, antiFairySpeedY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "VerticalObject")
        {
            antiFairySpeedX *= -1;
        }

        if(collision.gameObject.tag == "HorizontalObject")
        {
            antiFairySpeedY *= -1;
        }
    }
}
