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

    public float limitLeft, limitRight, limitBottom, limitTop;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            _Link = target.GetComponent<PlayerController>();
        }
    }

    public void SetBoundariesForDifferentRooms()
    {
        if(room_number == 1)
        {
            limitLeft = -1.03f;
            limitRight = 0.9f;
            limitBottom = -1.1f;
            limitTop = 0.4f;
        }
    }

    private void Update()
    {
        //regular camera
        Transform currentTarget = target;
        Vector3 desiredPosition = currentTarget.position + offset;
        transform.position = desiredPosition;

        //first room bounderies
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, limitLeft, limitRight), Mathf.Clamp(desiredPosition.y, limitBottom, limitTop), desiredPosition.z);


    }
}
