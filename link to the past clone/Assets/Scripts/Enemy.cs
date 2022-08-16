using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public static Enemy instance;
    public Rigidbody2D enemyRb;
    public GameObject player;

    public int enemyHealth = 2;
    public int enemyAttackPower = 1;
    public bool invulnerable;

    public float enemySpeed;
    float speed;

    public float enemyKnockbackPower = 100;
    public float enemyKnockDuration = 1;
    public float playerKnockbackPower = 100;
    public float playerKnockbackDuration = 1;

    public Transform enemyTransform;
    public GameObject heartPrefab;
    public float heartChance = 0.75f;
    public GameObject rupeePrefab;
    public float rupeeChance = 0.5f;

    private void Awake()
    {
        //instance = this;

        speed = enemySpeed;
    }

    void Update()
    {
        //Death Code
        if(enemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        int pick = Random.Range(0, 2);

        if(pick == 0)
        {
            if(Random.Range(0f, 1f) >= heartChance)
            {
                Instantiate(heartPrefab, enemyTransform.position, enemyTransform.rotation);
            }
        }
        else
        {
            if(Random.Range(0f, 1f) >= rupeeChance)
            {
                Instantiate(rupeePrefab, enemyTransform.position, enemyTransform.rotation);
            }
        }  

        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(enemyKnockback(playerKnockbackDuration, playerKnockbackPower, player.transform));
        enemyHealth -= damage;
    }

    //public IEnumerator enemyKnockback(float knockbackDuration, float knockbackPower, Transform obj)
    //{
    //    Debug.Log("enemy knocked back");
    //    float timer = 0;

    //    speed = 0;
    //    Debug.Log("speed is " + speed);

    //    while (knockbackDuration > timer)
    //    {
    //        timer += Time.deltaTime;
    //        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
    //        enemyRb.AddForce(-direction * knockbackPower);
    //    }

    //    yield return new WaitForSeconds(0.2f);

    //    speed = enemySpeed;
    //    Debug.Log("speed is now " + speed);
    //}

    public IEnumerator enemyKnockback(float knockbackDuration, float knockbackPower, Transform obj)
    {


        speed = 0;
        Vector2 direction = (obj.transform.position - this.transform.position).normalized;
        enemyRb.AddForce(-direction * knockbackPower);

        yield return new WaitForSeconds(0.5f);

        speed = enemySpeed;
        //Debug.Log("speed is now " + speed);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GameObject hitPlayer = collision.gameObject;

    //    //On player collision: player takes damage and gets knocked back
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        hitPlayer.GetComponent<temp_link_movement>().TakeDamage(enemyAttackPower);
    //        //StartCoroutine(temp_link_movement.instance.playerKnockback(enemyKnockDuration, enemyKnockbackPower, this.transform));
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitPlayer = collision.gameObject;

        //On player collision: player takes damage and gets knocked back
        if (collision.gameObject.tag == "Player")
        {
            hitPlayer.GetComponent<temp_link_movement>().TakeDamage(enemyAttackPower);
            //StartCoroutine(temp_link_movement.instance.playerKnockback(enemyKnockDuration, enemyKnockbackPower, this.transform));
        }
    }

}
