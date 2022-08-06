using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_borders_change : MonoBehaviour
{
    public int room_number = 1;
    public float limitLeft, limitRight, limitBottom, limitTop;

    public void SetBoundariesForDifferentRooms()
    {
        if (room_number == 1)
        {
            limitLeft = -1.03f;
            limitRight = 0.9f;
            limitBottom = -1.1f;
            limitTop = 0.4f;
        }
        else if (room_number == 2)
        {
            limitLeft = -1.6f;
            limitRight = 1.6f;
            limitBottom = 2.15f;
            limitTop = 3.95f;
        }
        else if (room_number == 3)
        {
            limitLeft = -1.68f;
            limitRight = 1.34f;
            limitBottom = 5.83f;
            limitTop = 9.97f;
        }
        else if (room_number == 4)
        {
            limitLeft = -1.86f;
            limitRight = 1.66f;
            limitBottom = 11.35f;
            limitTop = 15.4f;
        }
        else if (room_number == 5)
        {
            limitLeft = -5.2f;
            limitRight = -4.23f;
            limitBottom = 5.83f;
            limitTop = 10.36f;
        }
        else if (room_number == 6)
        {
            limitLeft = -5.14f;
            limitRight = -4.18f;
            limitBottom = 12.41f;
            limitTop = 15.52f;
        }
        else if (room_number == 7)
        {
            limitLeft = -8.26f;
            limitRight = -6.94f;
            limitBottom = 13.15f;
            limitTop = 15.52f;
        }
        else if (room_number == 8)
        {
            limitLeft = 3.68f;
            limitRight = 4.9f;
            limitBottom = 8.67f;
            limitTop = 10.05f;
        }
        else if (room_number == 9)
        {
            limitLeft = 6.57f;
            limitRight = 7.93f;
            limitBottom = 8.67f;
            limitTop = 10.05f;
        }
        else if (room_number == 10)
        {
            limitLeft = -8.26f;
            limitRight = -6.82f;
            limitBottom = 14.67f;
            limitTop = 15.99f;
        }
        else if (room_number == 11)
        {
            limitLeft = 3.66f;
            limitRight = 4.95f;
            limitBottom = 11.49f;
            limitTop = 15.45f;
        }
        else if (room_number == 12)
        {
            limitLeft = 6.48f;
            limitRight = 7.77f;
            limitBottom = 11.4f;
            limitTop = 12.85f;
        }
        else if (room_number == 13)
        {
            limitLeft = 6.48f;
            limitRight = 7.77f;
            limitBottom = 14.21f;
            limitTop = 15.67f;
        }
        else if (room_number == 14)
        {
            limitLeft = -1.44f;
            limitRight = 0.96f;
            limitBottom = 17.3f;
            limitTop = 18.71f;
        }
        else if (room_number == 15)
        {
            limitLeft = 0.53f;
            limitRight = 1.51f;
            limitBottom = 20.254f;
            limitTop = 21.07f;
        }
    }
}
