using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_link_movement : MonoBehaviour
{

    public float tempLinkSpeed = 10f;
    public Rigidbody2D tempLink_c ;

    private Vector2 _movement;

    private void Start()
    {
        
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        tempLink_c.MovePosition(tempLink_c.position + _movement * tempLinkSpeed);
    }
}
