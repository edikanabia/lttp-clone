using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosController : MonoBehaviour
{
    public static StalfosController instance;
    public float delay;
    public float time;
    public float waitDelay;
    public float waitTime;

    int direction = 1;
    int newDirection;

    float speed;

    public Rigidbody2D rb;
    public BoxCollider2D box;

    void Start()
    {
        delay = Random.Range(0.75f, 1.5f);
        direction = Random.Range(1, 5);

        speed = gameObject.GetComponent<Enemy>().enemySpeed;
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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HorizontalObject" || collision.gameObject.tag == "VerticalObject" || collision.gameObject.tag == "Pot")
        {
            direction = Random.Range(1, 5);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HorizontalObject" || collision.gameObject.tag == "VerticalObject" || collision.gameObject.tag == "Pot")
        {
            box.isTrigger = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "HorizontalObject" || collision.gameObject.tag == "VerticalObject" || collision.gameObject.tag == "Pot")
        {
            box.isTrigger = true;
        }
    }

}
