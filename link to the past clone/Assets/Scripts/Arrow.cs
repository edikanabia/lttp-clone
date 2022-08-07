using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject player;
    GameObject enemy;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !enemy.GetComponent<Enemy>().invulnerable)
        {
            enemy.GetComponent<Enemy>().enemyHealth -= 2;
            Destroy(this.gameObject);
            player.GetComponent<Bow>().hasShot = false;
        }

        if(collision.gameObject.tag == "Object")
        {
            Destroy(this.gameObject);
            player.GetComponent<Bow>().hasShot = false;

            //StartCoroutine(CanShootAgain());
        }
    }

    // IEnumerator CanShootAgain()
    // {
    //     yield return new WaitForSeconds(3.0f);
    //     player.GetComponent<Bow>().hasShot = false;
    // }
}
