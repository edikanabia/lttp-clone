using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 2;
    public int enemyAttackPower;
    public bool invulnerable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Death Code
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
