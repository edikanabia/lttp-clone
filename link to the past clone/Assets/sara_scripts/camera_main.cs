using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_main : MonoBehaviour
{
   // public int room_number = 1;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 _velocity = Vector3.zero;
    private PlayerController _Link;

    public static Vector2 room_size;
    public static Vector3 room_pos;

    //public static BoxCollider2D boundaries;
    public float limitLeft, limitRight, limitBottom, limitTop;

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
        //first room bounderies
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, limitLeft, limitRight), Mathf.Clamp(desiredPosition.y, limitBottom, limitTop), desiredPosition.z);
    }

    public void BoundCalc(Vector2 size, Vector3 pos)
    {
        limitRight = pos.x + (size.x/4 );
        limitLeft = pos.x - (size.x/4 );
        limitBottom = pos.y - (size.y/4 );
        limitTop = pos.y + (size.y /4);
    }
}
