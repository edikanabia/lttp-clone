using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    void Update()
    {

        //Rotates sword
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                180
            );
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                270
            );
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                0
            );
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                90
            );
        }

    }

}
