using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public Rigidbody2D enemyRb;

    public int enemyHealth = 2;
    public int enemyAttackPower = 1;
    public bool invulnerable;

    public float enemySpeed;
    float speed;

    public float enemyKnockbackPower = 100;
    public float enemyKnockDuration = 1;

    private void Awake()
    {
        instance = this;

        speed = enemySpeed;
    }

    void Update()
    {
        //Death Code
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    public IEnumerator enemyKnockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;
        
        speed = 0;

        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            enemyRb.AddForce(-direction * knockbackPower);
        }

        yield return new WaitForSeconds(0.05f);

        speed = enemySpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitPlayer = collision.gameObject;

        //On player collision: player takes damage and gets knocked back
        if(collision.gameObject.tag == "Player")
        {
            hitPlayer.GetComponent<PlayerController>().TakeDamage(enemyAttackPower);
            StartCoroutine(PlayerController.instance.playerKnockback(enemyKnockDuration, enemyKnockbackPower, this.transform));
        }
    }
    
}
