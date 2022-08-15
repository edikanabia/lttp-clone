using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoController : MonoBehaviour
{
    private int direction;
    public Rigidbody2D rb;
    public BoxCollider2D box;
    float speed;

    void Start()
    {
        speed = gameObject.GetComponent<Enemy>().enemySpeed;
    }

    void FixedUpdate()
    {
        direction = Random.Range(1, 9);

        //Debug.Log("Direction is " + direction);

        if(Random.Range(0, 100) >= 95)
        {

            if(direction == 1) //right
            {
                Vector3 tempVect = new Vector3(1, 0, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 2) //down right
            {
                Vector3 tempVect = new Vector3(1, -1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 3) //down 
            {
                Vector3 tempVect = new Vector3(0, -1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 4) //down left
            {
                Vector3 tempVect = new Vector3(-1, -1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 5) //left
            {
                Vector3 tempVect = new Vector3(-1, 0, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 6) //up left
            {
                Vector3 tempVect = new Vector3(-1, 1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 7) //up 
            {
                Vector3 tempVect = new Vector3(0, 1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }

            if(direction == 8) //up right
            {
                Vector3 tempVect = new Vector3(1, 1, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
            }
            
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
