using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_o_opens_door : MonoBehaviour
{
    bool door_open = false;
    public Rigidbody2D this_door;
    

    private void Start()
    {
        //door_open = false;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(door_open == false)
            {
                door_open = true;
                this_door.GetComponent<BoxCollider2D>().enabled = false;
            } 
            else if(door_open == true)
            {
                door_open = false;
                this_door.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

}
