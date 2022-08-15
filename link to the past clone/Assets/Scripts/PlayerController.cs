using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public int maxHealth = 6;
    int health;

    public float playerSpeed;
    float speed;

    public Rigidbody2D playerRB;
    private Vector2 _movement;

    int rupeeCount = 0;

    //public Animator playerAnimator;
    private Vector2 _previousPosition;

    private void Awake()
    {
        instance = this;

        speed = playerSpeed;

        health = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        _previousPosition = playerRB.position;

    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Rupee")
        {
            rupeeCount += 1;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Heart")
        {
            int healthGained = 2;
            health += healthGained;

            //if health is higher than max health: set health to max health
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator playerKnockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;
        
        speed = 0;

        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            playerRB.AddForce(-direction * knockbackPower);
        }

        yield return new WaitForSeconds(0.2f);

        speed = playerSpeed;

    }

    //updates at time intervals 
    //(rather than by frames, 
    //so as to not tie things to framerate).
    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + _movement * speed);

        _previousPosition = playerRB.position;
    }
}
