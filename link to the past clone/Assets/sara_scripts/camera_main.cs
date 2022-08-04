using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_main : MonoBehaviour
{
    public int room_number = 1;


    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 _velocity = Vector3.zero;
    private PlayerController _Link;

    public float limitLeft, limitRight, LimitBottom, LimitTop;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            _Link = target.GetComponent<PlayerController>();
        }
    }

    private void Update()
    {
        //regular camera
        Transform currentTarget = target;
        Vector3 desiredPosition = currentTarget.position + offset;
        transform.position = desiredPosition;
        
        
    }
}
