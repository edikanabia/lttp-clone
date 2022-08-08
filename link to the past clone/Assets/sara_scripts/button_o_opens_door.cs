using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_o_opens_door : MonoBehaviour
{
    bool door_open = false;
    public Rigidbody2D this_door;
    public GameObject this_door_;

    public Animator this_door_animator;

    private void Start()
    {
        door_open = false;
        this_door_animator = this_door.GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        if(door_open == false)
        {
            this_door_animator.SetBool("locked", true);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(door_open == false)
            {
                door_open = true;
                this_door_animator.SetBool("locked", false);
                this_door.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(Timedelay());
            } 
            else if(door_open == true)
            {
                door_open = false;
                this_door_animator.SetBool("locked", true);
                this_door.GetComponent<BoxCollider2D>().enabled = true;
                this_door.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    //delay
    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.3f);
        this_door.GetComponent<SpriteRenderer>().enabled = false;
    }

}
