using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    void Update()
    {
        //Rotates firepoint
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                90
            );
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                180
            );
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                270
            );
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                0
            );
        }

    }
}
