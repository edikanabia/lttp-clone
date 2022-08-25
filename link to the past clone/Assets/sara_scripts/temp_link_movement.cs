using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class temp_link_movement : MonoBehaviour
{
    //vars from Kris scripts (for health, enemies etc)
    public static temp_link_movement instance;

    public int maxHealth = 6;
    public int health;
    float speed;

    //RUPIS COUNT
    public int rupeeCount = 0;

    //KEYS
    public int keys;
    public bool hasKeys;
    public bool hasBigKey;

    //for movement
    public int current_floor = 1;
    public float tempLinkSpeed;
    public Rigidbody2D tempLink_c;

    public bool link_can_move = true;
    private Vector2 _movement;


    //order in layer vars
    public int sortingOrder = 16;
    public int order_upper = 16;
    public int order_lower = 5;
    private SpriteRenderer tempLinkSprite;


  


    //animation vars
    public Animator LinkAnimator;
    private Vector2 _previousPosition;


    private void Awake()
    {
        instance = this;

        speed = tempLinkSpeed;

        health = maxHealth;
    }

    private void Start()
    {
        tempLinkSprite = GetComponent<SpriteRenderer>();
        _previousPosition = tempLink_c.position;
    }


    //movement
    private void Update()
    { 
        if(link_can_move == true)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        }

        if (keys > 0)
        {
            hasKeys = true;
        }
        else
        {
            hasKeys = false;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(tempLink_c.position == _previousPosition)
        {
            LinkAnimator.SetBool("is_moving", false);
        }
        else
        {
            LinkAnimator.SetBool("is_moving", true);
            if(_movement.y < 0)
            {
                LinkAnimator.SetInteger("direction", 1);
            }
            if (_movement.x < 0)
            {
                LinkAnimator.SetInteger("direction", 3);
            }
            if (_movement.y > 0)
            {
                LinkAnimator.SetInteger("direction", 2);
            }
            if (_movement.x > 0)
            {
                LinkAnimator.SetInteger("direction", 4);
            }
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void FixedUpdate()
    {
        tempLink_c.MovePosition(tempLink_c.position + _movement * tempLinkSpeed);

        //animation
        // if(tempLink_c.position == _previousPosition)
        // {
        //     LinkAnimator.SetBool("is_moving", false);
        // }
        // else
        // {
        //     LinkAnimator.SetBool("is_moving", true);
        //     if(_movement.y < 0)
        //     {
        //         LinkAnimator.SetInteger("direction", 1);
        //     }
        //     if (_movement.x < 0)
        //     {
        //         LinkAnimator.SetInteger("direction", 3);
        //     }
        //     if (_movement.y > 0)
        //     {
        //         LinkAnimator.SetInteger("direction", 2);
        //     }
        //     if (_movement.x > 0)
        //     {
        //         LinkAnimator.SetInteger("direction", 4);
        //     }
        // }

        _previousPosition = tempLink_c.position;

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
            tempLinkSpeed = 0.03f;
        }
        if(collision.gameObject.tag == "door_rm_1")
        {
            link_can_move = false;
            tempLinkSpeed = 0.02f;
        }
        if (collision.gameObject.tag == "exit")
        {
            link_can_move = true;
            tempLinkSpeed = 0.03f;
        }
   
        //camera_boundaries change when in the new room
        if(collision.gameObject.tag == "room")
        {
            
            Camera.main.GetComponent<camera_main>().BoundCalc
                (collision.gameObject.GetComponent<RoomSetting>().room_camera_size, 
                collision.gameObject.transform.position);
        }

        //COLLECTING RUPIES AND HEARTS
        if (collision.gameObject.tag == "Rupee")
        {
            rupeeCount += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Heart")
        {
            int healthGained = 2;
            health += healthGained;

            //if health is higher than max health: set health to max health
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            Destroy(collision.gameObject);
        }

        //COLLECTING KEYS
        if (collision.gameObject.tag == "Key")
        {
            keys += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Big Key")
        {
            hasBigKey = true;
            Destroy(collision.gameObject);
        }
    }





    //KNOCKBACK
    public IEnumerator playerKnockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        speed = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            tempLink_c.AddForce(-direction * knockbackPower);
        }

        yield return new WaitForSeconds(0.2f);

        speed = tempLinkSpeed;

    }

}
