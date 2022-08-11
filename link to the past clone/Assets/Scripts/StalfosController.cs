using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosController : MonoBehaviour
{
    public float delay;
    public float time;
    public float waitDelay;
    public float waitTime;

    int direction = 1;
    int newDirection;
    // bool facingUp;
    // bool facingDown;
    // bool facingLeft;
    // bool facingRight;

    public float stalfosSpeed;
    float speed;

    public Rigidbody2D rb;
    public BoxCollider2D box;

    void Start()
    {
        delay = Random.Range(0.75f, 1.5f);
        direction = Random.Range(1, 5);

        speed = stalfosSpeed;
    }
 
    void FixedUpdate() 
    {
        if(waitTime > 0) {
            waitTime -= Time.deltaTime;
 
            if(waitTime < 0) waitTime = 0;
            return;
        }


        if(time > 0) 
        {
            time -= Time.deltaTime;

            //up
            if(direction == 1)
            {
                Vector3 tempVect = new Vector3(0, 1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }


            //down
            if(direction == 2)
            {
                Vector3 tempVect = new Vector3(0, -1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }


            //left
            if(direction == 3)
            {
                Vector3 tempVect = new Vector3(-1, 0, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }


            //right
            if(direction == 4)
            {
                Vector3 tempVect = new Vector3(1, 0, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            
            
        }
 
        if(time < 0) time = 0;

        if(time == 0)
        {

            switch(direction)
            {
                case 1: //Up
                    newDirection = Random.Range(3, 5);
                    break;
                case 2: //Down
                    newDirection = Random.Range(3, 5);
                    break;
                case 3: //Left
                    newDirection = Random.Range(1, 3);
                    break;
                case 4: //Right
                    newDirection = Random.Range(1, 3);
                    break;
            }
            direction = newDirection;

            delay = Random.Range(0.75f, 1.5f);
            time = delay;
            waitTime = waitDelay;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            box.isTrigger = true;
            speed = 0;
        }

        if(collision.gameObject.tag == "HorizontalObject" || collision.gameObject.tag == "VerticalObject")
        {
            direction = Random.Range(1, 5);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            box.isTrigger = false;
            speed = stalfosSpeed;
        }
    }

    // int currentPoint;
    // int destinationPoint;
    
    // public float stalfosstalfosSpeed;

    // int startingRotation;
    // int newRotation;
    // public bool facingUp;
    // public bool facingDown;
    // public bool facingLeft;
    // public bool facingRight;

    // void Start()
    // {
    //     facingUp = false;
    //     facingDown = false;
    //     facingLeft = false;
    //     facingRight = false;

    //     currentPoint = 0;

    //     startingRotation = Random.Range(1, 5);
    //     Debug.Log("Starting rotations is " + startingRotation);

    //     switch(startingRotation)
    //     {
    //         case 1:
    //             facingUp = true;
    //             Debug.Log("facing up is true");
    //             break;
    //         case 2:
    //             facingDown = true;
    //             Debug.Log("facing down is true");
    //             break;
    //         case 3:
    //             facingLeft = true;
    //             Debug.Log("facing left is true");
    //             break;
    //         case 4:
    //             facingRight = true;
    //             Debug.Log("facing right is true");
    //             break;
                
    //     }

    // }


    // void FixedUpdate()
    // {
    //     currentPoint = 0;
    //     destinationPoint = Random.Range(1, 11);

    //     if(facingUp)
    //     {
    //         Debug.Log("facing up");
    //         while(currentPoint < destinationPoint)
    //         {
    //             transform.Translate(0, stalfosstalfosSpeed, 0);
    //             currentPoint++;
    //         }
            
    //         newRotation = Random.Range(1, 3);

    //         switch(newRotation)
    //         {
    //             case 1:
    //                 facingLeft = true;
    //                 break;
    //             case 2:
    //                 facingRight = true;
    //                 break;
    //         }

    //         facingUp = false;
    //     }

    //     if(facingDown)
    //     {
    //         Debug.Log("facing down");
    //         while(currentPoint < destinationPoint)
    //         {
    //             transform.Translate(0, -stalfosstalfosSpeed, 0);
    //             currentPoint++;
    //         }

    //         newRotation = Random.Range(1, 3); 

    //         switch(newRotation)
    //         {
    //             case 1:
    //                 facingLeft = true;
    //                 break;
    //             case 2:
    //                 facingRight = true;
    //                 break;
    //         }

    //         facingDown = false;
    //     }

    //     if(facingLeft)
    //     {
    //         Debug.Log("facing left");

    //         while(currentPoint < destinationPoint)
    //         {
    //             transform.Translate(-stalfosstalfosSpeed, 0, 0);
    //         }


    //         newRotation = Random.Range(1, 3);

    //         switch(newRotation)
    //         {
    //             case 1:
    //                 facingUp = true;
    //                 break;
    //             case 2:
    //                 facingDown = true;
    //                 break;
    //         }

    //         facingLeft = false;
    //     }

    //     if(facingRight)
    //     {
    //         Debug.Log("facing right");

    //         while(currentPoint < destinationPoint)
    //         {
    //             transform.Translate(stalfosstalfosSpeed, 0, 0);
    //         }

            
    //         newRotation = Random.Range(1, 3);

    //         switch(newRotation)
    //         {
    //             case 1:
    //                 facingUp = true;
    //                 break;
    //             case 2:
    //                 facingDown = true;
    //                 break;
    //         }

    //         facingRight = false;
    //     }

        


    // }

}
