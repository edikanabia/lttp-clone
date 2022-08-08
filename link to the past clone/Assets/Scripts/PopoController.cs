using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoController : MonoBehaviour
{
    public float popoSpeed;
    private int direction;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        direction = Random.Range(1, 8);

        Debug.Log("Direction is " + direction);

        if(Random.Range(1, 100) >= 90)
        {
            switch(direction)
            {
                case 1:
                    transform.Translate(popoSpeed, 0, 0);
                    break;
                case 2:
                    transform.Translate(popoSpeed, -popoSpeed, 0);
                    break;
                case 3:
                    transform.Translate(0, -popoSpeed, 0);
                    break;
                case 4:
                    transform.Translate(-popoSpeed, -popoSpeed, 0);
                    break;
                case 5:
                    transform.Translate(-popoSpeed, 0, 0);
                    break;
                case 6:
                    transform.Translate(-popoSpeed, popoSpeed, 0);;
                    break;
                case 7:
                    transform.Translate(0, popoSpeed, 0);
                    break;
                case 8:
                    transform.Translate(popoSpeed, popoSpeed, 0);
                    break;
            }
        }
    }
}
