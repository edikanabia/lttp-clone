using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors_auto_lock : MonoBehaviour
{
    bool door_open = true;
    public Rigidbody2D door1;
    public GameObject door1_;
    
    //public Rigidbody2D door2;
    //public GameObject door2_;

    public Animator door1_animator;
   // public Animator door2_animator;

    private void Start()
    {
        door_open = true;
        door1_animator = door1.GetComponent<Animator>();
        //door2_animator = door2.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (door_open == false)
        {
            door1_animator.SetBool("locked", true);
            //door2_animator.SetBool("locked", true);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (door_open == true)
            {
                door_open = false;
                //animation
                door1_animator.SetBool("locked", true);
                //door2_animator.SetBool("locked", true);
                //colliders back, Lick cant go
                door1.GetComponent<BoxCollider2D>().enabled = true;
                //door2.GetComponent<BoxCollider2D>().enabled = true;
                //door can be seen again
                door1.GetComponent<SpriteRenderer>().enabled = true;
                //door2.GetComponent<SpriteRenderer>().enabled = true;
                Destroy(this);
            }
        }
    }

    //delay
    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.3f);
        door1.GetComponent<SpriteRenderer>().enabled = false;
        //door2.GetComponent<SpriteRenderer>().enabled = false;
    }

}
