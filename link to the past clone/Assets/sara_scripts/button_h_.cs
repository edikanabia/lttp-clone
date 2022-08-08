using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_h_ : MonoBehaviour
{
    bool door_open = false;
    public Rigidbody2D this_door;
    public GameObject this_door_;

    public Rigidbody2D pair_door;
    public GameObject pair_door_;

    public Animator this_door_animator;
    public Animator pair_door_animator;
    public Animator h_b_animator;

    private void Start()
    {
        door_open = false;
        this_door_animator = this_door.GetComponent<Animator>();
        pair_door_animator = pair_door.GetComponent<Animator>();

    }

    //private void FixedUpdate()
    //{
      //  if (door_open == false)
      //  {
       //     this_door_animator.SetBool("locked", true);
        //    pair_door_animator.SetBool("locked", true);
       // }
   // }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            h_b_animator.SetBool("pressed", true);

            if (door_open == false)
            {
                door_open = true;
                //play animations
                this_door_animator.SetBool("locked", false);
                pair_door_animator.SetBool("locked", false);
                //no more collision, Link can go through
                this_door.GetComponent<BoxCollider2D>().enabled = false;
                pair_door.GetComponent<BoxCollider2D>().enabled = false;
                //doors disappears after delay
                StartCoroutine(Timedelay());
                StartCoroutine(Timedelay2());
            }
            else if (door_open == true)
            {
                door_open = false;
                //animation
                this_door_animator.SetBool("locked", true);
                pair_door_animator.SetBool("locked", true);
                //colliders back, Lick cant go
                this_door.GetComponent<BoxCollider2D>().enabled = true;
                pair_door.GetComponent<BoxCollider2D>().enabled = true;
                //door can be seen again
                this_door.GetComponent<SpriteRenderer>().enabled = true;
                pair_door.GetComponent<SpriteRenderer>().enabled = true;
                StartCoroutine(Timedelay2());
            }
        }
    }

    //delay
    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(0.3f);
        this_door.GetComponent<SpriteRenderer>().enabled = false;
        pair_door.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Timedelay2()
    {
        yield return new WaitForSeconds(1);
        h_b_animator.SetBool("pressed", false);
    }

}
