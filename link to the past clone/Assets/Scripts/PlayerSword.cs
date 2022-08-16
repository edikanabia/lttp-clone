using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask potLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 2;

    // public float swordKnockbackPower = 100;
    // public float swordKnockDuration = 1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 
            attackRange, enemyLayers);



        //for each enemy collided with: Enemy takes damage and gets knocked back
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log(enemy);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            //  StartCoroutine(enemy.gameObject.GetComponent<Enemy>().enemyKnockback(swordKnockDuration, swordKnockbackPower, enemy.transform));
        }


        Collider2D[] hitPots = Physics2D.OverlapCircleAll(attackPoint.position, 
            attackRange, potLayers);

        foreach(Collider2D pot in hitPots)
        {
            pot.GetComponent<Pot>().Break();
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
