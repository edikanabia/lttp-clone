using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int arrowAttackPower = 2;
    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject player;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitEnemy = collision.gameObject;

        if(collision.gameObject.tag == "Enemy" && !hitEnemy.GetComponent<Enemy>().invulnerable)
        {
            hitEnemy.GetComponent<Enemy>().TakeDamage(arrowAttackPower);
            Destroy(this.gameObject);
            player.GetComponent<Bow>().hasShot = false;
        }

        if(collision.gameObject.tag == "HorizontalObject" || collision.gameObject.tag == "VerticalObject")
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
