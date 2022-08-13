using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int playerHealth = 6;
    public float playerSpeed;
    float speed;
    public Rigidbody2D playerRB;
    private Vector2 _movement;

    //public Animator playerAnimator;
    private Vector2 _previousPosition;

    private void Awake()
    {
        instance = this;

        speed = playerSpeed;

        playerHealth = 6;
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

        if(playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     GameObject hitEnemy = collision.gameObject;

    //     if(collision.gameObject.tag == "Enemy")
    //     {
    //         playerHealth -= hitEnemy.GetComponent<Enemy>().enemyAttackPower;

            
    //     }
    // }

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
