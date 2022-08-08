using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool hasShot;

    void Start()
    {
        hasShot = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !hasShot)
        {
            Shoot();
            hasShot = true;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}