using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class temp_link_movement : MonoBehaviour
{
    public int current_floor = 1;
    public float tempLinkSpeed = 0;
    public Rigidbody2D tempLink_c;

    public bool link_can_move = true;

    //order in layer vars
    public int sortingOrder = 16;
    public int order_upper = 16;
    public int order_lower = 5;
    private SpriteRenderer tempLinkSprite;

    private Vector2 _movement;


    //public Camera cam;

    private void Start()
    {
        tempLinkSprite = GetComponent<SpriteRenderer>();       
    }


    //movement
    private void Update()
    { 
        if(link_can_move == true)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        }
        
    }

    private void FixedUpdate()
    {
        tempLink_c.MovePosition(tempLink_c.position + _movement * tempLinkSpeed);
    }

    //change order in layer when on the lower floor AND
    //disable collision with borders on the upper floor AND
    //activate collision with borders when returning to the upper floor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lower_floor")
        {
            tempLinkSprite.sortingOrder = order_lower;
            border_dis.instance.DisableCollisionsWithBorders();
            border_dis.instance.ActivateCollisionsWithDeco();
            border_dis.instance.ActivateCollisionsWithLowWalls();
        }
        else if (collision.gameObject.tag == "upper_floor")
        {
            
            border_dis.instance.ActivateCollisionsWithBorders();
            tempLinkSprite.sortingOrder = order_upper;
            border_dis.instance.DisableCollisionsWithDeco();
            border_dis.instance.DisableCollisionsWithLowWalls();
        }

        if(collision.gameObject.tag == "stairs")
        {
            tempLinkSpeed = 0.01f;
        }else{
            tempLinkSpeed = 0.04f;
        }
        if(collision.gameObject.tag == "door_rm_1")
        {
            link_can_move = false;
            tempLinkSpeed = 0.02f;
        }
        if (collision.gameObject.tag == "exit")
        {
            link_can_move = true;
            tempLinkSpeed = 0.05f;
        }
   
        //camera_boundaries change when in the new room
        if(collision.gameObject.tag == "room")
        {
            
            Camera.main.GetComponent<camera_main>().BoundCalc
                (collision.gameObject.GetComponent<RoomSetting>().room_camera_size, 
                collision.gameObject.transform.position);
        }

        }
    
}
