using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class temp_link_movement : MonoBehaviour
{
    public int current_floor = 1;
    public float tempLinkSpeed = 10f;
    public Rigidbody2D tempLink_c;


    //order in layer vars
    public int sortingOrder = 16;
    public int order_upper = 16;
    public int order_lower = 5;
    private SpriteRenderer tempLinkSprite;

    private Vector2 _movement;

    private void Start()
    {
        tempLinkSprite = GetComponent<SpriteRenderer>();      
        
    }


    //movement
    private void Update()
    {
        //if (tempLinkSprite)
        // {
        //    tempLinkSprite.sortingOrder = order_upper;
        // }
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        tempLink_c.MovePosition(tempLink_c.position + _movement * tempLinkSpeed);
    }

    //change order in layer when on the lower floor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lower_floor")
        {
            tempLinkSprite.sortingOrder = order_lower;

        }
        else if (collision.gameObject.tag == "upper_floor")
        {        
            tempLinkSprite.sortingOrder = order_upper;
        }

    }
    
}
