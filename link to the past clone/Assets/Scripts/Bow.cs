using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool hasBow;
    public bool hasShot;

    void Start()
    {
        hasShot = false;
    }

    void Update()
    {
        if(hasBow)
        {
            if(Input.GetKeyDown(KeyCode.E) && !hasShot)
            {
                Shoot();
                hasShot = true;
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
